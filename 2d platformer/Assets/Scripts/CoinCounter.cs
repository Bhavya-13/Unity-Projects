using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public static int coinAmount;
    public static int coinsCount;

    public static CoinCounter Instance;

    [SerializeField] private GameObject floatingText;
    
    void Awake(){
        Instance = this;
    }

    void Start()
    {
        coinsCount = PlayerPrefs.GetInt("Coins");
        CoinText.text = coinsCount.ToString();
    }

    public void Reset(){
        PlayerPrefs.DeleteAll();
    }

    public void AddMoney(int moneyToAdd, Vector3 coinPos){
        coinsCount += moneyToAdd;
        CoinText.text = coinsCount.ToString();
        GameObject prefab = Instantiate(floatingText, coinPos, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = moneyToAdd.ToString();
    }
}
