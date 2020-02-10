using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameUI : MonoBehaviour
{

    [SerializeField] Text username;

    AccountInfoGetter accountInfoGetter = new AccountInfoGetter();

    private void OnEnable()
    {
        UpdateUsernameText();
    }

    void UpdateUsernameText()
    {
        accountInfoGetter.PullInfoFromServer();

        StartCoroutine( WaitInforInfoUpdateThenSetUsernameText() );
    }

    IEnumerator WaitInforInfoUpdateThenSetUsernameText()
    {
        while(accountInfoGetter.GetUsernameLocally() == null)
        {
            yield return null;
        }

        username.text = accountInfoGetter.GetUsernameLocally();
    }

}
