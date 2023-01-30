using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private bool activated = false;
    private Animator anim;
    private const string ANIM_PARAM_CHECKED = "checked";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER) && activated == false)
        {
            activated = true;
            anim.SetBool(ANIM_PARAM_CHECKED, true);
            collision.gameObject.GetComponent<Player>().SetCheckPointPosition(transform.position);
        }
    }
}
