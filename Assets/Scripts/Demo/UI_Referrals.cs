using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GetReferralInfoByPlayerIdRequestParams = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerIdRequestParams;
using GetReferralInfoByPlayerIdResponseCallbacks = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerIdResponseCallbacks;
using GetReferralInfoByPlayerId200Response = NexusSDK.ReferralsAPI.GetReferralInfoByPlayerId200Response;
using Referral = NexusSDK.ReferralsAPI.Referral;
using ReferralError = NexusSDK.ReferralsAPI.ReferralError;

using GetCreatorsRequestParams = NexusSDK.AttributionAPI.GetCreatorsRequestParams;
using GetCreators200Response = NexusSDK.AttributionAPI.GetCreators200Response;
using Creator = NexusSDK.AttributionAPI.Creator;



public class UI_Referrals : MonoBehaviour
{
    public Button CopyCodeBtn;
    public TextMeshProUGUI localUsername;
    public TextMeshProUGUI localReferralCode;


    void OnEnable()
    {
        CopyCodeBtn.onClick.AddListener(() => HandleCopyCodeButtonClick());

        GetCreatorsRequestParams requestParams = new GetCreatorsRequestParams();
        requestParams.page = 1;
        requestParams.pageSize = 99;
        requestParams.groupId = "";
        StartCoroutine(NexusSDK.AttributionAPI.StartGetCreatorsRequest(requestParams, 
            OnGetCreators200ResponseFunction, ErrorCallbackFunction));
    }
    void OnDisable()
    {
        CopyCodeBtn.onClick.RemoveAllListeners();
    }


    void OnGetCreators200ResponseFunction(GetCreators200Response Response)
    {
        print("Get Creators 200 response");
        GameObject.Find("DebugLog").GetComponent<DebugLog>().AddDebugMessage("Get Creators 200 response");

        foreach (Creator creator in Response.creators)
        {
            if (creator.name == localUsername.text)
            {
                GetReferralInfoByPlayerIdRequestParams requestParams2 = new GetReferralInfoByPlayerIdRequestParams();
                requestParams2.playerId = creator.id;
                requestParams2.groupId = "";
                requestParams2.page = 1;
                requestParams2.pageSize = 10;
                requestParams2.excludeReferralList = true;

                StartCoroutine(NexusSDK.ReferralsAPI.StartGetReferralInfoByPlayerIdRequest(requestParams2, 
                    new GetReferralInfoByPlayerIdResponseCallbacks () {OnGetReferralInfoByPlayerId200Response = OnGetReferralInfoByPlayerId200ResponseFunction, OnGetReferralInfoByPlayerId400Response = OnGetReferralInfoByPlayerId400ResponseFunction}, 
                    ErrorCallbackFunction));
            }
        }
    }


    void  OnGetReferralInfoByPlayerId200ResponseFunction(GetReferralInfoByPlayerId200Response Response)
    {
        print("Referral return 200 success");
        GameObject.Find("DebugLog").GetComponent<DebugLog>().AddDebugMessage("Get Referral Info by Player ID 200 response");
        
        localReferralCode.text = Response.referralCodes[0].code;
    }

    void OnGetReferralInfoByPlayerId400ResponseFunction (ReferralError Response)
    {
        print("Got a 400 error");
        GameObject.Find("DebugLog").GetComponent<DebugLog>().AddDebugMessage("Get Referral Info by Player ID 400 response");
    }


    void HandleCopyCodeButtonClick()
    {
        TextEditor te = new TextEditor();
        te.text = localReferralCode.text;
        te.SelectAll();
        te.Copy();
    }

    void ErrorCallbackFunction(long ErrorCode)
    {
        Debug.Log(ErrorCode);
        GameObject.Find("DebugLog").GetComponent<DebugLog>().AddDebugMessage(ErrorCode.ToString());
    }
}
