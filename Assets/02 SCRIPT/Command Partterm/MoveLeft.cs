using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    TestCMP testCMP;

    public MoveLeft(TestCMP testCMP)
    {
        this.testCMP = testCMP;
    }

    public override void ExeCute()
    {
        this.testCMP.MoveLeft();

        this.testCMP.history.Push(this);
    }

    public override void reExeCute()
    {
        this.testCMP.MoveRight();
    }
}
