using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] ShopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;


    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();

    }

    
    void Update()
    {
        
    }
}
