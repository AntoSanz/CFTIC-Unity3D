using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float currentTime = 0.0f;
    private const string ANIM_ISSPIT = "isSpit";
    private AudioSource audioSource;
    private bool canShot;
    public int damage;
    public float reloadTime;
    [SerializeField] AudioClip acSpit;
    [SerializeField] GameObject pSystem;
    private float pSystemDuration;
    private EnemyShot enemyShot;
    private Animator anim;
    private void Start()
    {
        damage = 100;
        canShot = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyShot = GetComponentInChildren<EnemyShot>();
        //pSystemDuration = GetComponentInChildren<ParticleSystem>().main.duration;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (canShot == true && currentTime >= reloadTime)
        {
            anim.SetBool(ANIM_ISSPIT, true);
           //SpitFire();
            currentTime = 0.0f;
        }
    }
    public void SpitFire()
    {
        enemyShot.Fire();
        pSystem.SetActive(true);
        audioSource.PlayOneShot(acSpit);
        StartCoroutine("DisableParticleSystem");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            canShot = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            canShot = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            collision.gameObject.GetComponent<Player>().ReceiveDamage(damage);
        }
    }
    IEnumerator DisableParticleSystem()
    {
        yield return new WaitForSeconds(1);
        pSystem.SetActive(false);
        anim.SetBool(ANIM_ISSPIT, false);

    }
}
