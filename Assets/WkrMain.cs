using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class WkrMain : MonoBehaviour
{

    private static WkrMain _instant;
    public static WkrMain Instant => _instant ;


    public Queue<Action> wkrs = new Queue<Action>();

    UnityWebRequest webRequest;

    private void Awake()
    {
        _instant = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(testWebRequest());

        webRequest = UnityWebRequest.Get("https://google.com");
    }

    // Update is called once per frame
    void Update()
    {
        if (wkrs.Count == 0)
            return;

        Action task = wkrs.Dequeue();
        if (task != null)
        {
            try
            {
                task();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
           
        }

        if (webRequest.SendWebRequest().isDone)
        {
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    break;
            }
        }

    }

    
}
