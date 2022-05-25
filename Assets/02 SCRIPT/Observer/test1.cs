using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test1Listener: IOServer
{
   
}

public class test1 : MonoBehaviour
{

    test1Listener listener = new test1Listener();

    
    // Start is called before the first frame update
    void Start()
    {
       
        listener.excute = moethod1;
        ObserverManager.Instant.Add("trigger", listener);
    }

    private void OnDestroy()
    {
        ObserverManager.Instant.Remove("trigger", listener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moethod1()
    {
        Debug.Log("Call on test1!");
    }
}
