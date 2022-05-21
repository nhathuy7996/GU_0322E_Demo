using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class TestUniTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _= TestUnitask();
    }

    // Update is called once per frame
    void Update()
    {

       

       
    }

    async UniTask TestUnitask()
    {
       
        Debug.Log("Start wk1");
        int res1 = await wk1();
        Debug.Log(res1);

        Debug.Log("Start wk2");
         int res2 = await wk1();

        Debug.Log(res2);

        ts.Cancel();
    }

    CancellationTokenSource ts = new CancellationTokenSource();
    async UniTask<int> wk1()
    {
        Debug.LogError("Call here!");

        await UniTask.DelayFrame(100, cancellationToken: ts.Token);

        Debug.LogError("Done!");

        return 1 + 1;
    }
}
