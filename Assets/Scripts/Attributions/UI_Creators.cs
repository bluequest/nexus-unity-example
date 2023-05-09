using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Pool;
using TMPro;
using GetCreatorsRequestParams = NexusSDK.AttributionAPI.GetCreatorsRequestParams;
using OnGetCreators200ResponseDelegate = NexusSDK.AttributionAPI.OnGetCreators200ResponseDelegate;
using GetCreators200Response = NexusSDK.AttributionAPI.GetCreators200Response;
using Creator = NexusSDK.AttributionAPI.Creator;



public class UI_Creators : MonoBehaviour
{
    public Button GetCreatorsButton;
    public TextMeshProUGUI outputTextField;
    public GameObject InputField_Page;
    public GameObject InputField_PageSize;
    public GameObject InputField_GroupId;
    public GameObject CreatorPanelPrefab;

    GetCreatorsRequestParams getCreatorsParameters = new GetCreatorsRequestParams();

    GameObject[] SpawnedCreatorPanels;


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
        getCreatorsParameters.page = InputField_Page.GetComponent<TMP_InputField>().text == "" ? 1 : int.Parse(InputField_Page.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.pageSize = InputField_PageSize.GetComponent<TMP_InputField>().text == "" ? 100 : int.Parse(InputField_PageSize.GetComponent<TMP_InputField>().text);
        getCreatorsParameters.groupId = InputField_GroupId.GetComponent<TMP_InputField>().text;

        StartCoroutine(NexusSDK.AttributionAPI.StartGetCreatorsRequest(getCreatorsParameters, OnGetCreators200ResponseFunction));
    }

    void OnGetCreators200ResponseFunction (GetCreators200Response Response)
    {
        foreach (Creator creator in Response.creators)
        {
            // SpawnedCreatorPanels.Add(Instantiate(CreatorPanelPrefab, transform));
        }
    }


    // public class SpawnUsingPool : MonoBehaviour
    // {
    //     public GameObject objectPrefab;
    //     ObjectPool<GameObject> objectPool;
    //     void Awake()
    //     {
    //         objectPool = new ObjectPool<GameObject>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
    //     }
    //     GameObject OnObjectCreate()
    //     {
    //         GameObject newObject = Instantiate(objectPrefab);
    //         newObject.AddComponent<PoolObject>().myPool = objectPool;
    //         return newObject;
    //     }
    //     void OnTake(GameObject poolObject)
    //     {
    //         poolObject.SetActive(true);
    //     }
    //     void OnRelease(GameObject poolObject)
    //     {
    //         poolObject.SetActive(false);
    //     }
    //     void OnObjectDestroy(GameObject poolObject)
    //     {
    //         Destroy(poolObject);
    //     }
    // }
}
