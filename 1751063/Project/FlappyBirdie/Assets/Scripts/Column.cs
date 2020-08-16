using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public AudioClip scoreClip;
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Birdie> () != null){
            Birdie controller = other.GetComponent<Birdie>();
            GameControl.instance.BirdieScored ();
            controller.PlaySound(scoreClip);
        }
            
    }
}
