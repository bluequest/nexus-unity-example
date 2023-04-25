using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using CreatorsRequest = NexusAPI_Attributions.CreatorsRequest;
using GetCreatorsParameters = NexusAPI_Attributions.GetCreatorsParameters;



public class UI_Creators : MonoBehaviour
{
    public Button GetCreatorsButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;
    public GameObject InputField_GroupId;
    CreatorsRequest CreatorsRequestResponse;
    GetCreatorsParameters getCreatorsParameters = new GetCreatorsParameters(1, 100, "");


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
        getCreatorsParameters.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? null : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? null : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;

        StartCoroutine(NexusAPI_Attributions.GetCreatorsRequest(getCreatorsParameters, (Result, CreatorsRequestResponse) =>
        {
            switch (Result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(String.Format("Connection Error: {0}", Result));
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Data Processing Error: {0}", Result));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(String.Format("Success"));
                    outputTextField.text = "Success";
                    break;
            }
        }));
    }
}
