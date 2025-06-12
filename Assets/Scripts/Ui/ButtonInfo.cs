using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;



    void Start()
    {
        PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().ShopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().ShopItems[3, ItemID].ToString();

    }
}
