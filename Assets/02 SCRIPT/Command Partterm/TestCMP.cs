using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCMP : MonoBehaviour
{

    Command buttonA;

    Command buttonD;

    Command buttonJ;

    Command buttonK;

    public Stack<Command> history = new Stack<Command>();


    // Start is called before the first frame update
    void Start()
    {
        buttonA = new MoveLeft(this);
        buttonD = new MoveRight(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonA.ExeCute();

           // MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonD.ExeCute();

            //MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //if(buttonJ != null)
                buttonJ.ExeCute();

            //MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
           // if (buttonK != null)
                buttonK.ExeCute();

            //MoveRight();
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(replay());
        }
    }


    IEnumerator replay()
    {
        while (this.history.Count != 0)
        {
            Debug.Log(this.history.Count);
            this.history.Pop().reExeCute();

            yield return new WaitForSeconds(1);
        }

    }

    public void MoveLeft()
    {
        this.transform.position += Vector3.left;
    }

    public void MoveRight()
    {
        this.transform.position += Vector3.right;
    }
}
