using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerDataNetworkPusher
{
    public void PushPlayerData(Dictionary<string, string> data)
    {
        var updateUserDataRequest = new UpdateUserDataRequest()
        {
            Data = data
        };

        PlayFabClientAPI.UpdateUserData(updateUserDataRequest,
                                        OnPushDataSuccess,
                                        OnPushDataError);
    }

    private void OnPushDataSuccess(UpdateUserDataResult obj) { }

    private void OnPushDataError(PlayFabError obj)
    {
        Debug.LogError("PushDataError at PlayerData class!!");
    }
}
