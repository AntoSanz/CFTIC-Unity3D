using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntEnemy : EnemyMobileScript {
    //private Transform transformPlayer;
    //private void Start() {
    //    transformPlayer = GameObject.Find("Player").transform;
    //    base.Start();
    //}
    private void Update() {
        if (AtackDistance()) {
            //A por él
            transform.LookAt(transformPlayer);
            
        }
        base.Update();
    }
    private bool AtackDistance() {
        bool isDistance = false;
        if(Vector3.Distance(transform.position, transformPlayer.position) < distanciaDeteccion) {
            isDistance = true;
        }
        return isDistance;
    }

}
