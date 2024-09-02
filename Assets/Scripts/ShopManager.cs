using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] birds;
    public GameObject[] birdsimg;
    public Button[] buttons;
    public BuyButton[] buyButtons;
    public int[] coinRequirements;
    public TMP_Text goldtxt;
    public int totalCoins = 0;
    public Button startButton;
    private bool[] birdPurchased; // Ku�lar�n sat�n al�n�p al�nmad���n� izlemek i�in


    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        birdPurchased = new bool[birds.Length];

        // Her bir ku� i�in sat�n alma durumunu y�kle
        for (int i = 0; i < birds.Length; i++)
        {
            birdPurchased[i] = PlayerPrefs.GetInt("BirdPurchased_" + i, 0) == 1;
            birdsimg[i].SetActive(false); // T�m ku�lar� ba�lang��ta kapal� yap�yoruz.
        }

        int savedBirdIndex = PlayerPrefs.GetInt("SelectedBirdIndex", -1);
        if (savedBirdIndex != -1)
        {
            BirdChange(savedBirdIndex);
        }
        else
        {
            // E�er herhangi bir ku� se�ilmemi�se, ilk ku�u aktif edelim
            birdsimg[0].SetActive(true);
        }

        startButton.interactable = savedBirdIndex != -1;

        UpdateShopButtons();
        UpdateGoldText();  // Gold miktar�n� ba�lang��ta g�ster
    }

    public void CollectCoin(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        UpdateGoldText();  // Coin topland���nda g�ncelle
    }

    public void UpdateShopButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // Butonlar her zaman interactable � a��k olacak, sadece sat�n al�nan ku�lar�n text'ini g�ncelleyece�iz.
            if (birdPurchased[i])
            {
                // E�er ku� zaten sat�n al�nd�ysa, butonun text'ini "Selected" olarak g�ncelle
                buyButtons[i].buttonText.text = "Selected";
            }
            else if (totalCoins >= coinRequirements[i])
            {
                // Sat�n al�nmam�� ama yeterli coin varsa, fiyat�n� g�ster
                buyButtons[i].buttonText.text = coinRequirements[i].ToString();
            }
            else
            //sat�n al�nmam�� ve yeterli coin yoksa,yine fiyat�n� g�ster
            {
                buyButtons[i].buttonText.text = coinRequirements[i].ToString();
            }
        }
    }

    public void BirdChange(int birdIndex)
    {
        if (birdIndex >= 0 && birdIndex < birdsimg.Length)
        {
            if (birdPurchased[birdIndex] || totalCoins >= coinRequirements[birdIndex])
            {
                if (!birdPurchased[birdIndex])
                {
                    // E�er ku� daha �nce sat�n al�nmam��sa, coinden d�� ve sat�n al�nm�� olarak i�aretle
                    totalCoins -= coinRequirements[birdIndex];
                    PlayerPrefs.SetInt("TotalCoins", totalCoins);
                    birdPurchased[birdIndex] = true;
                    PlayerPrefs.SetInt("BirdPurchased_" + birdIndex, 1);  // Sat�n al�nm�� olarak kaydet
                }
                // Gold text'ini g�ncelle
                UpdateGoldText();

                // T�m ku�lar� devre d��� b�rak ve se�ilen ku�u aktif et
                for (int i = 0; i < birdsimg.Length; i++)
                {
                    birdsimg[i].SetActive(false);
                }
                birdsimg[birdIndex].SetActive(true);

                // Se�ilen ku�un text'ini "Selected" olarak g�ncelle
                buyButtons[birdIndex].buttonText.text = "Selected";
                PlayerPrefs.SetInt("SelectedBirdIndex", birdIndex);
                startButton.interactable = true;
            }
            else
            {
                Debug.Log("Yetersiz coin! Bu ku�u se�mek i�in yeterli coininiz yok.");
            }
        }
    }
    private void UpdateGoldText()
    {
        goldtxt.text = totalCoins.ToString();
    }
}
