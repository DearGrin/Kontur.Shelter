using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomProperty : MonoBehaviour
{
    #region Properties
    // set up prop from build\upgrade
    [SerializeField]
    public string label;
    [SerializeField]
    public string description;
    [SerializeField]
    public int lvl;
    [SerializeField]
    public string resourceType;
    [SerializeField]
    public int roomIndex;
    // base values resoureces 
    [SerializeField]
    public int baseResorceGenerate;
    [SerializeField]
    public float baseTimeGenerate;
    [SerializeField]
    public int baseTaxToPay;
    [SerializeField]
    public int productConsume;
    [SerializeField]
    public int costBuild; // do we need it?
    // calculated resources
    [SerializeField]
    private int resourceAmountGenerate;
    [SerializeField]
    private int timeToGenerate;
    [SerializeField]
    public int taxToPay;
    //local Multi
    [SerializeField]
    public float localTimeMulti;
    [SerializeField]
    public float localTaxMulti;
    [SerializeField]
    public float localResoureceMulti;
   /*
    // global Multi
    [SerializeField]
    private float globalTaxMulti = 1;
    [SerializeField]
    private float globalResourceMulti = 1;
    [SerializeField]
    private float globalHappinessMulti = 1;
    [SerializeField]
    private float globalTimeMulti = 1;
    [SerializeField]
    public float eventMulti = 0;
    */
    // time
    [SerializeField]
    public float leftTimer;
    // bool managment
    [SerializeField]
    private bool isProductionComplete = false;
    [SerializeField]
    public bool isEmpty = true;
    [SerializeField]
    private bool isSelected = false;
    [SerializeField]
    private bool hasPaid = false;
    // Sprite
    [SerializeField]
    public Sprite image;
    // Game Events
    [SerializeField]
    private GameEvent check;
    #endregion

    #region References
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject upgradePanel;
    [SerializeField]
    private Text resourceTimer;
    [SerializeField]
    private GameObject resourceIconComplete;   
    [SerializeField]
    private Score score;
    [SerializeField]
    private RoomHandler controller;
    [SerializeField]
    private SpriteRenderer border1;
    [SerializeField]
    private SpriteRenderer border2;
    [SerializeField]
    private SpriteRenderer border3;
    [SerializeField]
    private SpriteRenderer border4;
    [SerializeField]
    private GameEvent incomeEvent;
    [SerializeField]
    private GameOver over;
    // [SerializeField]
    //private GameObject GameController;    
    //[SerializeField]
    //private GameObject scoreController;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
     //   controller = GameController.GetComponent<RoomHandler>();
     //   score = scoreController.GetComponent<Score>();
        leftTimer = timeToGenerate;
        UpdateMulti();
        Animator anim = GetComponent<Animator>();
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        anim.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        #region Resourece Production timer
        // Resource Production
        if (isEmpty == false)
        {
            if (timeToGenerate > 0)
            {
                if (isProductionComplete == false)
                {
                    if (resourceType == "product")
                    {
                        leftTimer -= Time.deltaTime;
                        if (leftTimer <= 0)
                        {
                            isProductionComplete = true;
                        }
                    }
                    else
                    {
                        if (hasPaid == false)
                        {
                            if (score.product >= productConsume)
                            {
                                score.ProductOperation(-productConsume);
                                hasPaid = true;
                            }
                        }
                        else
                        {
                            leftTimer -= Time.deltaTime;
                            if (leftTimer <= 0)
                            {
                                isProductionComplete = true;
                                hasPaid = false;
                            }
                        }

                    }
                }
                else
                {
                    ResourceReady();
                }
                /*
                if (isSelected)
                {
                    controller.leftTimer = Mathf.Round(leftTimer);
                }
                */
            }
        }
        if(isSelected == true)
        {
            controller.leftTimer = Mathf.Round(leftTimer);
           
        }
      
        #endregion

    }

    private void PassData()
    {        
        controller.label = label;
        controller.description = description;
        controller.lvl = lvl;
        controller.leftTimer = Mathf.Round(leftTimer);        
        controller.id = gameObject.name;
        controller.roomIndex = roomIndex;

        //  controller.isUpgradeable = isUpgradeable;
        //   controller.roomToUpgrade = roomToUpgrade;
       // controller.costBuild = costBuild;
        
        
         
    }
    
    // Resourece is Ready
    private void ResourceReady()
    {
        isProductionComplete = true;
        resourceIconComplete.SetActive(true);
    }

    // Get Income
    private void GatherResource()
    {
        ResourceToGenerate();
        TimeNeededToGenerate();
        isProductionComplete = false;
        resourceIconComplete.SetActive(false);
        leftTimer = timeToGenerate;
        if(resourceType == "money")
        {
            score.MoneyOperation(resourceAmountGenerate);
            over.totalMoney += resourceAmountGenerate;
            Debug.Log(resourceAmountGenerate);
        }
        else if (resourceType == "product")
        {
            score.ProductOperation(resourceAmountGenerate);
            over.totalProduct += resourceAmountGenerate;
            Debug.Log(resourceAmountGenerate);
        }
        incomeEvent.Raise();
    }
    public void NullTimer()
    {
        isProductionComplete = false;
        resourceIconComplete.SetActive(false);
        leftTimer = timeToGenerate;
    }

    // Pay Tax
    public void PayTaxes()
    {
        Debug.Log("Lets pay taxes");
        score.MoneyOperation(-taxToPay);
        over.totalTax += taxToPay;
        TaxToPay();
    }

    // Economy Calculations with Multi
    private void ResourceToGenerate()
    {
        Debug.Log("base " + baseResorceGenerate + "gmulti " + score.globalResourceMulti + "lMulti" + localResoureceMulti + "hap " + score.happiness);
        if (score.happiness < 100)
        {
            resourceAmountGenerate = Mathf.RoundToInt(baseResorceGenerate * score.globalResourceMulti * localResoureceMulti * score.happiness / 100);
            Debug.Log(resourceAmountGenerate + " total");
        }
        else
        {
            resourceAmountGenerate = Mathf.RoundToInt(baseResorceGenerate * score.globalResourceMulti * localResoureceMulti);
            Debug.Log(resourceAmountGenerate + " total");
        }
    }
    private void TimeNeededToGenerate()
    {
        if (score.happiness < 100)
        {
            timeToGenerate = Mathf.RoundToInt(baseTimeGenerate * score.globalTimeMulti * localTimeMulti / score.happiness * 100);
        }
        else
        {
            timeToGenerate = Mathf.RoundToInt(baseTimeGenerate * score.globalTimeMulti * localTimeMulti);
        }
    }
    private void TaxToPay()
    {
        int prevTax = taxToPay;
        taxToPay = Mathf.RoundToInt(baseTaxToPay * score.globalTaxMulti * localTaxMulti);
        score.MoneyTaxOperation(taxToPay-prevTax);
    }

    public void UpdateMulti()
    {
        ResourceToGenerate();
        TimeNeededToGenerate();
        TaxToPay();
    }
    /*
    // Recive Global Change Multi Event
    public void ChangeGlobalTaxMulti()
    {
        globalTaxMulti = score.globalTaxMulti;
        TaxToPay();
    }
    public void ChangeResourceTaxMulti()
    {
        globalResourceMulti = score.globalResourceMulti;
        ResourceToGenerate();
    }
    public void ChangeHappinessTaxMulti()
    {
        globalHappinessMulti = score.globalHappinessMulti;
    }
    public void ChangeGlobalTimeMulti()
    {
        globalTimeMulti = score.globalTimeMulti;
        TimeNeededToGenerate();
    }
    */
    // Recieve Select Event
    public void Select()
    {
        if (isProductionComplete == true)
        {
            GatherResource();
        }
        else
        {
                if (isEmpty == true)
                {
                    buildPanel.SetActive(true);
                    controller.id = gameObject.name;
                    upgradePanel.SetActive(false);
            }
                else
                {
                    PassData();
                    upgradePanel.SetActive(true);
                    buildPanel.SetActive(false);
            }
            check.Raise();
        }
    }

    // Selection check (only is active select)
   public void CheckSelect()
   {
        string id = controller.id;
        if (gameObject.name == id)
        {
            isSelected = true;
            border1.color = Color.green;
            border2.color = Color.green;
            border3.color = Color.green;
            border4.color = Color.green;
        }
        else
        {            
            isSelected = false;
            border1.color = Color.white;
            border2.color = Color.white;
            border3.color = Color.white;
            border4.color = Color.white;
        }
   }
    public void UpdateSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = image;
    }
}
