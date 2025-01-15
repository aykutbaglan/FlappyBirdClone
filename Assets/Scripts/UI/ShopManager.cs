using Game.UI;
using TMPro;
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
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private StartState startState;
    private bool[] _birdPurchased;
    
    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        _birdPurchased = new bool[birds.Length];

        for (int i = 0; i < birds.Length; i++)
        {
            _birdPurchased[i] = PlayerPrefs.GetInt("BirdPurchased_" + i, 0) == 1;
        }
        int savedBirdIndex = PlayerPrefs.GetInt("SelectedBirdIndex", -1);
        if (savedBirdIndex != -1)
        {
            BirdChange(savedBirdIndex);
            for (int i = 0; i < birdsimg.Length; i++)
            {
                birdsimg[i].SetActive(false);
            }
            birdsimg[savedBirdIndex].SetActive(true);
        }
        else
        {
            startState.startButton.interactable = false;
        }
        UpdateShopButtons();
        UpdateGoldText();
    }

    public void CollectCoin(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        UpdateGoldText();
        UpdateShopButtons();
    }
    public void UpdateShopButtons()
    {
        buttons[0].interactable = true;
        buyButtons[0].buttonText.text = _birdPurchased[0] ? "Selected" : "Free";

        for (int i = 1; i < buttons.Length; i++)
        {
            if (_birdPurchased[i])
            {
                buttons[i].interactable = true;
                buyButtons[i].buttonText.text = "Selected";
            }
            else if (totalCoins >= coinRequirements[i])
            {
                buttons[i].interactable = true;
                buyButtons[i].buttonText.text = coinRequirements[i].ToString();
            }
            else
            {
                buttons[i].interactable = false;
                buyButtons[i].buttonText.text = coinRequirements[i].ToString();
            }
        }
    }
    public void BirdChange(int birdIndex)
    {
        if (birdIndex >= 0 && birdIndex < birdsimg.Length)
        {
            if (_birdPurchased[birdIndex] || totalCoins >= coinRequirements[birdIndex])
            {
                if (!_birdPurchased[birdIndex])
                {
                    totalCoins -= coinRequirements[birdIndex];
                    PlayerPrefs.SetInt("TotalCoins", totalCoins);
                    _birdPurchased[birdIndex] = true;
                    PlayerPrefs.SetInt("BirdPurchased_" + birdIndex, 1);
                }
                UpdateGoldText();
                for (int i = 0; i < birdsimg.Length; i++)
                {
                    birdsimg[i].SetActive(false);
                }
                birdsimg[birdIndex].SetActive(true);
                buyButtons[birdIndex].buttonText.text = "Selected";
                PlayerPrefs.SetInt("SelectedBirdIndex", birdIndex);
                startState.startButton.interactable = true;
                UpdateShopButtons();
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (!_birdPurchased[birdIndex])
                    {
                        buttons[i].interactable = false;
                    }
                    if (_birdPurchased[birdIndex])
                    {
                        buttons[i].interactable = true;
                    }
                }
            }
        }
    }
    public void UpdateGoldText()
    {
        goldtxt.text = totalCoins.ToString();
    }
}