using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Footsteps : MonoBehaviour
{

    private AudioSource sourceRef;

    private PlayerController contollerRef;


    [SerializeField] private float sphereRadius;

    [SerializeField] private LayerMask pathLayer;
    [SerializeField] private LayerMask rockLayer;

    [SerializeField] private AudioClip grassSteps;
    [SerializeField] private AudioClip pathSteps;
    [SerializeField] private AudioClip rockSteps;

    [SerializeField] private AudioClip stepsToPlay;



    // Start is called before the first frame update
    void Start()
    {

        sourceRef = GetComponent<AudioSource>();
        contollerRef = GetComponent<PlayerController>();

        stepsToPlay = grassSteps;
    }

    // Update is called once per frame
    void Update()
    {
        if(contollerRef.GetIsMoving() &!sourceRef.isPlaying)
        {
            //Check if player is ontop of path

            Collider[] hitPath = Physics.OverlapSphere(transform.position, sphereRadius, pathLayer);

            if (hitPath.Length > 0)
            {
                stepsToPlay = pathSteps;
            }
            else
            {
                //Check if player is ontop of a rock
                hitPath = Physics.OverlapSphere(transform.position, sphereRadius, rockLayer);

                if (hitPath.Length > 0)
                {
                    stepsToPlay = rockSteps;
                }
                else
                {
                    //Player must be on grass
                    stepsToPlay = grassSteps;
                }


            }

           
            sourceRef.pitch = Random.Range(0.90f, 1.10f);

                

            sourceRef.PlayOneShot(stepsToPlay);

                //sourceRef.pitch = 1.0f;
            

        }

       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
