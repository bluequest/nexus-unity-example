using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DebugLog : MonoBehaviour
{
    public static DebugLog Singleton;
    public bool DebugLogActive = false;
    public GameObject ContentPanel;
    public Transform ScrollContentPanel;
    public GameObject DebugMessagePrefab;
    List<GameObject> SpawnedDebugMessages = new List<GameObject>{};

    void Awake()
    {
        NexusSDK.AttributionAPI.TestLog.AddListener(AddDebugMessage);
        Singleton = this;
    }

    public void AddDebugMessage(string message)
    {
        if (DebugLogActive)
        {
            GameObject spawnedDebugMessage = Instantiate(DebugMessagePrefab, transform);
            spawnedDebugMessage.transform.SetParent(ScrollContentPanel);
            spawnedDebugMessage.GetComponent<TextMeshProUGUI>().text = message;
            SpawnedDebugMessages.Add(spawnedDebugMessage);
            StartCoroutine(MessageTimer(spawnedDebugMessage, 10));

            ContentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(100, SpawnedDebugMessages.Count * 20);
        }
    }

    IEnumerator MessageTimer(GameObject spawnedMessage, float messageTime)
    {
        yield return new WaitForSeconds(messageTime);

        GameObject.Destroy(spawnedMessage);
        SpawnedDebugMessages.Remove(spawnedMessage);
        ContentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(100, SpawnedDebugMessages.Count * 20);
    }
}
