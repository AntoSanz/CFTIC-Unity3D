using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUp : Item
{
    private const int NUM_VIDAS = 1;
    public override void Kill()
    {
        base.Kill();
        Destroy(this.gameObject);
    }
    public override void DoAction()
    {
        base.DoAction();
        if (GameManager.MAX_LIVES != GameManager.Lives)
        {
            GameManager.AddLive(NUM_VIDAS);
            Kill();
        }
    }
}
