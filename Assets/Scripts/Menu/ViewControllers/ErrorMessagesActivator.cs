using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessagesActivator : MonoBehaviour
{
    [SerializeField] SignUp signUp;
    [SerializeField] Text signUpErrorText;

    [SerializeField] SignIn signIn;
    [SerializeField] Text signInErrorText;

    [SerializeField] float delayToDeactivate = 3f;

    void Start()
    {
        signUp.onSignUpFailed += ActivateSignUpErrorText;
        signIn.onSignInFailed += ActivateSignInErrorText;
    }


    void ActivateSignUpErrorText()
    {
        signUpErrorText.gameObject.SetActive(true);
        StartCoroutine( DisableText(signUpErrorText) );
    }

    void ActivateSignInErrorText()
    {
        signInErrorText.gameObject.SetActive(true);
        StartCoroutine( DisableText(signInErrorText) );
    }

    IEnumerator DisableText(Text text)
    {
        yield return new WaitForSeconds(delayToDeactivate);
        text.gameObject.SetActive(false);
    }
}
