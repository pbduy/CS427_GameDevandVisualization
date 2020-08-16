using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdie : MonoBehaviour
{
    AudioSource audioSource;
    public float upForce = 200f;
    public AudioClip flap;
    public AudioClip die;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    private float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                PlaySound(flap);
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        PlaySound(die);
        GameControl.instance.BirdieDie ();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
