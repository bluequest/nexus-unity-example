using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Pool;
using TMPro;



public class UI_SupportACreator : MonoBehaviour
{
    public Button EnterCodeButton;
    public GameObject InputField_Code;
    public GameObject txtCurrentCreatorCodeObject;
    public TextMeshProUGUI txtCurrentCreatorCode;
    public GameObject txtSetCreatorCodeObject;
    public TextMeshProUGUI txtSetCreatorCode;


    void OnEnable()
    {
        EnterCodeButton.onClick.AddListener(() => HandleButtonClick());

        if (GameObject.Find("UIController").GetComponent<UIController>().ActiveCode == "")
        {
            txtCurrentCreatorCodeObject.SetActive(false);
            txtSetCreatorCodeObject.SetActive(false);
        }
        else
        {
            txtCurrentCreatorCodeObject.SetActive(true);
            txtSetCreatorCodeObject.SetActive(true);
            
        }
    }
    void OnDisable()
    {
        EnterCodeButton.onClick.RemoveAllListeners();
    }


    void HandleButtonClick()
    {
        GameObject.Find("UIController").GetComponent<UIController>().ActiveCode = InputField_Code.GetComponent<TMP_InputField>().text;

        txtCurrentCreatorCodeObject.SetActive(true);
        txtSetCreatorCodeObject.SetActive(true);
        txtSetCreatorCode.text = GameObject.Find("UIController").GetComponent<UIController>().ActiveCode;
    }
}
