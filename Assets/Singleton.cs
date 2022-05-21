using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<S> : MonoBehaviour where S: MonoBehaviour
{
    private static S _instant;

    public static S Instant => _instant;

    protected void Awake()
    {
       
        if (Instant == null)
        {
            _instant = this.GetComponent<S>();
        }
        else
            Destroy(this.gameObject);
    }
}
