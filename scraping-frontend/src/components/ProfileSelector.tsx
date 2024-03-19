import { BackendApiContext } from "@/lib/BackendApiService"
import { UserProfile } from "@/lib/TypeModels";
import { FormEvent, useContext, useEffect, useState } from "react"

export default function Profiles({ className }: { className?: string | undefined }) {
    var backendApi = useContext(BackendApiContext)
    var [profiles, setProfiles] = useState<Array<UserProfile>>([]);
    var [isLoading, setLoading] = useState(true);


    useEffect(() => {
        backendApi?.Profiles!.getAllProfiles()
            .then((allUsers) => {
                setProfiles(allUsers);
                setLoading(false);
            }).catch((reason) => {
                setLoading(false);
            });
    }, [])

    if (isLoading) return <p>Loading...</p>;


    function changeSelected(event: FormEvent<HTMLSelectElement>): void {
        event.preventDefault();
        var selectedValue = event.currentTarget.value;
        if (selectedValue === "-1") {
            backendApi!.Profiles.currentProfile = null;
        }
        else {
            var provider = profiles.filter((a) => a.id == selectedValue)[0];
            // set provider as selected
            backendApi!.Profiles!.currentProfile = provider;
        }

    }

    return (
        <div className="container mx-auto">
            <div className="container grid grid-cols-3">
                <select defaultValue={-1} onChangeCapture={changeSelected} className={className} >
                    <option value={-1} >(Not selected)</option>
                    {profiles.map((a) => (<Profile profile={a} key={a.id} />))}
                </select>
            </div>
        </div>);
}

const Profile = ({ profile }: { profile: UserProfile }): JSX.Element => {
    return (<>
        <option value={profile.id} >
            {profile.name}
        </option>
    </>
    );
}