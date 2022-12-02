using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomPositionDirectionalGhostLaughter : MonoBehaviour
{
    public AudioClip ghostLaughter;

    private float timer = 0.0f;

    public AudioClip[] voiceLines;
    public AudioSource voiceLinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = ghostLaughter;
    }

    // Update is called once per frame
    void Update()
    {
        RandomLaugh();
    }

    //use array to store and select random voice line
    public void VoiceLineSelector()
    {
        int voiceLine = Random.Range(0, voiceLines.Length);
        voiceLinePlayer.clip = voiceLines[voiceLine];
        voiceLinePlayer.Play();
    }

    //find random location in map and play voiceline
    public void RandomLaugh()
    {
        timer += Time.deltaTime;
        if (timer >= Random.Range(10f, 25f))
        {
            VoiceLineSelector();  
            Vector3 test = new Vector3(Random.Range(-6, 6), Random.Range(0, 6), Random.Range(-2, 18)); 
            this.transform.position = test; 
            timer = 0;  
        }
    }
}
