using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserDataNetworkPuller
{

    Dictionary<string, UserDataRecord> userData;


    public Dictionary<string, UserDataRecord> GetUserData( string playFabID )
    {
        var getUserDataRequest = new GetUserDataRequest
        {
            PlayFabId = playFabID,
            Keys = null // null means I want all the available keys
        };

        PlayFabClientAPI.GetUserData(getUserDataRequest, OnGetDataSuccess, OnGetDataError);

        return userData;
    }


    private void OnGetDataSuccess(GetUserDataResult result)
    {
        userData = result.Data;
    }


    private void OnGetDataError(PlayFabError obj)
    {
        Debug.LogError("GetDataError at UserData class!!");
    }
}
