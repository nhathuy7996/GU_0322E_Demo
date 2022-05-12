using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public GameObject g = null;
    [SerializeField] float atkSpeed;
    float timer = 0;

    List<GameObject> poolBullet = new List<GameObject>();

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

        foreach (GameObject g2 in poolBullet)
        {
            if (!g2.activeSelf)
            {
                g2.transform.position = this.transform.position;
                g2.transform.rotation = Quaternion.Euler(0, 0, angle -90);

                g2.SetActive(true);
                return;
            }
        }


        g = Instantiate(bulletPrefab, this.transform.position,
            Quaternion.Euler(0, 0, angle -90));
        poolBullet.Add(g);
    }

    void CountdownTimer()
    {
        timer -= Time.deltaTime;
    }


    private void FixedUpdate()
    {
        
    }
}


