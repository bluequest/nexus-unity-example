using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CoroutineTest : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(NexusAPI_Attributions.PingAttributionsRequest((isSuccess) =>
        {
            if (isSuccess)
            {
                Debug.Log("SUCESSSSSS");
            }
        }));
    }
}
