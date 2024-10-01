using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameLoginPanel : MonoBehaviour
{
    public Button saveButton;
    public TMP_InputField inputname;
    public TextMeshProUGUI infoText;
    private bool loginCompleated;

    private void OnEnable()
    {
        saveButton.onClick.AddListener(LoginButton); 
        saveButton.onClick.AddListener(()=>
        {
            if (loginCompleated)
            {
                gameObject.SetActive(false);
            }
        } );
    }

    private void Start()
    {
        
    }
    private void OnDisable()
    {
        saveButton.onClick.RemoveListener(LoginButton);
    }
    public void LoginButton()
    {
        if (inputname.text == "")
        {
            infoText.text = "Kullanýcý adý boþ olmamalý";
            loginCompleated = false;
            return;
        }
        PlayerPrefs.SetString("playerName",inputname.text);
        loginCompleated = true;
    }
}
