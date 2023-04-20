using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;



public class NexusAPI_Attributions : MonoBehaviour
{
    public Button PingAttributionsButton;
    public Button GetCreatorsButton;
    public Button GetCreatorByIdButton;


    void OnEnable()
    {
        //Register Button Events
        PingAttributionsButton.onClick.AddListener(() => PingAttributions());

        GetCreatorsParameters getCreatorsParameters = new GetCreatorsParameters(1, 100, "");
        GetCreatorsButton.onClick.AddListener(() => GetCreators(getCreatorsParameters));

        CreatorByIdParameters getCreatorByIdParameters = new CreatorByIdParameters("dusty");
        GetCreatorByIdButton.onClick.AddListener(() => GetCreatorById(getCreatorByIdParameters));
    }
    void OnDisable()
    {
        //Un-Register Button Events
        PingAttributionsButton.onClick.RemoveAllListeners();
        GetCreatorsButton.onClick.RemoveAllListeners();
        GetCreatorByIdButton.onClick.RemoveAllListeners();
    }

    public TextMeshProUGUI outputTextPing;

    public void PingAttributions() {
        StartCoroutine(PingAttributionsRequest());
    }
    IEnumerator PingAttributionsRequest()
    {
        string uri = "https://api.nexus.gg/v1/attributions/ping";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(String.Format("Connection Error: {0}", webRequest.error));
                    outputTextPing.text = String.Format("Connection Error: {0}", webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    print(String.Format("Success"));
                    outputTextPing.text = "Success";
                    break;
            }
        }
    }



    public struct GetCreatorsParameters
    {
        public Nullable<int> page { get; set; }
        public Nullable<int> pageSize { get; set; }
        public string groupId { get; set; }

        public GetCreatorsParameters(int Page, int PageSize, string GroupId)
        {
            page = Page;
            pageSize = PageSize;
            groupId = GroupId;
        }
    }
    public class Creator
    {
        public string id { get; set; }
        public string name { get; set; }
        public string logoImage { get; set; }
        public string nexusUrl { get; set; }
        public string profileImage { get; set; }
    }
    public class CreatorsRequest
    {
        public int currentPage { get; set; }
        public int currentPageSize { get; set; }
        public List<Creator> creators { get; set; }
    }

    public TextMeshProUGUI outputTextGetCreators;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;
    public GameObject InputField_GroupId;

    public void GetCreators(GetCreatorsParameters parameters) {
        parameters.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? null : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        parameters.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? null : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        parameters.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;

        StartCoroutine(GetCreatorsRequest(parameters));
    }
    IEnumerator GetCreatorsRequest(GetCreatorsParameters parameters)
    {
        string uri = "https://api.nexus.gg/v1/attributions/creators";


        if (parameters.page != null)
        {
            uri = uri + "?page=" + parameters.page;
        }
        if (parameters.pageSize != null)
        {
            uri = uri.Contains("?") ? uri + "&" : uri + "?";
            uri = uri + "pageSize=" + parameters.pageSize;
        }
        if (parameters.groupId != "")
        {
            uri = uri.Contains("?") ? uri + "&" : uri + "?";
            uri = uri + parameters.groupId;
        }

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("x-shared-secret", APIKeyContainer.APIKey);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(String.Format("Connection Error: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Data Processing Error: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    print(String.Format("Success: {0}", webRequest.error));
                    CreatorsRequest creatorsRequest = JsonConvert.DeserializeObject<CreatorsRequest>(webRequest.downloadHandler.text);
                    outputTextGetCreators.text = webRequest.downloadHandler.text;
                    break;
            }
        }
    }



    public struct CreatorByIdParameters
    {
        public string creatorSlugOrId { get; set; } 

        public CreatorByIdParameters(string CreatorSlugOrId)
        {
            creatorSlugOrId = CreatorSlugOrId;
        }
    }
    public class Group
    {
        public string name { get; set; } 
        public string id { get; set; }
        public string status { get; set; }
    }
    public class CreatorById
    {
        public List<Group> groups { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string logoImage { get; set; }
        public string nexusUrl { get; set; }
        public string profileImage { get; set; }
    }

    public TextMeshProUGUI outputTextGetCreatorById;
    public GameObject InputField_CreatorSlugOrId;

    public void GetCreatorById(CreatorByIdParameters parameters) {
        parameters.creatorSlugOrId = InputField_CreatorSlugOrId.GetComponent<TMP_InputField>().text;
        StartCoroutine(GetCreatorByIdRequest(parameters));
    }
    IEnumerator GetCreatorByIdRequest(CreatorByIdParameters parameters)
    {
        string uri = "https://api.nexus.gg/v1/attributions/creators/";

        if (parameters.creatorSlugOrId != "")
        {
            uri = uri + "?creatorSlugOrId=" + parameters.creatorSlugOrId;
        }

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("x-shared-secret", APIKeyContainer.APIKey);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(String.Format("Connection Error: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Data Processing Error: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    print(String.Format("Success: {0}", webRequest.error));
                    CreatorById CreatorByID = JsonConvert.DeserializeObject<CreatorById>(webRequest.downloadHandler.text);
                    outputTextGetCreatorById.text = webRequest.downloadHandler.text;
                    break;
            }
        }
    }
}
