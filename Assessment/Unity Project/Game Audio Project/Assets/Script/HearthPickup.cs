using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private AudioSource playerSourceRef;

    [SerializeField] private AudioClip heartPickUpSound;


    // Start is called before the first frame update
    void Start()
    {
        playerSourceRef = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerSourceRef.pitch = Random.Range(0.90f, 1.10f);
            playerSourceRef.PlayOneShot(heartPickUpSound);
            DestroyHeart();
        }
    }

    void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
