using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SignInManager : MonoBehaviour
{
    SignIn signIn;

    [SerializeField] Text emailSignIn;
    [SerializeField] Text passwordSignIn;

    [SerializeField] Text errorMessage;
    [SerializeField] Text successMessage;
    [SerializeField] float delayToDeactivate;

    private void Start()
    {
        signIn = new SignIn();
        signIn.onCredentialsOperationFailed += ActivateErrorMessage;
        signIn.onCredentialsOperationSucceed += ActivateSuccessMessage;
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

    public void StoreSignInCredentials()
    {
        signIn.SetEmail(emailSignIn.text);
        signIn.SetPassword(passwordSignIn.text);
    }

    public void Login()
    {
        signIn.Login();
    }

    public bool IsSignedIn()
    {
        return signIn.IsSignedIn();
    }
}
