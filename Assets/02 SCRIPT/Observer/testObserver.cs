using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testObserver : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ObserverManager.Instant.Notify("trigger");

            //Test1.moethod1();
           // Test2.method2();
        }
    }
}
