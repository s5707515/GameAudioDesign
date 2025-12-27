using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.UI;
using Unity.VisualScripting;

public class ButtonSounds : MonoBehaviour,
    IPointerEnterHandler,
    IPointerDownHandler,
    IPointerUpHandler
{

    [Header("Sounds")]

    public AudioSource sourceRef;

    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip buttonDownSound;
    [SerializeField] private AudioClip buttonUpSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound(hoverSound);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlaySound(buttonDownSound);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        PlaySound(buttonUpSound);
    }

    void PlaySound(AudioClip buttonSound)
    {
        if(sourceRef.isPlaying) //Only play HUD sound if another sound isnt being played (avoids spam)
        {
            return;
        }
        

        sourceRef.PlayOneShot(buttonSound);
    }


}
