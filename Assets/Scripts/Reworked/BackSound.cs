using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioBack;
    [SerializeField]
    private AudioSource audio1;
    [SerializeField]
    private AudioSource audio2;
    [SerializeField]
    private AudioSource audio3;
    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite pauseImage;
    [SerializeField]
    private Sprite playImage;

    

    public void Mute()
    {
        if (isPaused == false)
        {
            audioBack.mute = true;
            audio1.mute = true;
            audio2.mute = true;
            audio3.mute = true;
            isPaused = true;
            image.sprite = playImage;
        }
        else
        {
            audioBack.mute = false;
            audio1.mute = true;
            audio2.mute = true;
            audio3.mute = true;
            isPaused = false;
            image.sprite = pauseImage;
        }
    }
}
