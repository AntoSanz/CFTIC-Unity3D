using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State { InFloor, Jumping, Immune }

    [Header("Horizontal speed")]
    [SerializeField] float linearSpeed;
    [Header("Jump force")]
    [SerializeField] float jumpForce;
    [SerializeField] float health;
    [Header("Impulse force")]
    [SerializeField] float xForce;
    [SerializeField] float yForce;

    private const string ANIM_WALK = "walking";
    public State state;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;
    private Vector2 lastCheckPointPos;

    private float x, y;
    private float xExternal;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        lastCheckPointPos = transform.position;

    }
    private void Start()
    {
        GameManager.SaveData(lastCheckPointPos);
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        if (x == 0)
            x = xExternal;

        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponentInChildren<Weapon>().Fire();
        }
    }
    private void FixedUpdate()
    {
        Walk();
    }
    public void Jump()
    {
        if (state == State.Jumping)
        {
            //print("aa");
            return;
        }
        //print("aa2");
        rb2d.velocity = new Vector2(x * linearSpeed, jumpForce);
    }
    private void Walk()
    {
        if (Mathf.Abs(x) > 0)
        {
            animator.SetBool(ANIM_WALK, true);
            rb2d.velocity = new Vector2(x * linearSpeed, rb2d.velocity.y);
            transform.rotation = (x > 0) ? Quaternion.Euler(Vector2.zero) : Quaternion.Euler(new Vector2(0, 180));
        }
        else
        {
            animator.SetBool(ANIM_WALK, false);
        }
    }
    public void ReceiveDamage(int _damage)
    {
        health = health - _damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GameManager.SubstractLive();
        transform.position = lastCheckPointPos;        
    }
    public void SetImpulse(float _force)
    {
        int multiplier = sr.flipX ? 1 : -1;
        rb2d.AddForce((new Vector2(xForce * multiplier, yForce)) * _force);
        state = State.Jumping;
    }
    private void ChangeFriction(float _newFriction)
    {
        PhysicsMaterial2D pm2d = GetComponent<CapsuleCollider2D>().sharedMaterial;
        pm2d.friction = _newFriction;
        GetComponent<CapsuleCollider2D>().sharedMaterial = pm2d;
    }
    public void SetCheckPointPosition(Vector2 _newPos)
    {
        lastCheckPointPos = _newPos;
        GameManager.SaveData(lastCheckPointPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == State.Jumping)
        {
            //print("EnterCollider: " + state);
            state = State.InFloor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("EnterCollider: " + state + "COSA:" + collision.gameObject.name);
        if (collision.CompareTag(Tags.ITEM))
        {
            collision.gameObject.GetComponent<Item>().DoAction();
        }
        else if (collision.CompareTag(Tags.GLUE_OBJECT))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("ExitCollider: " + state);
        state = State.Jumping;
        ChangeFriction(0f);
        transform.SetParent(null);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        state = State.InFloor;
        ChangeFriction(1f);
    }

    public void SetExternalRight()
    {
        xExternal = 1;
    }
    public void SetExternalLeft()
    {
        xExternal = -1;
    }
    public void SetExternalJump()
    {
            Jump();      
    }
    public void SetExternalFire()
    {
        GetComponentInChildren<Weapon>().Fire();
    }
}