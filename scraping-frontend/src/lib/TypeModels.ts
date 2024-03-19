export type UserProfile = {
    id:string,
    name:string,
    created:Date,
    updated:Date,
}

export type SearchProvider={
    id:string,
    name:string,
    base64Image:string,
    baseUrl:string
}

export type UserSearch={
    id:string,
    profileId:string, 
    providerId:string,
    profileName:string,
    providerName:string,
    searchTerms:string,
    positions:string,
    time:Date
}

export type NewUserSearch={
    profileId:string, 
    providerId:string,
    searchTerms:string,
}

