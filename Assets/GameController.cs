using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    private int _Score;

    public int Score
    {
        get { return _Score; }

        set {
            if(value >= 0)
            _Score = value;
        }
    }

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float spawTime;

    float timer;

    Coroutine spawEnemyCor;

    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawEnemyCor = StartCoroutine(SpawCreep(3));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StopCoroutine(spawEnemyCor);
        }
    }

    IEnumerator SpawCreep(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            Vector2 screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            Vector2 pos = new Vector2(Random.Range(-screen.x / 2, screen.x / 2), Random.Range(-screen.y / 2, screen.y / 2));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
