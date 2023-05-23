using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using GetReferralInfoByCodeRequestParams = NexusSDK.ReferralsAPI.GetReferralInfoByCodeRequestParams;
using GetReferralInfoByCodeResponseCallbacks = NexusSDK.ReferralsAPI.GetReferralInfoByCodeResponseCallbacks;
using GetReferralInfoByCode200Response = NexusSDK.ReferralsAPI.GetReferralInfoByCode200Response;
using ReferralError = NexusSDK.ReferralsAPI.ReferralError;



public class UI_ReferralInfoByCode : MonoBehaviour
{
    public Button ActivateButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_Code;
    public GameObject InputField_GroupId;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;
    public Button ExcludReferralListButton;
    GetReferralInfoByCodeRequestParams requestParams = new GetReferralInfoByCodeRequestParams();

    

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
        requestParams.code = InputField_Code.GetComponent<TMP_InputField>().text;
        requestParams.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;
        requestParams.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? 1 : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        requestParams.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? 100 : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        requestParams.excludeReferralList = ExcludReferralListButton.IsActive();

        StartCoroutine(NexusSDK.ReferralsAPI.StartGetReferralInfoByCodeRequest(requestParams, 
            new GetReferralInfoByCodeResponseCallbacks () {OnGetReferralInfoByCode200Response = OnGetReferralInfoByCode200ResponseFunction, OnGetReferralInfoByCode400Response = OnGetReferralInfoByCode400ResponseFunction}));
    }

    void OnGetReferralInfoByCode200ResponseFunction (GetReferralInfoByCode200Response Param0)
    {

    }

    void OnGetReferralInfoByCode400ResponseFunction (ReferralError Param0)
    {

    }
}
