using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField] GameObject _prefab;

    List<GameObject> _pool = new List<GameObject>();

    public GameObject getObj()
    {
        foreach (GameObject G in _pool)
        {
            if (!G.activeSelf)
            {
                return G;
            }
        }
        GameObject G2 = Instantiate(_prefab,this.transform.position, Quaternion.identity);
        _pool.Add(G2);
        G2.SetActive(false);
        return G2;
    }
}
