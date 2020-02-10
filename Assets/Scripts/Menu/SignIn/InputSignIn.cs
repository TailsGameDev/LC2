using UnityEngine;
using UnityEngine.UI;

public class InputSignIn : MonoBehaviour
{
    [SerializeField] SignIn signIn;

    [SerializeField] Text emailSignIn;
    [SerializeField] Text passwordSignIn;

    public void StoreSignInCredentials()
    {
        signIn.SetEmail(emailSignIn.text);
        signIn.SetPassword(passwordSignIn.text);
    }
}
