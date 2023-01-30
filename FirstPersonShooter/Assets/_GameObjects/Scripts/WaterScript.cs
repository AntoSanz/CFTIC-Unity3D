using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] int waterDamage = 10;
    [SerializeField] float timeBetweenDamage = 1f;
    private PlayerScript player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    private void Update()
    {

    }
    private void DoDamage()
    {
        //print("DoDamage");
        player.RecibirDamage(waterDamage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("DoDamage", 1, timeBetweenDamage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //print("Sale del agua");
        CancelInvoke();
    }

}
