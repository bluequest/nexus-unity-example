using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public class Creator
    {
        public string id { get; set; }
        public string name { get; set; }
        public string logoImage { get; set; }
        public string nexusUrl { get; set; }
        public string profileImage { get; set; }
    }

    public class CreatorRequest
    {
        public int currentPage { get; set; }
        public int currentPageSize { get; set; }
        public List<Creator> creators { get; set; }
    }


    public class Fact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

    public string APIKey;
    public TextMeshProUGUI text;

    public void OpenMenu (GameObject Panel) {
        Panel.SetActive(true);
    }

    public void CloseMenu (GameObject Panel) {
        Panel.SetActive(false);
    }

    public void GetCatFact(TextMeshProUGUI textField) {
        text = textField;
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    }

    public void GetCreators() {
        print("asdfasfasf");
        StartCoroutine(GetCreatorsRequest("https://api.nexus.gg/v1/attributions/creators"));
    }


    IEnumerator GetRequest(String uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                    text.text = fact.fact;
                    break;
            }
        }
    }

    IEnumerator GetCreatorsRequest(String uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + "?token="+APIKey))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    print("Connection Error");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    CreatorRequest CreatorRequest = JsonConvert.DeserializeObject<CreatorRequest>(webRequest.downloadHandler.text);
                    print("Success");
                    break;
            }
        }
    }
}
