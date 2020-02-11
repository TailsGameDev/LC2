using UnityEngine;

//this class asks UserDataManager to pull data from server, and notify when it is successfully pulled.

public class CharacterData : MonoBehaviour
{
    static UserDataManager userDataManager;

    public delegate void OnDataPulledFromServer();
    public event OnDataPulledFromServer onDataPulledFromServer;

    void Start()
    {
        userDataManager = new UserDataManager();

        userDataManager.onUserDataPulledFromServer += DataPulledFromServerCallback;

        userDataManager.PullUserDataFromServer();
    }


    public void StorePieceOfDataLocally(string key, string value)
    {
        userDataManager.StorePieceOfDataLocally(key, value);
    }


    public string GetPieceOfDataLocally(string key)
    {
        return userDataManager.GetPieceOfDataLocally(key);
    }


    public void PushDataToServer()
    {
        userDataManager.PushAllDataToServer();
    }


    public void PullDataFromServer()
    {
        userDataManager.PullUserDataFromServer();
    }


    void DataPulledFromServerCallback()
    {
        onDataPulledFromServer();
    }

}
