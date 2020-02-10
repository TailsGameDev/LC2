using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSignUp : MonoBehaviour
{
    [SerializeField] SignUp signUp;

    [SerializeField] Text emailSignUp;
    [SerializeField] Text usernameSignUp;
    [SerializeField] Text passwordSignUp;

    public void StoreSignUpCredentials()
    {
        signUp.SetUsername(usernameSignUp.text);
        signUp.SetEmail(emailSignUp.text);
        signUp.SetPassword(passwordSignUp.text);
    }
}
