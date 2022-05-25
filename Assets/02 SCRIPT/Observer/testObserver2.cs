using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testObserver2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ObserverManager.Instant.Notify("trigger");

            //Test1.moethod1();
            // Test2.method2();
        }
    }
}
