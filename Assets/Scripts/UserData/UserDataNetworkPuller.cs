using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class UserDataNetworkPuller
{

    UserDataManager userDataManager;

    public UserDataNetworkPuller(UserDataManager userDataManager)
    {
        this.userDataManager = userDataManager;
    }

    public void PullUserDataFromServer( string playFabId )
    {
        var getUserDataRequest = new GetUserDataRequest
        {
            PlayFabId = playFabId,
            Keys = null // null means I want all the available keys
        };

        PlayFabClientAPI.GetUserData(getUserDataRequest, PullDataSuccessCallback, PullDataErrorCallback);
    }

    private void PullDataSuccessCallback(GetUserDataResult result)
    {
        userDataManager.PullUserDataFromServerCallback(
            ToStringStringDictionary(result.Data)
        );
    }

    Dictionary<string, string> ToStringStringDictionary(Dictionary<string, UserDataRecord> userData)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        foreach (KeyValuePair<string, UserDataRecord> entry in userData)
        {
            data.Add(entry.Key, entry.Value.Value);
        }

        return data;
    }

    private void PullDataErrorCallback(PlayFabError obj)
    {
        Debug.LogError("GetDataError at UserData class!!");
    }
}
