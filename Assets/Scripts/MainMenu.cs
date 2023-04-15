using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public class Fact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

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

    public void RandomFunction() {

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
}
