using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : ObjectPooling
{
   
    
    [SerializeField] float atkSpeed;
    float timer = 0;

 
    [SerializeField]public  float HP = 100;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0,0,angle - 90);

        CountdownTimer();

        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            timer = atkSpeed;

            GetBullet();
        }
    }


    void GetBullet()
    {

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;



        GameObject g = this.getObj();
        g.transform.position = this.transform.position;
        g.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        g.SetActive(true);
    }

    void CountdownTimer()
    {
        timer -= Time.deltaTime;
    }


    private void FixedUpdate()
    {
        
    }
}


