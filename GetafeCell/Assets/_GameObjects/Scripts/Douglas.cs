using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Douglas : MonoBehaviour
{
    //Constantes
    private const string ANIM_ISWALKING = "isWalking";
    private const string PLAYER_NAME = "Player";
    //private const string PLAYER_TAG = "Player";

    //Variables
    public Transform[] puntosPatrulla;
    private NavMeshAgent agente;
    private Animator anim;
    private int indiceNavegacion = 0;
    private Player player;
    //Distancia de detección
    public float distanciaAviso;
    public float distanciaDeteccionVisual;
    public float distanciaDeteccionPasos;
    public float distanciaDeteccionCarrera;
    public float anguloVision;
    public float distanciaAlPlayer;
    //Estados
    private enum Estado { Idle, Walking };
    private Estado estado = Estado.Idle;
    public bool enloquecido = false;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        GoToDestino(indiceNavegacion);
        player = GameObject.Find(PLAYER_NAME).GetComponent<Player>();
    }

    private void Update()
    {
        Detectar();
        if (estado != Estado.Idle && agente.remainingDistance < 0.1f)
        {
            enloquecido = false;
            estado = Estado.Idle;
            anim.SetBool(ANIM_ISWALKING, false);
            Invoke("AsignarDestino", 2);
        }
    }

    private void AsignarDestino()
    {
        int nuevoIndice;
        do
        {
            nuevoIndice = Random.Range(0, puntosPatrulla.Length);

        } while (nuevoIndice == indiceNavegacion);
        indiceNavegacion = nuevoIndice;

        GoToDestino(indiceNavegacion);
    }

    private void GoToDestino(int _indice)
    {
        estado = Estado.Walking;
        agente.destination = puntosPatrulla[_indice].position;
        anim.SetBool(ANIM_ISWALKING, true);
    }

    private void GoToDestino(Vector3 _nuevoDestino)
    {
        if (!enloquecido)
        {
            estado = Estado.Walking;
            agente.destination = _nuevoDestino;
            anim.SetBool(ANIM_ISWALKING, true);
        }
    }

    private void Detectar()
    {
        distanciaAlPlayer = ObtenerDistanciaAlPlayer();
        switch (player.State)
        {
            case Player.Estado.Idle:
                break;
            case Player.Estado.Walking:
                if (distanciaAlPlayer <= distanciaDeteccionPasos)
                {
                    GoToDestino(player.transform.position);
                }
                break;
            case Player.Estado.Running:
                if (distanciaAlPlayer <= distanciaDeteccionCarrera)
                {
                    GoToDestino(player.transform.position);
                }
                break;
            default:
                break;
        }
    }

    private float ObtenerDistanciaAlPlayer()
    {
        return Vector3.Distance(transform.position, player.gameObject.transform.position);
    }

    public void SetTaunt(Vector3 _newpos)
    {
        GoToDestino(_newpos);
    }
}
