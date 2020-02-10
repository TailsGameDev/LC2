using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    static UserDataManager userDataManager;

    [SerializeField] Text characterLevelText;

    public void LevelUp()
    {
        int characterLevel = GetCharacterLevel();
        characterLevel++;
        userDataManager.StorePieceOfDataLocally("characterLevel", characterLevel+"");

        DisplayCharacterLevel();
    }

    public void PushDataToServer()
    {
        userDataManager.PushAllDataToServer();
    }

    void Start()
    {
        userDataManager = new UserDataManager();

        userDataManager.onUserDataPulledFromServer += DataPulledCallback;

        userDataManager.PullUserDataFromServer();
    }

    void DataPulledCallback()
    {
        DisplayCharacterLevel();
        userDataManager.StorePieceOfDataLocally("characterLevel", GetCharacterLevel().ToString());
    }

    void DisplayCharacterLevel()
    {
        characterLevelText.text = "lvl: " + GetCharacterLevel();
    }

    int GetCharacterLevel()
    {
        string level = userDataManager.GetPieceOfDataLocally("characterLevel");

        int characterLevel;

        if (level == "dataNotFound")
        {
            characterLevel = 1;
        } else
        {
            characterLevel = int.Parse(level);
        }
        return characterLevel;
    }

}
