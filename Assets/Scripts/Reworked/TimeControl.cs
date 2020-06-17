using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    [SerializeField]
    public bool isPaused;
    [SerializeField]
    private Sprite pauseImage;
    [SerializeField]
    private Sprite playImage;
    [SerializeField]
    private Text speedText;

    private float lastTimeScale;

    [SerializeField]
    private bool boost = false;
    [SerializeField]
    private Sprite speedNormalImage;
    [SerializeField]
    private Sprite speedFastImage;

    [SerializeField]
    private Image pauseButton;
    [SerializeField]
    private Image speedButton;

    private void Start()
    {
        Pause();
    }
    public void Pause()
    {
        if (isPaused == false)
        {
            lastTimeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseButton.sprite = playImage;
        }
        else
        {
            Time.timeScale = lastTimeScale;
            pauseButton.sprite = pauseImage;
        }
        isPaused = !isPaused;
    }
    public void SpeedUp()
    {
        if (isPaused == true)
        {
            Pause();
        }
        if (boost == false)
        {
            Time.timeScale = 3;
            speedButton.sprite = speedFastImage;
            speedText.text = "X2";
        }
        else
        {
            Time.timeScale = 1;
            speedButton.sprite = speedNormalImage;
            speedText.text = "X1";
        }
        boost = !boost;
      
    }
    public void OpenHelp()
    {
        if(isPaused == false)
        {
            Pause();
        }
    }
}
