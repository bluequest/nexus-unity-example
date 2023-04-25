using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Ping : MonoBehaviour
{
    public Button PingAttributionsButton;
    public TextMeshProUGUI outputTextField;


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
        StartCoroutine(NexusAPI_Attributions.PingAttributionsRequest((isSuccess) =>
        {
            if (isSuccess)
            {
                outputTextField.text = "Success";
            }
            else
            {
                outputTextField.text = "Fail";
            }
        }));
    }
}