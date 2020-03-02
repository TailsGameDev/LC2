using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]
    float delayToRestartScene;

    private void Start()
    {
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(delayToRestartScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
