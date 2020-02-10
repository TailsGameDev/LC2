using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelsActivator : MonoBehaviour
{
    [SerializeField] SignIn signInManager;

    [SerializeField] GameObject pannelToSignIn, alreadySignedInPannel;

    private void Update()
    {
        UpdateSignInPannels();
    }

    void UpdateSignInPannels()
    {
        bool signedIn = signInManager.IsSignedIn();

        alreadySignedInPannel.SetActive(signedIn);

        pannelToSignIn.SetActive(!signedIn);
    }
}
