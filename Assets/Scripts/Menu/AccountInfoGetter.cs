using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class AccountInfoGetter : PlayFabIDConsumer
{
    string username;

    public string GetUsernameLocally()
    {
        return username;
    }

    public void PullInfoFromServer()
    {
        var req = new GetAccountInfoRequest { PlayFabId = base.GetPlayFabId() };
        PlayFabClientAPI.GetAccountInfo(req, OnGetInfoSucceed, OnGetInfoFailed);
    }

    private void OnGetInfoSucceed(GetAccountInfoResult result)
    {
        username = result.AccountInfo.Username;
    }

    private void OnGetInfoFailed(PlayFabError obj)
    {
        Debug.LogError("GetAccountInfo failed!!");
    }

}
