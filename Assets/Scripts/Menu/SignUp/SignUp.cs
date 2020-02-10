using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class SignUp : MonoBehaviour
{
    [SerializeField] SignIn signIn;

    [SerializeField] string username;

    public delegate void OnSignUpFailed();
    public event OnSignUpFailed onSignUpFailed;

    public delegate void OnSignUpSuccess();
    public event OnSignUpSuccess onSignUpSuccess;

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = signIn.GetEmail(),
            Username = username,
            Password = signIn.GetPassword()
        };

        print(signIn.GetEmail());
        print(username);
        print(signIn.GetPassword());

        PlayFabClientAPI.RegisterPlayFabUser(request, SignUpSuccessCallback, FailedSignUpCallback);
    }

    private void SignUpSuccessCallback(RegisterPlayFabUserResult result)
    {
        onSignUpSuccess?.Invoke();
    }

    private void FailedSignUpCallback(PlayFabError error)
    {
        onSignUpFailed?.Invoke();
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
