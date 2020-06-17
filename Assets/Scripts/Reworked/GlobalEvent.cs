using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalEvent : MonoBehaviour
{
    [SerializeField]
    private TimeControl time;
    [SerializeField]
    private Score score;
    [SerializeField]
    private GameObject eventPanel;
    [SerializeField]
    private Text labelEvent;
    [SerializeField]
    private Text subjectEvent;
    [SerializeField]
    private Text prosEvent;
    [SerializeField]
    private Text consEvent;     

    
    public void RecieveEvent()
    {
        time.Pause();
        eventPanel.SetActive(true);

    }
}
