using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    [SerializeField]
    private RoomHandler roomHandler;
    [SerializeField]
    private Score score;
    [SerializeField]
    private TimeLine timeLine;

    [SerializeField]
    private NewRoomList roomList;

    [SerializeField]
    private GameObject upgradePanel;
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject hintInfo;
    [SerializeField]
    private Text hintText;
    [SerializeField]
    private Text labelText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text costText;
    [SerializeField]
    private Image previewImage;
    [SerializeField]
    private GameEvent buildEvent;

    [SerializeField]
    private GameObject stat;

    [SerializeField]
    private Sprite emptyImage;

    public void Build(NewRoom room) // build lvl 1 from build panel
    {
        GameObject gameObject = GameObject.Find(roomHandler.id.ToString());
        RoomProperty currentRoom = gameObject.GetComponent<RoomProperty>();
        Animator animator = gameObject.GetComponent<Animator>();
        GameOver over = stat.GetComponent<GameOver>();
       
        if (score.money >= room.BuildCost[0])
        {
            // minus money and happiness
            score.MoneyOperation(-room.BuildCost[0]);
            score.HappinessOperation(room.Happiness[0]);
            animator.SetInteger("index", room.AnimationIndex[0]);
            // and pass param to corespond room
            // naming
            currentRoom.label = room.Label;
            currentRoom.description = room.Description[0];
            currentRoom.resourceType = room.ResourceType;
                // base param
            currentRoom.baseResorceGenerate = room.Resource[0];
            currentRoom.productConsume = room.ProductConsume[0];
            currentRoom.baseTaxToPay = room.Taxes[0];
            currentRoom.baseTimeGenerate = room.ProductionTime[0];
            currentRoom.costBuild = room.BuildCost[0];
            currentRoom.lvl = 1;
            currentRoom.roomIndex = room.RoomIndex; // rename later in RoomProperty
                // multi
           // currentRoom.localResoureceMulti = room.LocalMoneyMulti[0];
           // currentRoom.localTaxMulti = room.TaxMulti[0];
           // currentRoom.localTimeMulti = room.TimeMulti[0];
           // currentRoom.eventMulti = room.EventMulti[0];
                // do smth with local support
            //////
                // bool managment
            currentRoom.isEmpty = false;
                // handle sprite update
            currentRoom.image = room.Image[0];
            currentRoom.UpdateSprite();
                // operations with global multi at Score
            score.globalResourceMulti *= room.MoneyMulti[0];
            score.globalTaxMulti *= room.TaxMulti[0];
            score.globalTimeMulti *= room.TimeMulti[0];
            score.globalEventChance *= room.EventMulti[0];
            timeLine.eventChance *= room.EventMulti[0];
                // update data in room
            currentRoom.UpdateMulti();
            currentRoom.NullTimer();
            currentRoom.Select();
                // and Handle UI panels
            upgradePanel.SetActive(true);
            buildPanel.SetActive(false);
            buildEvent.Raise();            
            int id = int.Parse(roomHandler.id);
            over.roomLabels[id] = room.Label;
        }
    }
    public void Build(NewRoom room, int lvl) 
    {
        GameObject gameObject = GameObject.Find(roomHandler.id.ToString());
        RoomProperty currentRoom = gameObject.GetComponent<RoomProperty>();
        GameOver over = stat.GetComponent<GameOver>();
        if (score.money >= room.BuildCost[lvl])
        {
            // minus money and happiness
            score.MoneyOperation(-room.BuildCost[lvl]);
            score.HappinessOperation(room.Happiness[lvl]);
            Animator animator = gameObject.GetComponent<Animator>();
            animator.SetInteger("index", room.AnimationIndex[lvl]);
            // and pass param to corespond room
            // naming
            currentRoom.label = room.Label;
            if(lvl == 1)
            {
                currentRoom.description = room.Description[0] + " " + room.Description[1];
            }
            else
            {
                currentRoom.description = room.Description[0] + " " + room.Description[1] + " " + room.Description[2];
            }
          //  currentRoom.description = room.Description[lvl];
            currentRoom.resourceType = room.ResourceType;
            // base param
            currentRoom.baseResorceGenerate = room.Resource[lvl];
            currentRoom.productConsume = room.ProductConsume[lvl];
            currentRoom.baseTaxToPay = room.Taxes[lvl];
            currentRoom.baseTimeGenerate = room.ProductionTime[lvl];
            currentRoom.costBuild = room.BuildCost[lvl];
            currentRoom.lvl = lvl + 1;
            currentRoom.roomIndex = room.RoomIndex; // rename later in RoomProperty
                                                        // multi
                                                        /*
            currentRoom.localResoureceMulti = room.MoneyMulti[lvl];
            currentRoom.localTaxMulti = room.TaxMulti[lvl];
            currentRoom.localTimeMulti = room.TimeMulti[lvl];
            currentRoom.eventMulti = room.EventMulti[lvl];
            */
            // do smth with local support
            //////
            // bool managment
            currentRoom.isEmpty = false;
            // handle sprite update
            currentRoom.image = room.Image[lvl];
            currentRoom.UpdateSprite();
            // operations with global multi at Score
            score.globalResourceMulti *= room.MoneyMulti[lvl];
            score.globalTaxMulti *= room.TaxMulti[lvl];
            score.globalTimeMulti *= room.TimeMulti[lvl];
            score.globalEventChance *= room.EventMulti[lvl];
            timeLine.eventChance *= room.EventMulti[lvl];
            // update data in room
            currentRoom.UpdateMulti();
            currentRoom.NullTimer();
            currentRoom.Select();
            // and Handle UI panels
            upgradePanel.SetActive(true);
            buildPanel.SetActive(false);
            buildEvent.Raise();
            int id = int.Parse(roomHandler.id);
            over.roomLabels[id] = room.Label;
        }
    }
    public void Upgrade()
    {
        Build(roomList.Rooms[roomHandler.roomIndex], roomHandler.lvl);
        hintInfo.SetActive(false);
    }
    public void Sell()
    {
        GameObject gameObject = GameObject.Find(roomHandler.id.ToString());
        RoomProperty currentRoom = gameObject.GetComponent<RoomProperty>();
        Animator animator = gameObject.GetComponent<Animator>();
        GameOver over = stat.GetComponent<GameOver>();
        
        // bool managment
        currentRoom.isEmpty = true;
        // refund calculations        
        int moneyRefund = 0;
        int happinessRefund = 0;
        float moneyMultiRefund = 1;
        float timeMultiRefund = 1;
        float eventMultiRefund = 1;
        float taxMultiRefund = 1;
        for(int i = 0; i<currentRoom.lvl; i++ )
        {
            moneyRefund += roomList.Rooms[currentRoom.roomIndex].BuildCost[i];
            happinessRefund += roomList.Rooms[currentRoom.roomIndex].Happiness[i];
            moneyMultiRefund *= roomList.Rooms[currentRoom.roomIndex].MoneyMulti[i];
            timeMultiRefund *= roomList.Rooms[currentRoom.roomIndex].TimeMulti[i];
            eventMultiRefund *= roomList.Rooms[currentRoom.roomIndex].EventMulti[i];
            taxMultiRefund *= roomList.Rooms[currentRoom.roomIndex].TaxMulti[i];
        }
        // and some local??
        //
        // actually the refund
        Debug.Log(moneyRefund + " refund");
        score.MoneyOperation(Mathf.RoundToInt(moneyRefund * 0.3f));
        score.HappinessOperation(-happinessRefund);
        score.globalResourceMulti /= moneyMultiRefund;
        score.globalTimeMulti /= timeMultiRefund;
        score.globalEventChance /= eventMultiRefund;
        score.globalTaxMulti /= taxMultiRefund;
        timeLine.eventChance /= eventMultiRefund;
        // multi managment
        currentRoom.baseTaxToPay = 0;
        currentRoom.NullTimer();
        currentRoom.UpdateMulti();
        currentRoom.UpdateSprite();
        // handle sprite update
        currentRoom.image = emptyImage;
        currentRoom.UpdateSprite();        
        // ui change
        upgradePanel.SetActive(false);
        buildPanel.SetActive(true);
        currentRoom.Select();
        int id = int.Parse(roomHandler.id);
        over.roomLabels[id] = "";
        animator.SetInteger("index", 0);
        hintInfo.SetActive(false);
    }
    public void ShowSellHint()
    {        
        int moneyRefund = 0;
        for (int i = 0; i < roomHandler.lvl; i++)
        {
            moneyRefund += roomList.Rooms[roomHandler.roomIndex].BuildCost[i];
        }
        int refund = Mathf.RoundToInt(moneyRefund * 0.3f);
        string hint = "За продажу комнаты можно получить " + refund + " контуриков";
        hintText.text = hint;
        hintInfo.SetActive(true);
    }
    public void HideSellHint()
    {
        hintInfo.SetActive(false);
    }
    public void ShowUpgradeInfo()
    {
        if (roomHandler.lvl < 3)
        {
            string hint = roomList.Rooms[roomHandler.roomIndex].Description[roomHandler.lvl];
            hintText.text = hint;
            hintInfo.SetActive(true);
        }
    }
    public void HideUpgradeInfo()
    {
        hintInfo.SetActive(false);
    }
    public void DisplayDescription(int id)
    {
        labelText.text = roomList.Rooms[id].Label;
        descriptionText.text = roomList.Rooms[id].Description[0];
        costText.text = Mathf.RoundToInt(roomList.Rooms[id].BuildCost[0]).ToString() + " контуриков";
        previewImage.sprite = roomList.Rooms[id].Image[0];
    }
}
