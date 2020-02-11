using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpManager : MonoBehaviour
{
    SignUp signUp;

    [SerializeField] Text emailSignUp;
    [SerializeField] Text usernameSignUp;
    [SerializeField] Text passwordSignUp;

    [SerializeField] Text errorMessage;
    [SerializeField] Text successMessage;
    [SerializeField] float delayToDeactivate;

    private void Start()
    {
        signUp = new SignUp();
        signUp.onCredentialsOperationFailed += ActivateErrorMessage;
        signUp.onCredentialsOperationSucceed += ActivateSuccessMessage;
    }

    public void StoreSignUpCredentials()
    {
        signUp.SetUsername(usernameSignUp.text);
        signUp.SetEmail(emailSignUp.text);
        signUp.SetPassword(passwordSignUp.text);
    }

    public void Register()
    {
        signUp.Register();
    }

    void ActivateErrorMessage()
    {
        errorMessage.gameObject.SetActive(true);
        StartCoroutine(DisableText(errorMessage));
    }

    void ActivateSuccessMessage()
    {
        successMessage.gameObject.SetActive(true);
        StartCoroutine(DisableText(successMessage));
    }

    IEnumerator DisableText(Text text)
    {
        yield return new WaitForSeconds(delayToDeactivate);
        text.gameObject.SetActive(false);
    }
}
