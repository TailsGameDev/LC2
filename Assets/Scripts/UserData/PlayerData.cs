using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    string playFabID;

    PlayerDataNetworkPuller playerDataNetworkPuller = new PlayerDataNetworkPuller();
    PlayerDataNetworkPusher playerDataNetworkPusher = new PlayerDataNetworkPusher();

    Dictionary<string, string> userData;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerID(string playerID)
    {
        this.playFabID = playerID;
    }
    
    public void StoreDataLocally(string key, string value)
    {
        if( userData.ContainsKey(key) )
        {
            userData[key] = value;
        } else
        {
            userData.Add(key, value);
        }
    }

    public string GetDataLocally(string key)
    {
        string data;
        if (userData.ContainsKey(key))
        {
            data = userData[key];
        } else
        {
            data = "dataNotFound";
        }
        return data;
    }
   
    void SaveAllDataOnServer()
    {
        playerDataNetworkPusher.PushPlayerData(userData);
    }

    void RetreiveAllDataFromServer()
    {/* TODO: convert received data to string!!!
        Dictionary<string, UserDataRecord> userDataRecords =
                        playerDataNetworkPuller.GetPlayerData(playFabID);

        userData = new Dictionary<string, string>();

        foreach (string)
        */
    }
    
}
