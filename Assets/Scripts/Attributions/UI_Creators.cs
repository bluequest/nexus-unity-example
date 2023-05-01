using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using GetCreatorsRequestParams = NexusAPI.AttributionAPI.GetCreatorsRequestParams;
using GetCreatorsResponseCallbacks = NexusAPI.AttributionAPI.GetCreatorsResponseCallbacks;
using GetCreators200Response = NexusAPI.AttributionAPI.GetCreators200Response;



public class UI_Creators : MonoBehaviour
{
    public Button GetCreatorsButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;
    public GameObject InputField_GroupId;
    GetCreatorsRequestParams getCreatorsParameters = new GetCreatorsRequestParams();


    void OnEnable()
    {
        GetCreatorsButton.onClick.AddListener(() => HandleButtonClick());
    }
    void OnDisable()
    {
        GetCreatorsButton.onClick.RemoveAllListeners();
    }


    void HandleButtonClick()
    {
        getCreatorsParameters.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? 1 : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? 100 : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;

        StartCoroutine(NexusAPI.AttributionAPI.StartGetCreatorsRequest(getCreatorsParameters, new GetCreatorsResponseCallbacks() {OnGetCreators200Response = OnGetCreators200ResponseFunction}));
    }

    void OnGetCreators200ResponseFunction (GetCreators200Response Response)
    {
        
    }
}
