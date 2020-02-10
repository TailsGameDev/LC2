using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject loadingUI;

    public void LoadScene(string sceneName)
    {
        loadingUI.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
    }

}
