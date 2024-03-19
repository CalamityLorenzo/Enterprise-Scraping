import { BackendApiContext } from "@/lib/BackendApiService"
import { SearchProvider, } from "@/lib/TypeModels";
import { FormEvent, useContext, useEffect, useState } from "react"

export default function Providers({ className }: { className?: string | undefined }) {
    var backendApi = useContext(BackendApiContext)
    var [providers, setProviders] = useState<Array<SearchProvider>>([]);
    var [isLoading, setLoading] = useState(true);

    useEffect(() => {
        backendApi?.Providers!.getAllProviders()
            .then((allUsers) => {
                setProviders(allUsers);
                setLoading(false);
            }).catch((reason) => {
                setLoading(false);
            });
    }, [])
    if (isLoading) return <p>Loading...</p>;


    function changeSelected(event: FormEvent<HTMLSelectElement>): void {
        var selectedValue = event.currentTarget.value;
        if (selectedValue === "-1") {
            backendApi!.Providers.currentProvider = null;
        }
        else {
            var provider = providers.filter((a) => a.id == selectedValue)[0];
            // set provider as selected
            backendApi!.Providers.currentProvider = provider;
        }
    }

    return (<>
        <div className="container mx-auto">
            <div className="container grid grid-cols-3">
                <select defaultValue={-1} onChangeCapture={changeSelected} className={className} >
                    <option value={-1} >(Not selected)</option>
                    {providers.map((a) => (<Provider provider={a} key={a.id} />))}
                </select>
            </div>
        </div>
    </>);

}

const DisplayProvider = ({ provider }: { provider: SearchProvider | null }): JSX.Element => {
    if (provider === null) return <p>No Provider selected</p>;
    return (<>
        <div key={provider.id} className="cursor-pointer col-span-1" >
            {provider.base64Image}
        </div>
        <div className="cursor-pointer col-span-1">
            {provider.name}
        </div>
        <div>
            {provider.baseUrl}
        </div>
        <div>

        </div>
    </>
    );
}

const Provider = ({ provider }: { provider: SearchProvider }): JSX.Element => {
    return (<>
        <option value={provider.id}>
            {provider.name}
        </option >
    </>
    );
}