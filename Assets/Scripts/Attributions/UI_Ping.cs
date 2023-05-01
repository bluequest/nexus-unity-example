using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using PingAttributionsResponseCallbacks = NexusAPI.Attributions.PingAttributionsResponseCallbacks;



public class UI_Ping : MonoBehaviour
{
    public Button PingAttributionsButton;
    public TextMeshProUGUI outputTextField;
    // public PingAttributionsResponseCallbacks responseCallbacks;



    void OnEnable()
    {
        PingAttributionsButton.onClick.AddListener(() => HandleButtonClick());
    }
    void OnDisable()
    {
        PingAttributionsButton.onClick.RemoveAllListeners();
    }

    void HandleButtonClick()
    {
        // StartCoroutine(NexusAPI.Attributions.PingAttributionsRequest((responseCallbacks) =>
        // {
            
        //     // if (responseCallbacks)
        //     // {
        //     //     outputTextField.text = "Success";
        //     // }
        //     // else
        //     // {
        //     //     outputTextField.text = "Fail";
        //     // }
        // }));
    }


}