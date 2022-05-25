using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    TestCMP testCMP;

    public MoveRight(TestCMP testCMP)
    {
        this.testCMP = testCMP;
    }

    public override void ExeCute()
    {
        this.testCMP.MoveRight();

        this.testCMP.history.Push(this);
    }

    public override void reExeCute()
    {
        this.testCMP.MoveLeft();
    }
}

public class MoveUp : Command
{
    public override void ExeCute()
    {
        this.transform.position += Vector3.up * 10;
    }

    public override void reExeCute()
    {
        throw new System.NotImplementedException();
    }
}

public class MoveDown : Command
{
    public override void ExeCute()
    {
        this.transform.position += Vector3.down * 10;
    }

    public override void reExeCute()
    {
        throw new System.NotImplementedException();
    }
}
