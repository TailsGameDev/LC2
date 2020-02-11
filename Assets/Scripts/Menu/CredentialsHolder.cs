using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class CredentialsHolder
{
    protected string username;
    protected string userEmail;
    protected string userPassword;
    
    protected bool signedIn = false;

    public delegate void OnCredentialsOperationFailed();
    public event OnCredentialsOperationFailed onCredentialsOperationFailed;

    public delegate void OnCredentialsOperationSucceed();
    public event OnCredentialsOperationSucceed onCredentialsOperationSucceed;


    protected void CredentialsOperationSuccessCallback()
    {
        onCredentialsOperationSucceed?.Invoke();
    }

    public void CredentialsOperationFailCallback(PlayFabError error)
    {
        onCredentialsOperationFailed?.Invoke();
        Debug.LogError(error.GenerateErrorReport());
    }

    public bool IsSignedIn()
    {
        return signedIn;
    }


    public void SetEmail(string email)
    {
        this.userEmail = email;
    }
    public void SetPassword(string password)
    {
        this.userPassword = password;
    }
    public void SetUsername(string username)
    {
        this.username = username;
    }
}
