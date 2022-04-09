using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCOntroller : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

        

        Debug.Log(Camera.main.name);

        Vector3 maxScreen; //= new Vector3(Screen.width, Screen.height, 0);

        maxScreen.x = Screen.width;
        maxScreen.y = Screen.height;
        maxScreen.z = 0;

        Vector3 worldPos =  Camera.main.ScreenToWorldPoint(maxScreen);


        //Camera.main.WorldToScreenPoint();

        Debug.Log(worldPos);

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 worldPos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
    }
}
