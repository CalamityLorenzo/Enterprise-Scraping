"use client"
import { createContext } from "react";
import { NewUserSearch, SearchProvider, UserProfile, UserSearch } from "./TypeModels";


export class BackendApiService {
    Profiles: Profiles = new Profiles();
    Providers: Providers = new Providers();
    UserSearch: UserSearchService = new UserSearchService();
}
export const BackendApiContext = createContext<BackendApiService | null>(null);


class Profiles {
    private _currentProfile: UserProfile | null = null;
    public onProfileChanged?: () => void;
    async getAllProfiles(): Promise<Array<UserProfile>> {
        var res = await fetch(`${process.env.NEXT_PUBLIC_BACKEND_URL}profiles/`, {
            mode: "cors"
        });
        if (res.ok)
            return (await res.json() as Array<UserProfile>);
        return [];
    }

    async getProfile(id: string): Promise<UserProfile | null> {
        var res = await fetch(`${process.env.NEXT_PUBLIC_BACKEND_URL}profiles/id`, {
            mode: "cors"
        });
        if (res.ok)
            return (await res.json() as UserProfile);
        return null;
    }

    public get currentProfile(): UserProfile | null {
        return this._currentProfile;
    }
    public set currentProfile(profile: UserProfile | null) {
        this._currentProfile = profile;
        if (this.onProfileChanged)
            this.onProfileChanged();
    }
}

class Providers {
    public onProviderChanged?: () => void;
    private _currentProvider: SearchProvider | null = null;
    async getAllProviders(): Promise<Array<SearchProvider>> {

        var res = await fetch(`${process.env.NEXT_PUBLIC_BACKEND_URL}providers/`, {
            mode: "cors"
        });
        if (res.ok)
            return (await res.json() as Array<SearchProvider>);
        return [];
    }

    public get currentProvider(): SearchProvider | null {
        return this._currentProvider;
    }
    public set currentProvider(provider: SearchProvider | null) {
        this._currentProvider = provider;
        if (this.onProviderChanged)
            this.onProviderChanged();
    }
}

class UserSearchService {
    async newSearch(userSearch: NewUserSearch):Promise<UserSearch | null> {
        var res = await fetch(`${process.env.NEXT_PUBLIC_BACKEND_URL}searches`, {
            method: "POST",
            mode: "cors",
            headers:{
                "Content-Type":"application/json"
            },
            body: JSON.stringify(userSearch),
        });
        if (res.ok)
            return (await res.json() as UserSearch);
        return null;
    }
}
