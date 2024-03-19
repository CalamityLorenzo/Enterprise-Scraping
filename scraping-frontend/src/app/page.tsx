"use client"
import Profiles from "@/components/ProfileSelector";
import Providers from "@/components/ProvidersSelector";
import { BackendApiContext, BackendApiService } from "@/lib/BackendApiService";
import { UserSearch } from "@/lib/TypeModels";
import { FormEvent, useState } from "react";
var backendCtx = new BackendApiService();


export default function Home() {
  var profileSelected = false;
  var providerSelected = false;

  var [displaySearch, setDisplaySearch] = useState(false);
  var [displaySearchResult, setDisplaySearchResult] = useState(false);
  var [searchResult, setSearchResult] = useState<UserSearch | null>(null);

  const checkStatus = (): void => {
    if (backendCtx.Profiles.currentProfile && backendCtx.Providers.currentProvider) {
      console.log("display search box");
      setDisplaySearch(true);
    } else {
      console.log("hide search box");
      setDisplaySearch(false);
    }
  }


  backendCtx.Profiles.onProfileChanged = () => {
    console.log("profile changed");
    profileSelected = true;
    checkStatus();
  }

  backendCtx.Providers.onProviderChanged = () => {
    console.log("provider changed");
    providerSelected = true;
    checkStatus();
  }

  const beginSearch = async (event: FormEvent<HTMLFormElement>): Promise<void> => {
    event.preventDefault();
    setDisplaySearchResult(false);
    var formData = new FormData(event.currentTarget);
    var result = await backendCtx.UserSearch.newSearch({
      profileId: backendCtx.Profiles.currentProfile!.id,
      providerId: backendCtx.Providers.currentProvider!.id,
      searchTerms: formData.get("defaultSearch") as string
    });
    setDisplaySearchResult(true);
    setSearchResult(result);
  }

  return (
    <main className="flex min-h-screen flex-col items-center p-24">
      <h1 className="mb-4 text-4xl font-extrabold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-6xl dark:text-white" >Search scraper</h1>
      <BackendApiContext.Provider value={backendCtx}>
        <div className="grid max-cols-2">
          <div className="col-span-2 col-span-2 text-2xl font-extrabold dark:text-white">Select Profile</div>
          <div>
            <Profiles className="block w-full p-4 ps-10 text-md" />
          </div> <div></div>
          <div className="col-span-2 text-2xl font-extrabold dark:text-white"><p>Select Provider</p></div>
          <div><Providers className="block w-full p-4 ps-10 text-md" />
          </div> <div></div>
        </div>
        {displaySearch ?
          <form className="grid max-cols-2" onSubmitCapture={beginSearch}>
            <input type="search" id="defaultSearch" name="defaultSearch" className="block w-full p-4 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" defaultValue="land registry searches" placeholder="Search" required />
            <button type="submit" className="text-white end-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Search</button>
          </form>
          : <></>}
        {displaySearchResult ?
          <div className="min-w-8 mt-4 px-4 font-semibold border bg-sky-500 border-cyan-600 backgroun text-white dark:text-white dark:border-gray-600">
            <h3>Result</h3>
            <div className="grid grid-flow-row-dense grid-cols-2">
              <div>Search Term</div>
              <div>{searchResult?.searchTerms}</div>
              <div>Positions found</div>
              <div>{searchResult?.positions}</div>
              <div>ProviderName</div>
              <div>{searchResult?.providerName}</div>
              <div>{new Date(searchResult!.time).toLocaleDateString("en-GB")}</div>
            </div>
          </div>
          : <>  </>}
      </BackendApiContext.Provider>
    </main>
  );
}
