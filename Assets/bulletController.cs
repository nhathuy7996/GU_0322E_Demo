using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float lifeTime;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        timer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 dir = new Vector2(
        //    Mathf.Cos(this.transform.rotation.z * Mathf.Deg2Rad),
        //    Mathf.Sin(this.transform.rotation.z * Mathf.Deg2Rad)
        //    );

        this.transform.position += transform.up * Speed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0)
            this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
        Destroy(collision.gameObject);

        GameController.Instant.Score++;
    }
}
