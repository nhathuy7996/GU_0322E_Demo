using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Threading.Tasks;

public class huy : MonoBehaviour
{

    float timer = 0;

    [SerializeField] GameObject player;

    Coroutine _waitA;

    private void Awake()
    {
      
    }

    async Task doSth()
    {
        await Task.Run(()=> {

            Test();

            Test2();
        });

        await Task.Delay(10);

        UnityEngine.Debug.Log("AAAAA");
    }

    void Test()
    {

    }

    void Test2()
    {

    }

    // Start is called before the first frame update
     void Start()
    {
        _waitA = StartCoroutine(waitA());

         doSth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // StartCoroutine(startHeavy());

            StartHeavyTask();
        }
        //StartCoroutine(waitA());
    }


    async Task StartHeavyTask()
    {
        UnityEngine.Debug.Log("Start task1");
         await HeavyTask();

        UnityEngine.Debug.Log("Start task2");

         await HeavyTask();
    }

    async Task HeavyTask()
    {
         await Task.Run(()=> {
            try
            {
                UnityEngine.Debug.Log("Start task");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            float[,] Arr = new float[10000, 10000];
            for (int x = 0; x < 10000; x++)
            {
                for (int y = 0; y < 10000; y++)
                {
                    Arr[x, y] = Mathf.PerlinNoise(x * 0.01f, y * 0.01f);
                }
            }
            TimeSpan ts = stopWatch.Elapsed;

            UnityEngine.Debug.Log(ts);

                WkrMain.Instant.wkrs.Enqueue(()=> {
                    player.SetActive(false);
                });
               
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e);
            }

            
        });

      
    }


    IEnumerator waitA()
    {
        yield return new WaitForSeconds(3);

        UnityEngine.Debug.Log("AA");
    }
}
