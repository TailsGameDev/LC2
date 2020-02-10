using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class SignIn : MonoBehaviour
{

    string userEmail;
    string userPassword;

    public void Login()
    {
        var req = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(req, OnLoginSuccess, OnFailedLoginOrSignUp);
    }

    public void OnFailedLoginOrSignUp(PlayFabError error)
    {
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

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged in!!");
        UserDataManager.SetPlayerID(result.PlayFabId);
    }

}
