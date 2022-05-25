using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test2 : MonoBehaviour
{

    test1Listener listener = new test1Listener();

    // Start is called before the first frame update
    void Start()
    {
        listener.excute = method2;
        ObserverManager.Instant.Add("trigger", listener);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void method2()
    {
        Debug.Log("Call on method2");
    }
}
