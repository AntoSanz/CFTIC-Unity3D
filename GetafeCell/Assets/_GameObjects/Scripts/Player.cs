using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ANIM_ISWALKING = "isWalking";
    private const string ANIM_ISRUNNING = "isRunning";
    private const string VERTICAL = "Vertical";
    private const string HORIZONTAL = "Horizontal";
    private Animator anim;
    private float x, y;
    
    //Estado
    public enum Estado { Idle, Walking, Running };
    private Estado state;

    public Estado State {
        get {
            return state;
        }

        set {
            state = value;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //firePoint = gameObject.GetComponent<FirePoint>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis(HORIZONTAL);
        y = Input.GetAxis(VERTICAL);
        if (y > 0.1f || Input.GetKeyDown(KeyCode.W))
        {
            Walk();
        }
        else
        {
            Stop();
        }

        if (x != 0)
        {
            Rotate();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StopRun();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            LanzarProyectil();
        }
    }

    private void Run()
    {
        anim.SetBool(ANIM_ISRUNNING, true);
        state = Estado.Running;
    }

    private void StopRun()
    {
        anim.SetBool(ANIM_ISRUNNING, false);
        state = Estado.Walking;
    }

    private void Walk()
    {

        if (state != Estado.Running)
        {
            anim.SetBool(ANIM_ISWALKING, true);
            state = Estado.Walking;
        }

    }

    private void Stop()
    {
        StopRun();
        anim.SetBool(ANIM_ISWALKING, false);
        state = Estado.Idle;
    }

    private void Rotate()
    {
        transform.Rotate(0, x, 0);
    }

    private void Jump()
    {

    }

    private void LanzarProyectil()
    {
        GetComponentInChildren<FirePoint>().Fire();

    }
}
