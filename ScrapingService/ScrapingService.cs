using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using System.Diagnostics;

namespace ScraperService
{
    public class ScrapingService : IScrapingService
    {
        private readonly IDbService dbService;
        private readonly HttpClient httpClient;

        public ScrapingService(IDbService dbService, IHttpClientFactory httpClientFactory)
        {
            this.dbService = dbService;
            this.httpClient = httpClientFactory.CreateClient();
        }

        // Meat and potatoes of the project!        
        public async Task<UserSearch> Search(Guid ProfileId, Guid ProviderId, string searchTerms)
        {

            var profile = await dbService.Profiles.Get(ProfileId);
            var profileName = profile.IsSuccess ? profile.Value.Name : "";
            // baseUrl:  https://www.google.co.uk/search?num=100
            // query:   &q=land+registry+search
            var provider = await dbService.Providers.Get(ProviderId);
            if (provider.IsSuccess)
            {
                var result = provider.Value.Name switch
                {
                    "Google" => await SearchGoogle(provider.Value.BaseUrl, searchTerms),
                    "Google (Alt)" => await SearchGoogleAlt(provider.Value.BaseUrl, searchTerms),
                    //"DuckDuckGo" => await SearchDuckDuckGo(provider.Value.BaseUrl, searchTerms),
                    "Dogpile" => await SearchDogpile(provider.Value.BaseUrl, searchTerms),
                    _ => throw new ArgumentOutOfRangeException("cannot find matching provider")
                };
                // get profile Name 

                return new UserSearch(Guid.Empty, ProfileId, ProviderId, profileName, provider.Value.Name, searchTerms, result, DateTime.Now);
            }
            throw new Exception("something has gone wrong");
        }

        // Http Client classic. May work a couple of times before google get suspicous of our robotic intentions.
        private async Task<string> SearchGoogle(string baseUrl, string searchTerms)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDoc = await htmlWeb.LoadFromWebAsync($"{string.Format(baseUrl, searchTerms.Replace(' ', '+'))}");

            var divs = htmlDoc.DocumentNode.QuerySelectorAll("div.Gx5Zad.fP1Qef.xpd.EtOod.pkphOe");
            var totalResults = divs.Count();


            var results = new List<string>();
            var counter = 1;
            // See dogpile for alternate for loop
            foreach (var div in divs)
            {
                // We are looking for the first instance
                var anchors = div.Descendants().Select(node => node.Element("a")).First();
                var address = anchors.GetAttributes("href").First();
                var containsInfoTrack = address.Value.Contains("https://www.infotrack.co.uk");
                if (containsInfoTrack)
                {
                    results.Add(counter.ToString());
                }
                counter++;
            }
            return $"Total results = {totalResults}; Instances = {(results.Count > 0 ? String.Join(", ", results) : "0")}";
        }
        // Using Selenium to parse the results.
        // Notice the actual page content is very different to the original.
        private async Task<string> SearchGoogleAlt(string baseUrl, string searchTerms)
        {
            var chromeOptions = new ChromeOptions();
            // Headless browser gets trapped by CloudFlare doo-hickey
            // chromeOptions.AddArguments("--headless=new"); // comment out for testing
            IWebDriver driver = new ChromeDriver(chromeOptions);
            List<IWebElement> elements = new List<IWebElement>();
            // Navigate to the page and wait until it has loaded.
            driver.Navigate().GoToUrl($"{string.Format(baseUrl, searchTerms.Replace(' ', '+'))}");
            // Wait until page loaded
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 5, 0));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            // Do we have the cookie warning screen
            List<string> citeList = new();

            try
            {
                driver.FindElement(By.Id("W0wltc")).Click();
                new WebDriverWait(driver, new TimeSpan(0, 5, 0)).Until(cond =>
                {
                    try
                    {
                        // This header targets the header of search result.
                        var etd = cond.FindElements(By.CssSelector(".yuRUbf div.B6fmyf cite"));
                        if (etd.Count > 0)
                        {
                            var cnt = etd.Where(etd=>etd.Text.Length>0).Count();
                            foreach(var ele in etd)
                            {
                                Debug.WriteLine($"Text :{ele.GetAttribute("textContent")}");
                            }

                            citeList.AddRange(etd.Select(a => a.GetAttribute("textContent")).ToList());
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        return etd.Count > 0;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (NoSuchElementException ex)
            {
                // We eat the error if there is no button to click.
                ;
            }


            var pageSource = driver.PageSource;
            var totalResults = citeList.Count();

            var counter = 1;

            var results = new List<string>();

            foreach (var citeText in citeList)
            {
                // We are looking for the first instance
                if (citeText.Contains("https://www.infotrack.co.uk"))
                {
                    results.Add(counter.ToString());
                }
                counter++;
            }
            driver.Quit();
            return $"Total results = {totalResults}; Instances = {(results.Count > 0 ? String.Join(", ", results) : "0")}";
        }
        // ALternative Search engine, we have manually to press next for each page.
        // But it trips out after 9 pages.
        private async Task<string> SearchDogpile(string baseUrl, string searchTerms)
        {

            var chromeOptions = new ChromeOptions();
            // Headless browser gets trapped by CloudFlare doo-hickey
            // chromeOptions.AddArguments("--headless=new"); // comment out for testing
            IWebDriver driver = new ChromeDriver(chromeOptions);
            List<string> elements = new();
            // Navigate to the page and wait until it has loaded.
            driver.Navigate().GoToUrl($"{string.Format(baseUrl, searchTerms.Replace(' ', '+'))}");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 5, 0));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            var pageSource = driver.PageSource;
            elements.AddRange(driver.FindElements(By.CssSelector(".web-bing__url")).Select(a => a.Text));
            // Create a list to store the item details
            List<string[]> items = new List<string[]>();

            // WE keep clickon pages until we have the first 100 records or the we get kicked out becuase of cloud flare.
            while (elements.Count < 100)
            {
                try
                {
                    var btn = driver.FindElement(By.CssSelector(".pagination__num--next"));
                    btn.SendKeys(Keys.Enter);
                    var url = driver.Url;
                    WebDriverWait pageWaiter = new WebDriverWait(driver, new TimeSpan(0, 5, 0));
                    pageWaiter.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                    elements.AddRange(driver.FindElements(By.CssSelector(".web-bing__url")).Select(a => a.Text));
                }
                catch (NoSuchElementException ex)
                {
                    // This occurs on any page over 9 when using a browser.
                    break;
                }
            }

            var results = new List<string>();
            for (var x = 0; x < elements.Count; ++x)
            {
                Debug.WriteLine(elements[x].ToString());
                if (elements[x].ToLower().Contains("https://www.infotrack.co.uk"))
                {
                    results.Add(x.ToString());
                }
            }
            var totalResults = elements.Count;

            driver.Quit();
            return $"Total results = {totalResults}; Instances =  {(results.Count > 0 ? String.Join(",", results) : "0")}";
        }
    }
}
