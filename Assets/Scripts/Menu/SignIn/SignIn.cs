using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class SignIn : CredentialsHolder
{

    public void Login()
    {
        var req = new LoginWithEmailAddressRequest { Email = base.userEmail, Password = base.userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(req, SignInSuccessCallback, CredentialsOperationFailCallback);
    }

    private void SignInSuccessCallback(LoginResult result)
    {
        PlayFabIDConsumer.SetPlayFabId(result.PlayFabId);

        base.signedIn = true;

        base.CredentialsOperationSuccessCallback();
    }

}
