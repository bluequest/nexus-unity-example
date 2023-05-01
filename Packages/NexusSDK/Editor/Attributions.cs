using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


namespace NexusAPI {
    public static class Attributions
    {
        // public struct OnPingAttributions200Response
        // {
        //     OnPingAttributions200RepsonseDelegate OnPingAttributions200Response { get; set; }
        // };
        // delegate void OnPingAttributions200ResponseDelegate();

        // public struct PingAttributionsResponseCallbacks
        // {
        //     OnPingAttributions200RepsonseDelegate OnPingAttributions200Response { get; set; }
        // }

        // public static IEnumerator PingAttributionsRequest(System.Action<PingAttributionsResponseCallbacks> Callback)
        // {
        //     string uri = "https://api.nexus.gg/v1/attributions/ping";

        //     using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        //     {
        //         yield return webRequest.SendWebRequest();

        //         switch (webRequest.result)
        //         {
        //             case UnityWebRequest.Result.ConnectionError:
        //                 Callback({});
        //                 break;
        //             case UnityWebRequest.Result.Success:
        //                 Callback({});
        //                 break;
        //         }
        //     }
        // }


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

        public static IEnumerator GetCreatorsRequest(GetCreatorsParameters parameters, System.Action<UnityWebRequest.Result, CreatorsRequest> Callback)
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

                Callback(webRequest.result, JsonConvert.DeserializeObject<CreatorsRequest>(webRequest.downloadHandler.text));
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

        public static IEnumerator GetCreatorByIdRequest(CreatorByIdParameters parameters, System.Action<UnityWebRequest.Result, CreatorById> Callback)
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

                Callback(webRequest.result, JsonConvert.DeserializeObject<CreatorById>(webRequest.downloadHandler.text));
            }
        }
    }
}
