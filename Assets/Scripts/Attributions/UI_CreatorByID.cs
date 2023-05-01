using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using CreatorById = NexusAPI.Attributions.CreatorById;
using CreatorByIdParameters = NexusAPI.Attributions.CreatorByIdParameters;



public class UI_CreatorByID : MonoBehaviour
{
    public Button GetCreatorByIdButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_CreatorSlugOrId;
    CreatorById CreatorByIdResponse;
    CreatorByIdParameters getCreatorByIdParameters = new CreatorByIdParameters("");


    void OnEnable()
    {
        GetCreatorByIdButton.onClick.AddListener(() => HandleButtonClick());
    }
    void OnDisable()
    {
        GetCreatorByIdButton.onClick.RemoveAllListeners();
    }


    void HandleButtonClick()
    {
        getCreatorByIdParameters.creatorSlugOrId = InputField_CreatorSlugOrId.GetComponent<TMP_InputField>().text;

        StartCoroutine(NexusAPI.Attributions.GetCreatorByIdRequest(getCreatorByIdParameters, (Result, CreatorByIdResponse) =>
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
