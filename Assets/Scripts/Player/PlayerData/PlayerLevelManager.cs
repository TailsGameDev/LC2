using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelManager : MonoBehaviour
{
    [SerializeField] Text characterLevelText;
    [SerializeField] CharacterData characterData;

    private void Start()
    {
        characterData.onDataPulledFromServer += DisplayCharacterLevel;
    }

    void DisplayCharacterLevel() //called when data is pulled from server
    {
        characterLevelText.text = "lvl: " + GetCharacterLevel();
    }

    int GetCharacterLevel()
    {
        string level = characterData.GetPieceOfDataLocally("characterLevel");

        int characterLevel;

        if (level == "dataNotFound")
        {
            characterLevel = 1;
        }
        else
        {
            characterLevel = int.Parse(level);
        }
        return characterLevel;
    }

    public void LevelUp()
    {
        IncrementLevel();

        DisplayCharacterLevel();
    }

    void IncrementLevel()
    {
        int characterLevel = GetCharacterLevel();
        characterLevel++;
        StoreCharacterLevel(characterLevel);
    }

    void StoreCharacterLevel(int level)
    {
        characterData.StorePieceOfDataLocally("characterLevel", level.ToString());
    }
}
