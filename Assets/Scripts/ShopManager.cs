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
    private bool[] birdPurchased; // Kuþlarýn satýn alýnýp alýnmadýðýný izlemek için


    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        birdPurchased = new bool[birds.Length];

        // Her bir kuþ için satýn alma durumunu yükle
        for (int i = 0; i < birds.Length; i++)
        {
            birdPurchased[i] = PlayerPrefs.GetInt("BirdPurchased_" + i, 0) == 1;
            birdsimg[i].SetActive(false); // Tüm kuþlarý baþlangýçta kapalý yapýyoruz.
        }

        int savedBirdIndex = PlayerPrefs.GetInt("SelectedBirdIndex", -1);
        if (savedBirdIndex != -1)
        {
            BirdChange(savedBirdIndex);
        }
        else
        {
            // Eðer herhangi bir kuþ seçilmemiþse, ilk kuþu aktif edelim
            birdsimg[0].SetActive(true);
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

    public void UpdateShopButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // Butonlar her zaman interactable ý açýk olacak, sadece satýn alýnan kuþlarýn text'ini güncelleyeceðiz.
            if (birdPurchased[i])
            {
                // Eðer kuþ zaten satýn alýndýysa, butonun text'ini "Selected" olarak güncelle
                buyButtons[i].buttonText.text = "Selected";
            }
            else if (totalCoins >= coinRequirements[i])
            {
                // Satýn alýnmamýþ ama yeterli coin varsa, fiyatýný göster
                buyButtons[i].buttonText.text = coinRequirements[i].ToString();
            }
            else
            //satýn alýnmamýþ ve yeterli coin yoksa,yine fiyatýný göster
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
