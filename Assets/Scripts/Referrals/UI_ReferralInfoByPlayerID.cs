using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
// using GetReferralInfoByPlayerIdRequestParams = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerIdRequestParams;
// using GetReferralInfoByPlayerIdResponseCallbacks = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerIdResponseCallbacks;
// using GetReferralInfoByPlayerId200Response = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerId200Response;
// using ReferralError = NexusSDK.ReferralsAPI.ReferralError;



public class UI_ReferralInfoByPlayerID : MonoBehaviour
{
    // public Button ActivateButton;
    // public TextMeshProUGUI outputTextField;
    // public GameObject InputField_PlayerId;
    // public GameObject InputField_GroupId;
    // public GameObject InputField_Page;
    // public GameObject InputField_PageSize;
    // public Button ExcludReferralListButton;

    // GetReferralInfoByPlayerIdRequestParams requestParams = new GetReferralInfoByPlayerIdRequestParams();


    // void OnEnable()
    // {
    //     ActivateButton.onClick.AddListener(() => HandleButtonClick());
    // }
    // void OnDisable()
    // {
    //     ActivateButton.onClick.RemoveAllListeners();
    // }

    // void HandleButtonClick()
    // {
    //     requestParams.playerId = InputField_PlayerId.GetComponent<TMP_InputField>().text;
    //     requestParams.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;
    //     requestParams.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? 1 : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
    //     requestParams.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? 100 : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
    //     requestParams.excludeReferralList = ExcludReferralListButton.IsActive();

    //     StartCoroutine(NexusSDK.ReferralsAPI.StartGetReferralInfoByPlayerIdRequest(requestParams, 
    //         new GetReferralInfoByPlayerIdResponseCallbacks () {OnGetReferralInfoByPlayerId200Response = OnGetReferralInfoByPlayerId200ResponseFunction, OnGetReferralInfoByPlayerId400Response = OnGetReferralInfoByPlayerId400ResponseFunction}));
    // }
    // void OnGetReferralInfoByPlayerId200ResponseFunction (GetReferralInfoByPlayerId200Response Param0)
    // {

    // }

    // void OnGetReferralInfoByPlayerId400ResponseFunction (ReferralError Param0)
    // {

    // }
}
