using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item {
    public int points;
    private bool used = false;
    public override void Kill()
    {
        base.Kill();
        Destroy(this.gameObject);
    }
    public override void DoAction()
    {
        if (!used)
        {
            used = false;
            base.DoAction();
            GameManager.AddPoints(points);
            Kill();
        }
    }
}
