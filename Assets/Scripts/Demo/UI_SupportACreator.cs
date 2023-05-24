using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Pool;
using TMPro;
using GetCreatorsRequestParams = NexusSDK.AttributionAPI.GetCreatorsRequestParams;
using GetCreators200Response = NexusSDK.AttributionAPI.GetCreators200Response;
using Creator = NexusSDK.AttributionAPI.Creator;



public class UI_SupportACreator : MonoBehaviour
{
    public Button EnterCodeButton;
    public GameObject InputField_Code;
    public GameObject txtCurrentCreatorCodeObject;
    public TextMeshProUGUI txtCurrentCreatorCode;
    public GameObject txtSetCreatorCodeObject;
    public TextMeshProUGUI txtSetCreatorCode;
    bool codeIsValid = false;


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
        GetCreatorsRequestParams requestParams = new GetCreatorsRequestParams();
        requestParams.page = 1;
        requestParams.pageSize = 99;
        requestParams.groupId = "";
        StartCoroutine(NexusSDK.AttributionAPI.StartGetCreatorsRequest(requestParams, 
            OnGetCreators200ResponseFunction));
    }

    void OnGetCreators200ResponseFunction(GetCreators200Response Response)
    {
        print("Get Creators 200 response");
        codeIsValid = false;

        foreach (Creator creator in Response.creators)
        {
            if (creator.name == InputField_Code.GetComponent<TMP_InputField>().text)
            {
                codeIsValid = true;
            }
        }

        if (codeIsValid)
        {
            GameObject.Find("UIController").GetComponent<UIController>().ActiveCode = InputField_Code.GetComponent<TMP_InputField>().text;
            txtCurrentCreatorCodeObject.SetActive(true);
            txtSetCreatorCodeObject.SetActive(true);
            txtSetCreatorCode.text = GameObject.Find("UIController").GetComponent<UIController>().ActiveCode;
        }
    }
}
