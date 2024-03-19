"use client"
import Profiles from "@/components/ProfileSelector";
import Providers from "@/components/ProvidersSelector";
import { BackendApiContext, BackendApiService } from "@/lib/BackendApiService";
var backendCtx = new BackendApiService();
export default function Page(): JSX.Element {
    return <BackendApiContext.Provider value={backendCtx}>
        <>
            <h1>Search Providers</h1>
            
            <p className="py-2">Select a search provider</p>

            <div className="grid grid-cols-2">
                <div>
                    <Providers />
                </div>
                <div>

                </div>
            </div>
        </>

    </BackendApiContext.Provider>

};