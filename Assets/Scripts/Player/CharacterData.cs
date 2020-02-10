using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    static UserDataManager userDataManager;

    Text playerName;

    void Start()
    {
        userDataManager = new UserDataManager();
        userDataManager.RetreiveAllDataFromServer();

        playerName.text = userDataManager.GetDataLocally("playerName");
    }

}
