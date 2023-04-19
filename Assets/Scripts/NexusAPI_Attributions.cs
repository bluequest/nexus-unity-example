using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;

public class NexusAPI_Attributions : MonoBehaviour
{
    public string APIKey;


    public void PingAttributions() {
        StartCoroutine(GetCreatorsRequest("https://api.nexus.gg/v1/attributions/ping"));
    }
    IEnumerator PingAttributionsRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(String.Format("Connection Error: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    print(String.Format("Success"));
                    break;
            }
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

    public void GetCreators() {
        StartCoroutine(GetCreatorsRequest("https://api.nexus.gg/v1/attributions/creators"));
    }
    IEnumerator GetCreatorsRequest(String uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("x-shared-secret", APIKey);
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
                    print(webRequest.downloadHandler.text);
                    CreatorsRequest CreatorsRequest = JsonConvert.DeserializeObject<CreatorsRequest>(webRequest.downloadHandler.text);
                    break;
            }
        }
    }



    public class Group
    {
        public string name { get; set; }
        public string id { get; set; }
        public string status { get; set; }
    }
    public class CreatorByID
    {
        public List<Group> groups { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string logoImage { get; set; }
        public string nexusUrl { get; set; }
        public string profileImage { get; set; }
    }

    public void GetCreatorByID(string uuid) {
        StartCoroutine(GetCreatorByIDRequest("https://api.nexus.gg/v1/attributions/creators/", uuid));
    }
    IEnumerator GetCreatorByIDRequest(string uri, string uuid)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + uuid))
        {
            webRequest.SetRequestHeader("x-shared-secret", APIKey);
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
                    print(webRequest.downloadHandler.text);
                    CreatorByID CreatorByID = JsonConvert.DeserializeObject<CreatorByID>(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
