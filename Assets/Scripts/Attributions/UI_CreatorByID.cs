using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using GetCreatorByUuidRequestParams = NexusSDK.AttributionAPI.GetCreatorByUuidRequestParams;
using GetCreatorByUuid200Response = NexusSDK.AttributionAPI.GetCreatorByUuid200Response;



public class UI_CreatorByID : MonoBehaviour
{
    public Button ActivateButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_CreatorSlugOrId;
    GetCreatorByUuidRequestParams getCreatorByIdParameters = new GetCreatorByUuidRequestParams();


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
        getCreatorByIdParameters.creatorSlugOrId = InputField_CreatorSlugOrId.GetComponent<TMP_InputField>().text;

        StartCoroutine(NexusSDK.AttributionAPI.StartGetCreatorByUuidRequest(getCreatorByIdParameters, GetCreatorByUuid200ResponseFunction));
    }

    void GetCreatorByUuid200ResponseFunction(GetCreatorByUuid200Response Response)
    {
        print("success");
    }
}
