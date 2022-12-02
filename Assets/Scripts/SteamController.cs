using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamController : MonoBehaviour
{
    public Vector3 collision = Vector3.zero;
    private float timer = 0;

    public AudioClip steamBlastNoise;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem part = GetComponent<ParticleSystem>();
        GetComponent<AudioSource>().clip = steamBlastNoise;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromSteamCheckAndRaycast();
    }

    //create raycast, check if gameobject is player using tag, if it is a player, play steam particle effect
    //check how long player was in raycast, if 2.5 seconds or longer play steam particle and steam sound
    public void DistanceFromSteamCheckAndRaycast()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance: 8))
        {
            if (hit.collider.CompareTag("Player"))
            {
                timer += Time.deltaTime;
                if (timer >= 2.5f)
                {
                    var part = GetComponent<ParticleSystem>();
                    GetComponent<AudioSource>().Play();
                    part.Play();
                    Debug.Log("Hit");
                    timer = 0;
                }
            }
        }
    }
}
