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
    public Button pressedButton;
    private bool[] birdPurchased; // Kuþlarýn satýn alýnýp alýnmadýðýný izlemek için



    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        birdPurchased = new bool[birds.Length];

        // Her bir kuþ için satýn alma durumunu yükle
        for (int i = 0; i < birds.Length; i++)
        {
            birdPurchased[i] = PlayerPrefs.GetInt("BirdPurchased_" + i, 0) == 1;
        }
        int savedBirdIndex = PlayerPrefs.GetInt("SelectedBirdIndex", -1);
        if (savedBirdIndex != -1)
        {
            BirdChange(savedBirdIndex);
        }
        startButton.interactable = savedBirdIndex != -1;

        UpdateShopButtons();
        UpdateGoldText();  // Gold miktarýný baþlangýçta göster
    }

    public void CollectCoin(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        UpdateGoldText();  // Coin toplandýðýnda güncelle
    }

    private void UpdateShopButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // Butonlar her zaman interactable ý açýk olacak, sadece satýn alýnan kuþlarýn text'ini güncelleyeceðiz.
            if (birdPurchased[i])
            {
                // Eðer kuþ zaten satýn alýndýysa, butonun text'ini "Selected" olarak güncelle
                buyButtons[i].buttonText.text = "Selected";
            }
            if (totalCoins >= coinRequirements[1])
            {
                // Satýn alýnmamýþ ama yeterli coin varsa, fiyatýný göster
                buyButtons[1].buttonText.text = "25";
                Debug.Log("25");

            }
            if (totalCoins >= coinRequirements[2])
            {
                // Satýn alýnmamýþ ve yeterli coin yoksa, gerekli coin miktarýný göster
                buyButtons[i].buttonText.text = "50 " + coinRequirements[i] + " Coins";
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
                    // Eðer kuþ daha önce satýn alýnmamýþsa, coinden düþ ve satýn alýnmýþ olarak iþaretle
                    totalCoins -= coinRequirements[birdIndex];
                    PlayerPrefs.SetInt("TotalCoins", totalCoins);
                    birdPurchased[birdIndex] = true;
                    PlayerPrefs.SetInt("BirdPurchased_" + birdIndex, 1);  // Satýn alýnmýþ olarak kaydet
                }

                // Gold text'ini güncelle
                UpdateGoldText();

                // Tüm kuþlarý devre dýþý býrak ve seçilen kuþu aktif et
                for (int i = 0; i < birdsimg.Length; i++)
                {
                    birdsimg[i].SetActive(false);
                }
                birdsimg[birdIndex].SetActive(true);

                // Seçilen kuþun text'ini "Selected" olarak güncelle
                buyButtons[birdIndex].buttonText.text = "Selected";
                PlayerPrefs.SetInt("SelectedBirdIndex", birdIndex);
                startButton.interactable = true;
            }
            else
            {
                Debug.Log("Yetersiz coin! Bu kuþu seçmek için yeterli coininiz yok.");
            }
        }
    }

    private void UpdateGoldText()
    {
        goldtxt.text = totalCoins.ToString();
    }
}
