using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop_Item : MonoBehaviour
{
    public Button purchaseButton;


    void OnEnable()
    {
        purchaseButton.onClick.AddListener(() => HandleButtonClick());
    }
    void OnDisable()
    {
        purchaseButton.onClick.RemoveAllListeners();
    }


    void HandleButtonClick()
    {
        Destroy(this.gameObject);
    }
}
