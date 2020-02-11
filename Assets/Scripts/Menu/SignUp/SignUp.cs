using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class SignUp : CredentialsHolder
{

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = base.userEmail,
            Username = base.username,
            Password = base.userPassword
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, SignUpSuccessCallback, CredentialsOperationFailCallback);
    }


    private void SignUpSuccessCallback(RegisterPlayFabUserResult result)
    {
        base.CredentialsOperationSuccessCallback();
    }

    
}
