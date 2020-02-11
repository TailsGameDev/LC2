using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class SignIn
{

    string userEmail;
    string userPassword;

    bool signedIn = false;

    public delegate void OnSignInFailed();
    public event OnSignInFailed onSignInFailed;

    public delegate void OnSignInSuccess();
    public event OnSignInSuccess onSignInSuccess;

    public void Login()
    {
        var req = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(req, SignInSuccessCallback, SignInFailedCallback);
    }

    private void SignInSuccessCallback(LoginResult result)
    {
        PlayFabIDConsumer.SetPlayFabId(result.PlayFabId);

        onSignInSuccess?.Invoke();

        signedIn = true;
    }

    public void SignInFailedCallback(PlayFabError error)
    {
        onSignInFailed?.Invoke();
        Debug.LogError(error.GenerateErrorReport());
    }

    public string GetEmail()
    {
        return this.userEmail;
    }

    public string GetPassword()
    {
        return this.userPassword;
    }

    public void SetEmail(string email)
    {
        this.userEmail = email;
    }

    public void SetPassword(string password)
    {
        this.userPassword = password;
    }

    public bool IsSignedIn()
    {
        return signedIn;
    }

}
