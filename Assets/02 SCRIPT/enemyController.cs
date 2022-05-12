using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    Rigidbody2D Rigi;
    [SerializeField] Transform Target;
    [SerializeField] Vector2 movement = Vector2.zero;
    [SerializeField] float Speed = 0, timeRanDir = 3, atkTime = 1;
    float timer = 0;

    Coroutine randomDir_cor;
    Vector2 screen;


    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        Rigi = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void OnEnable()
    {
        randomDir_cor = StartCoroutine(randomDir());
        movement = new Vector2(
               Random.Range(-1f, 1f),
               Random.Range(-1f, 1f)
               );


        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void OnDisable()
    {
        StopCoroutine(randomDir_cor);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
        Rigi.velocity = movement.normalized * Speed * Time.deltaTime;

        timer -= Time.deltaTime;
        if (Target != null)
            Fire();
    }

    IEnumerator randomDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(timeRanDir/2, timeRanDir));

            if(checkOutSider())
            {
                Vector2 dirCam = Camera.main.transform.position - this.transform.position;
                movement = dirCam;
            }
            else
            {
                movement = new Vector2(
              Random.Range(-1f, 1f),
              Random.Range(-1f, 1f)
              );
            }

            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0,0,angle -90);
        }
    }

    bool checkOutSider()
    {
        if (this.transform.position.x > screen.x / 2)
            return true;

        if (this.transform.position.x < -screen.x / 2)
            return true;

        if (this.transform.position.y > screen.y / 2)
            return true;

        if (this.transform.position.y < -screen.y / 2)
            return true;

        return false;
    }

    void CheckTarget()
    {
        Debug.DrawRay(this.transform.position, movement.normalized, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position,movement.normalized,Mathf.Infinity );

        if (hit.collider == null)
        {
            Target = null;
            return;
        }

        if (!hit.collider.gameObject.CompareTag("Player"))
        {
            Target = null;
            return;
        }

        Target = hit.collider.transform;
        
    }

    void Fire()
    {
        if (timer > 0)
            return;

        timer = atkTime;

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        
        Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0,0,angle - 90));

    }

}
