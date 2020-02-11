using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class SignUp
{
    SignIn signIn;

    string username;

    public delegate void OnSignUpFailed();
    public event OnSignUpFailed onSignUpFailed;

    public delegate void OnSignUpSuccess();
    public event OnSignUpSuccess onSignUpSuccess;

    public SignUp()
    {
        signIn = new SignIn();
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = signIn.GetEmail(),
            Username = username,
            Password = signIn.GetPassword()
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, SignUpSuccessCallback, FailedSignUpCallback);
    }

    private void SignUpSuccessCallback(RegisterPlayFabUserResult result)
    {
        onSignUpSuccess?.Invoke();
    }

    private void FailedSignUpCallback(PlayFabError error)
    {
        onSignUpFailed?.Invoke();
        Debug.Log(error.ErrorMessage);
    }


    public void SetUsername(string username)
    {
        this.username = username;
    }

    public void SetEmail(string text)
    {
        signIn.SetEmail(text);
    }

    public void SetPassword(string text)
    {
        signIn.SetPassword(text);
    }
    
}
