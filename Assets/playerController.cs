using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] List<Vector3> target = new List<Vector3>();
    [SerializeField] float Speed = 100;

    int currentIndex = 0;

    private void Awake()
    {
       
       
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(10,10,0);

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            //reset taget
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            worldPos.z = 0;

            target.Add(worldPos);
        }

        if (target.Count == 0)
            return;

        if (currentIndex >= target.Count)
            return;

        this.transform.position = Vector3.MoveTowards(this.transform.position, target[currentIndex], Speed * Time.deltaTime);


        if (Vector2.Distance(this.transform.position, target[currentIndex]) <= 0.5f)
            currentIndex++;

        //Time.timeScale = 0;


        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    worldPos.z = 0;

        //    this.transform.position = worldPos;
        //}

    }


    private void FixedUpdate()
    {
        
    }
}


