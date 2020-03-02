using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{

    [SerializeField]
    float delay;

    void Start()
    {
        StartCoroutine(DestroyItself());
    }

    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
