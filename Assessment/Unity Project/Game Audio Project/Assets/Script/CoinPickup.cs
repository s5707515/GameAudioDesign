using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private AudioSource playerSourceRef;

    [SerializeField] private AudioClip coin1;
    [SerializeField] private AudioClip coin2;
    [SerializeField] private AudioClip coin3;


    // Start is called before the first frame update
    void Start()
    {
        playerSourceRef = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerSourceRef.PlayOneShot(PickCoinSoundToPlay());
            DestroyCoin();
        }
    }

    AudioClip PickCoinSoundToPlay()
    {
        AudioClip soundToPlay = coin1;
        
        int soundID = Random.Range(0, 2);

        switch(soundID)
        {
            case 0:
                soundToPlay = coin1;

                break;

            case 1:
                soundToPlay = coin2;

                break;

            case 2:

                soundToPlay = coin3;

                break;

            default:

                Debug.Log("Sound ID [" + soundID + "] does not exist for Coin Sounds");
                break;

          
        }

        return soundToPlay;


    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
