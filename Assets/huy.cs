using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huy : MonoBehaviour
{


    private void Awake()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(GameController.Instant.player.HP);
        }
    }
}
