using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Button birdButton;
    public TextMeshProUGUI buttonText;

    private void Awake()
    {
        if (birdButton == null)
        {
            birdButton = GetComponentInChildren<Button>();
        }
        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}