using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSoundController : MonoBehaviour
{
    public AudioClip metalClang;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = metalClang;
    }

    //if the cross collides with the ghost, it'll make a noise
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
