using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;

    private void Awake()
    {
        if (button == null)
        {
            button = GetComponentInChildren<Button>();
        }
        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}
