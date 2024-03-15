using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_InputField))]
public class InputFieldBoundsValidator : MonoBehaviour
{
    public int max = 100;
    public int min = 0;
    private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(ValidateInput);
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    public void ValidateInput(string input)
    {
        int value;


        if (!string.IsNullOrEmpty(input))
        {
            if (int.TryParse(input, out value))
            {
                value = Mathf.Clamp(value, min, max);
                inputField.text = value.ToString();
            }
            else
            {
                inputField.text = min.ToString();
            }

        }

        else
        {
            Debug.Log("null");
            inputField.text = min.ToString();
        }
    }
}
