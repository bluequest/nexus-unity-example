using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;



public class UI_GetBountyList : MonoBehaviour
{
    public Button ActivateButton;
    public TextMeshProUGUI outputTextField;

    public GameObject InputField_GroupId;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;

    
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
        // getCreatorsParameters.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? 1 : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        // getCreatorsParameters.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? 100 : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        // getCreatorsParameters.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;

        // StartCoroutine(NexusSDK.AttributionAPI.StartGetCreatorsRequest(getCreatorsParameters, OnGetCreators200ResponseFunction));
    }
}
