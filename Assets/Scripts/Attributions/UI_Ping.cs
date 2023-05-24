using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UI_Ping : MonoBehaviour
{
    public Button ActivateButton;
    public TextMeshProUGUI outputTextField;


    void OnEnable()
    {
        ActivateButton.onClick.AddListener(() => HandleButtonClick());
    }
    void OnDisable()
    {
        ActivateButton.onClick.RemoveAllListeners();
    }

    void HandleButtonClick()
    {
        StartCoroutine(NexusSDK.AttributionAPI.StartGetPingRequest(OnGetPingResponse, ErrorCallbackFunction));
    }

    void OnGetPingResponse()
    {
       outputTextField.text = "Ping Success";
    }

    void ErrorCallbackFunction(long ErrorCode)
    {
        Debug.Log(ErrorCode);
    }
}