using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Pool;
using TMPro;



public class UI_ItemShop : MonoBehaviour
{
    public TextMeshProUGUI outputTextField;
    public GameObject ScrollContentPanel;

    void OnEnable()
    {
        outputTextField.text = GameObject.Find("UIController").GetComponent<UIController>().ActiveCode;

        if (GameObject.Find("UIController").GetComponent<UIController>().ActiveCode != "")
        {
            for(int i = 0; i < ScrollContentPanel.transform.childCount; i++)
            {
                GameObject itemPanel = ScrollContentPanel.transform.GetChild(i).gameObject;
                itemPanel.transform.Find("SaleSticker").gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        ScrollContentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(ScrollContentPanel.GetComponent<RectTransform>().sizeDelta.x, ScrollContentPanel.transform.childCount * 100);
    }
}
