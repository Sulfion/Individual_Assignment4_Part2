using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Android;
using UnityEngine.VFX;

public class GhostController : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer = 5;
    private float timer;
    private int ghostSpeed = 1;

    private NavMeshAgent agent;
    public AudioClip ghostScream;
    public GameObject fakeGhostBody;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = ghostScream;

        ParticleSystem part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        agent.speed = ghostSpeed;
    }

    //create timer to track how how long until the ghost picks a new position to move to
    //using RandomNavSphere set destination to new position
    public void Timer()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    //choose a random direction, use navmesh move to it
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    //play scream when ghost collides with player
    //hide renderer, spawn fake stationary ghost, wait until VFX are done, then destroy both
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cross"))
        {
            var part = GetComponent<ParticleSystem>();                       
            GetComponent<Collider>().enabled = false;                        //turn off the collider to stop multiple ghosts from "dying"
            part.Play();                                                     
            GetComponent<AudioSource>().Play();                              
            Destroy(gameObject, 2.4f);                                       //wait for animations to finish, then destroy ghost
        }
    }
}
