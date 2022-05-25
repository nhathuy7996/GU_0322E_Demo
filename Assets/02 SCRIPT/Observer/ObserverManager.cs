using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : Singleton<ObserverManager>
{
    Dictionary<string, List<IOServer>> ListObserver = new Dictionary<string, List<IOServer>>();
    // Start is called before the first frame update

    public void Add(string key, IOServer client)
    {
        List<IOServer> tmp;
        if( ! ListObserver.TryGetValue(key, out tmp))
        {
            tmp = new List<IOServer>();
        }

        tmp.Add(client);

        ListObserver.Add(key, tmp);
    }

    public void Notify(string key)
    {
        List<IOServer> tmp;
        ListObserver.TryGetValue(key, out tmp);

        foreach (IOServer I in tmp)
        {
            I.excute();
        }
    }

    public void Remove(string key, IOServer client)
    {
        List<IOServer> tmp;
        if (!ListObserver.TryGetValue(key, out tmp))
        {
            tmp = new List<IOServer>();
        }

        tmp.Remove(client);

        ListObserver[key] = tmp;
    }
}

public abstract class IOServer
{
    public Action excute;
}
