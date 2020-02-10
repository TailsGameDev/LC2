using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserDataNetworkPusher
{
    public void PushUserData(UserData data)
    {
        var updateUserDataRequest = new UpdateUserDataRequest()
        {
            Data = data.getDataClone()
        };

        PlayFabClientAPI.UpdateUserData(updateUserDataRequest,
                                        OnPushDataSuccess,
                                        OnPushDataError);
    }

    private void OnPushDataSuccess(UpdateUserDataResult obj) { }

    private void OnPushDataError(PlayFabError obj)
    {
        Debug.LogError("PushDataError at UserData class!!");
    }
}
