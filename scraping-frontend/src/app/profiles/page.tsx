"use client"
import Profiles from "@/components/ProfileSelector";
import { BackendApiContext, BackendApiService } from "@/lib/BackendApiService";
var backendCtx = new BackendApiService();
export default function Page(): JSX.Element {
    return <BackendApiContext.Provider value={backendCtx}>
        <>
            <h1>Profiles page</h1>
            
            <p className="py-2">Select an existing profile, or add a new one.</p>

            <div className="grid grid-cols-2">
                <div>
                    <Profiles />
                </div>
                <div>

                </div>
            </div>
        </>

    </BackendApiContext.Provider>

};