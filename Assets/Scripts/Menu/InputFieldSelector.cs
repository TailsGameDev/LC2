using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSelector : MonoBehaviour
{
    [SerializeField] InputField thisInputField, nextInputField;

    void Update()
    {
        if (thisInputField.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextInputField.Select();
            nextInputField.ActivateInputField();
        }
    }
}
