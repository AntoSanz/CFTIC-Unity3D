using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : EnemyScript
{

    //Gestion de fases
    public int maxsalud = 250;
    public float phase1init = 1f;
    public float phase2init = 0.75f;
    public float phase3init = 0.25f;
    public float velocidad = 1f;

    private int currentPhase = 1;
    private const int MAX_PHASE = 3;
    private float angulo;

    private const float ANGULO_MINIMO_ROT = -90f;
    private const float ANGULO_MAXIMO_ROT = 90f;
    private const int INIT_ROTACION = 1;
    private const int ROTATION_TIME = 2;

    //private float humilloR = 255f;
    //private float humilloG = 0f;
    //private float humilloB = 0f;
    //private float humilloA = 1f;

    [SerializeField] GameObject prefabBolillas;
    [SerializeField] GameObject prefabHumillo;

    public class HumilloColor
    {
        public float Red { get; set; }
        public float Blue { get; set; }
        public float Green { get; set; }
        public float Alfa { get; set; }

        public HumilloColor(float red, float green, float blue, float alfa)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alfa = alfa;
        }
    }

    public override void Start()
    {
        // prefabHumillo.main.startColor = new Color(0,0,0,0);
        salud = maxsalud;
        InvokeRepeating("Rotate", INIT_ROTACION, ROTATION_TIME);
        base.Start();
    }
    private void Update()
    {
        if (salud >= (maxsalud * phase2init))
        {
            print("FASE 1");
            currentPhase = 1;
        }
        if (salud <= (maxsalud * phase2init))
        {
            print("FASE 2");
            currentPhase = 2;
        }
        if (salud <= (maxsalud * phase3init))
        {
            print("FASE 3");
            currentPhase = 3;
        }
        CheckPhase(currentPhase);
    }
    /// <summary>
    /// Gestiona la fase en la que se encuentra el boss.
    /// </summary>
    /// <param name="_currentPhase">Numero de la fase en la que se encuentra el boss (1, 2 ó 3)</param>
    private void CheckPhase(int _currentPhase)
    {
        switch (_currentPhase)
        {
            case 1:
                Phase1Manager();
                break;
            case 2:
                Phase2Manager();
                break;
            case 3:
                Phase3Manager();
                break;
        }
    }
    /// <summary>
    /// Gestión de la fase 1.
    /// </summary>
    private void Phase1Manager()
    {
        HumilloColor hc1 = new HumilloColor(255f, 0f, 252f, 1f);
        prefabHumillo.GetComponent<ParticleSystem>().startColor = new Color(hc1.Red, hc1.Green, hc1.Blue, hc1.Alfa);
        this.velocidad = 2;
        Move();
    }
    /// <summary>
    /// Gestión de la fase 2.
    /// </summary>
    private void Phase2Manager()
    {
        HumilloColor hc2 = new HumilloColor(255f, 125f, 0f, 1f);
        prefabHumillo.GetComponent<ParticleSystem>().startColor = new Color(hc2.Red, hc2.Green, hc2.Blue, hc2.Alfa);

        this.velocidad = 4;

        Move();

        if (currentPhase == 2 && AtackDistance())
        {
            //A por él
            this.velocidad = 3;
            transform.LookAt(transformPlayer);

        }
    }
    /// <summary>
    /// Gestión de la fase 3.
    /// </summary>
    private void Phase3Manager()
    {
        prefabBolillas.gameObject.SetActive(true);
        HumilloColor hc3 = new HumilloColor(255f, 0f, 0f, 1f);
        prefabHumillo.GetComponent<ParticleSystem>().startColor = new Color(hc3.Red, hc3.Green, hc3.Blue, hc3.Alfa);

        this.velocidad = 5;
        Move();
        if (currentPhase == 3 && AtackDistance())
        {
            //A por él
            this.velocidad = 4;
            transform.LookAt(transformPlayer);
        }
    }
    /// <summary>
    /// Desplaza el enemigo hacia delante.
    /// </summary>
    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }
    /// <summary>
    /// Rota al enemigo aleatoriamente.
    /// </summary>
    private void Rotate()
    {
        angulo = Random.Range(ANGULO_MINIMO_ROT, ANGULO_MAXIMO_ROT);
        transform.Rotate(new Vector3(0, angulo, 0));
    }
    /// <summary>
    /// Función de ataque del enemigo. Persigue si entras en el rango.
    /// </summary>
    /// <returns></returns>
    private bool AtackDistance()
    {
        bool isDistance = false;
        if (Vector3.Distance(transform.position, transformPlayer.position) < distanciaDeteccion)
        {
            isDistance = true;
        }
        return isDistance;
    }
}
