using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<Enemy> Enemies = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> eyes = this.getPositionPart(); 

        List<Vector3> hands = this.getPositionPart();

        List<Vector3> Legs = this.getPositionPart();


        for (int i = 0; i< 100; i++)
        {
            Enemy E = new Enemy();
            

        }
    }


    List<Vector3> getPositionPart()
    {
        List<Vector3> poss = new List<Vector3>();

        for (int i = 0; i< 1000; i++)
        {
            poss.Add(new Vector3());
        }

        return poss;
    }
}
