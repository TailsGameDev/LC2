using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHelper : MonoBehaviour
{
    [SerializeField] InputField thisInputField, nextInputField;
    [SerializeField] Button submitButton;

    void Update()
    {
        if (thisInputField.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                nextInputField.Select();
                nextInputField.ActivateInputField();
            }
        }
    }

    public void CallSubmitButton()
    {
        submitButton?.onClick?.Invoke();
    }
}
