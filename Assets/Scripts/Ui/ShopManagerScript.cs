using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] ShopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;


    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();

        //id
        ShopItems[1, 1] = 1;
        ShopItems[1, 2] = 2;
        ShopItems[1, 3] = 3;
        ShopItems[1, 4] = 4;
        ShopItems[1, 5] = 5;

        //price
        ShopItems[2, 1] = 10;
        ShopItems[2, 2] = 20;
        ShopItems[2, 3] = 30;
        ShopItems[2, 4] = 40;
        ShopItems[2, 5] = 50;

        //quantity
        ShopItems[3, 1] = 0;
        ShopItems[3, 2] = 0;
        ShopItems[3, 3] = 0;
        ShopItems[3, 4] = 0;
        ShopItems[3, 5] = 0;
    }


    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= ShopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= ShopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            ShopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = ShopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();


        }
    }
}
