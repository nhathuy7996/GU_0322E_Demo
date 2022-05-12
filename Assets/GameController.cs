using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController instant;

    public static GameController Instant => instant;

    [SerializeField]
    private playerController _player;

    public playerController player
    {
        get
        {
            if (_player == null)
                _player = FindObjectOfType<playerController>();

            return _player;
        }
    }


    public int Score = 0;

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float spawTime;

    float timer;

    Coroutine spawEnemyCor;

    private void Awake()
    {
        if (GameController.instant == null)
            GameController.instant = this;

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
