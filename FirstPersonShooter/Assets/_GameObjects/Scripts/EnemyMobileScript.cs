using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobileScript : EnemyScript {
    [SerializeField] float velocidad;

    private float angulo;
    private const int INIT_ROTACION = 1;
    private const int ROTATION_TIME = 2;
    private const float ANGULO_MINIMO_ROT = -90f;
    private const float ANGULO_MAXIMO_ROT = 90f;

    public override void Start() {
        InvokeRepeating("Rotar", INIT_ROTACION, ROTATION_TIME);
        base.Start();
    }

    public void Update() {
        Move();
    }

    private void Rotar() {
        angulo = Random.Range(ANGULO_MINIMO_ROT, ANGULO_MAXIMO_ROT);
        transform.Rotate(new Vector3(0, angulo, 0));
    }

    private void Move() {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }
}
