//Example SDK For Nexus SDK Generator
/*  NOTE NOTE NOTE
*   GENERATED CODE
*   ANY CHANGES TO THIS FILE WILL BE OVERWRITTEN
*	PLEASE MAKE ANY CHANGES TO THE SDK TEMPLATES IN THE SDK GENERATOR
*/
//Schema Types
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;



namespace NexusAPI
{

    public struct Creator
    {
            public string id { get; set; }
            public string name { get; set; }
            public string logoImage { get; set; }
            public string nexusUrl { get; set; }
            public string profileImage { get; set; }
    }

    public struct CreatorGroup
    {
            public string name { get; set; }
            public string id { get; set; }
            public string status { get; set; }
    }

    public static class AttributionAPI
    {
	
    	public struct GetCreatorsRequestParams
    	{
            public int page { get; set; }
            public int pageSize { get; set; }
            public string groupId { get; set; }
    	};
                
        public struct GetCreators200Response
        {
                public int currentPage { get; set; }
                public int currentPageSize { get; set; }
                    public Creator[] creators { get; set; }
        }
    	public delegate void OnGetCreators200ResponseDelegate(GetCreators200Response Response);


    	public delegate void OnGetCreators400ResponseDelegate();

    	public struct GetCreatorsResponseCallbacks
    	{
    			public OnGetCreators200ResponseDelegate OnGetCreators200Response { get; set; }
    			public OnGetCreators400ResponseDelegate OnGetCreators400Response { get; set; }
    	}


        public static IEnumerator StartGetCreatorsRequest(GetCreatorsRequestParams RequestParams, GetCreatorsResponseCallbacks ResponseCallback)
    	{
    		string uri = "https://api.nexus.gg/v1/attributions/creators";

            uri = uri + "?page=" + RequestParams.page;

            uri = uri.Contains("?") ? uri + "&" : uri + "?";
            uri = uri + "pageSize=" + RequestParams.pageSize;

            uri = uri.Contains("?") ? uri + "&" : uri + "?";
            uri = uri + RequestParams.groupId;


    		using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
    		{
    			yield return webRequest.SendWebRequest();
        
    			switch(webRequest.responseCode)
    			{
    
    				case 200:
    				if(ResponseCallback.OnGetCreators200Response != null)
    				{
    					ResponseCallback.OnGetCreators200Response(JsonConvert.DeserializeObject<GetCreators200Response>(webRequest.downloadHandler.text));
    				}
    				break;
    
    				case 400:
    				if(ResponseCallback.OnGetCreators400Response != null)
    				{
    					ResponseCallback.OnGetCreators400Response();
    				}
    				break;
    				default:
    					throw new Exception();
    				break;					
    			}
    		}
    	}


        public struct GetCreatorByUuidRequestParams
        {
            public string creatorSlugOrId { get; set; }
        };
			
        struct GetCreatorByUuid200Response
        {

        }
        public delegate void OnGetCreatorByUuid200ResponseDelegate(GetCreatorByUuid200Response Response);

        public struct GetCreatorByUuidResponseCallbacks
        {
            public OnGetCreatorByUuid200ResponseDelegate OnGetCreatorByUuid200Response { get; set; }
            public OnGetCreatorByUuid404ResponseDelegate OnGetCreatorByUuid404Response { get; set; }
        }

        public static IEnumerator StartGetCreatorByUuidRequest(GetCreatorByUuidRequestParams RequestParams, GetCreatorByUuidResponseCallbacks ResponseCallback)
        {
            string uri = "https://api.nexus.gg/v1/attributions/creators/";

            //TODO: Serialize the request

            using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
        
                switch(webRequest.responseCode)
                {
    
                    case 200:
                    if(ResponseCallback.OnGetCreatorByUuid200Response != null)
                    {
                        ResponseCallback.OnGetCreatorByUuid200Response(JsonConvert.DeserializeObject<GetCreatorByUuid200Response>(webRequest.downloadHandler.text));
                    }
                    break;
    
                    case 404:
                    if(ResponseCallback.OnGetCreatorByUuid404Response != null)
                    {
                        ResponseCallback.OnGetCreatorByUuid404Response(JsonConvert.DeserializeObject<GetCreatorByUuid404Response>(webRequest.downloadHandler.text));
                    }
                    break;
                    default:
                        throw new Exception(); //TODO: Exception on error
                    break;					
                }
            }
        }

        
        public struct GetPingResponseCallbacks
        {
            public OnGetPing200ResponseDelegate OnGetPing200Response { get; set; }
        }


        public static IEnumerator StartGetPingRequest(GetPingRequestParams RequestParams, GetPingResponseCallbacks ResponseCallback)
        {
            string uri = "https://api.nexus.gg/v1/attributions/ping";

            //TODO: Serialize the request

            using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
        
                switch(webRequest.responseCode)
                {
    
                    case 200:
                    if(ResponseCallback.OnGetPing200Response != null)
                    {
                        ResponseCallback.OnGetPing200Response(JsonConvert.DeserializeObject<GetPing200Response>(webRequest.downloadHandler.text));
                    }
                    break;
                    default:
                        throw new Exception(); //TODO: Exception on error
                    break;					
                }
            }
        }
    }
}