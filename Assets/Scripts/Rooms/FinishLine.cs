using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
       private Animator anim;

    private void Awake(){
        anim= GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Win")
        {
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("win");
        }
    }
    }


