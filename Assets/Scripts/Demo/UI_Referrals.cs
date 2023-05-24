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



public class UI_Referrals : MonoBehaviour
{
    public Button CopyCodeBtn;
    public TextMeshProUGUI localUsername;
    public TextMeshProUGUI localReferralCode;


    void OnEnable()
    {
        CopyCodeBtn.onClick.AddListener(() => HandleCopyCodeButtonClick());

        GetReferralInfoByPlayerIdRequestParams requestParams = new GetReferralInfoByPlayerIdRequestParams();
        requestParams.playerId = "0Con-WN07cuBMdEkr56oo";
        requestParams.groupId = "";
        requestParams.page = 1;
        requestParams.pageSize = 10;
        requestParams.excludeReferralList = true;

        StartCoroutine(NexusSDK.ReferralsAPI.StartGetReferralInfoByPlayerIdRequest(requestParams, 
            new GetReferralInfoByPlayerIdResponseCallbacks () {OnGetReferralInfoByPlayerId200Response = OnGetReferralInfoByPlayerId200ResponseFunction, OnGetReferralInfoByPlayerId400Response = OnGetReferralInfoByPlayerId400ResponseFunction}, 
            ErrorCallbackFunction));
    }
    void OnDisable()
    {
        CopyCodeBtn.onClick.RemoveAllListeners();
    }


    void  OnGetReferralInfoByPlayerId200ResponseFunction(GetReferralInfoByPlayerId200Response Response)
    {
        print("Referral return 200 success");
        
        localReferralCode.text = Response.referralCodes[0].code;
    }

    void OnGetReferralInfoByPlayerId400ResponseFunction (ReferralError Response)
    {
        print("Got a 400 error");
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
    }
}
