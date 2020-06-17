using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomHandler : MonoBehaviour
{
    [SerializeField]
    public string label;
    [SerializeField]
    public string description;
    [SerializeField]
    public int roomIndex;
    [SerializeField]
    public int lvl;
    [SerializeField]
    public string id;
   
    [SerializeField]
    public float leftTimer;
   
    [SerializeField]
    private NewRoomList rooms;
 
    [SerializeField]
    private Text labelText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text costText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Button upgradeButton;
    [SerializeField]
    private GameObject timerImage;
    // [SerializeField]
    //  public int costBuild;
    // [SerializeField]
    // public int costUp;    

    //  [SerializeField]
    // public bool isUpgradeable;
    // [SerializeField]
    // public int roomToUpgrade;

    // Update is called once per frame

    void Update()
    {
        labelText.text = label + ", " + lvl + " уровень";
        if (leftTimer > 0)
        {
            timerImage.SetActive(true);
            timerText.text = leftTimer.ToString();
        }
        else
        {
            timerImage.SetActive(false);
            timerText.text = "";
        }
        if (lvl < 3)
        {
            costText.text = "Стоимость улучшения: " + rooms.Rooms[roomIndex].BuildCost[lvl].ToString() + " контуриков";
        }
        else
        {
            costText.text = "Максимальный уровень улучшения";
        }
        descriptionText.text = description;
     //   costText.text = costUp.ToString();        
        if(lvl < 3) // change for 3 lvl
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }
}
