using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private AudioSource playerSourceRef;

    [SerializeField] private AudioClip coinSFX;



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
            playerSourceRef.PlayOneShot(coinSFX);
            DestroyCoin();
        }
    }

  

    void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
