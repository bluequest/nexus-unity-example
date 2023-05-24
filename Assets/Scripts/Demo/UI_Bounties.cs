using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Pool;
using TMPro;

using GetBountiesRequestParams = NexusSDK.BountyAPI.GetBountiesRequestParams;
using GetBountiesResponseCallbacks = NexusSDK.BountyAPI.GetBountiesResponseCallbacks;
using GetBounties200Response = NexusSDK.BountyAPI.GetBounties200Response;
using GetCreatorBountiesByIDRequestParams = NexusSDK.BountyAPI.GetCreatorBountiesByIDRequestParams;
using GetCreatorBountiesByIDResponseCallbacks = NexusSDK.BountyAPI.GetCreatorBountiesByIDResponseCallbacks;
using GetCreatorBountiesByID200Response = NexusSDK.BountyAPI.GetCreatorBountiesByID200Response;
using Bounty = NexusSDK.BountyAPI.Bounty;
using BountyError = NexusSDK.BountyAPI.BountyError;



public class UI_Bounties : MonoBehaviour
{
    public GameObject BountyPanelPrefab;
    List<GameObject> SpawnedBountyPanels = new List<GameObject>{};
    public GameObject ContentPanel;
    public Transform ScrollContentPanel;

    void OnEnable()
    {
        RefreshBounties();
    }
    void OnDisable()
    {
        foreach (Transform child in ScrollContentPanel)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void RefreshBounties()
    {
        GetBountiesRequestParams requestParams = new GetBountiesRequestParams();
        requestParams.groupId = "";
        requestParams.page = 1;
        requestParams.pageSize = 100;

        StartCoroutine(NexusSDK.BountyAPI.StartGetBountiesRequest(requestParams, 
            new GetBountiesResponseCallbacks () {OnGetBounties200Response = OnGetBounties200ResponseFunction, OnGetBounties400Response = OnGetBounties400ResponseFunction},
            ErrorCallbackFunction));
    }

    void OnGetBounties200ResponseFunction(GetBounties200Response Response)
    {
        print("Bounties return 200 success");
        ContentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(100, Response.bounties.Length * 100);

        foreach (Bounty bounty in Response.bounties)
        {
            GameObject spawnedBountyPanel = Instantiate(BountyPanelPrefab, transform);
            spawnedBountyPanel.transform.SetParent(ScrollContentPanel);
            spawnedBountyPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = bounty.name;
            spawnedBountyPanel.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = bounty.objectives[0].name;
            StartCoroutine(spawnedBountyPanel.GetComponent<BountyPanel>().LoadIconImage(bounty.imageSrc));
            SpawnedBountyPanels.Add(spawnedBountyPanel);
        }
    }

    void OnGetBounties400ResponseFunction (BountyError Response)
    {
        print("Got a 400 error");
    }

    void ErrorCallbackFunction(long ErrorCode)
    {
        Debug.Log(ErrorCode);
    }
}
