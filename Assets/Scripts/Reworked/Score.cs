using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    public int money = 1000;
    [SerializeField]
    public int product = 150;
    [SerializeField]
    public int happiness = 90;
    [SerializeField]
    public int moneyTax;
    [SerializeField]
    public float globalTimeMulti = 1;
    [SerializeField]
    public float globalResourceMulti = 1;
    [SerializeField]
    public float globalTaxMulti = 1;
    [SerializeField]
    public float globalHappinessMulti = 1;
    [SerializeField]
    public float globalBuildMulti = 1;
    [SerializeField]
    public float globalEventChance = 1;
  
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Text productText;
    [SerializeField]
    private Text happinessText;
    [SerializeField]
    private Text moneyTaxText;
    [SerializeField]
    private GameEvent gameOver;
    [SerializeField]
    private bool isAlerted = false;
    [SerializeField]
    private GameObject alertPanel;
    [SerializeField]
    private bool isOver = false;
   

    private void Update()
    {
        #region Display
        moneyText.text = money.ToString();
        productText.text = product.ToString();
        happinessText.text = happiness.ToString();
        moneyTaxText.text = moneyTax.ToString();
        #endregion
        // check for minus money
        if(money < 0)
        {
            moneyText.color = Color.red;
            if(isAlerted == false)
            {
                isAlerted = true;
                alertPanel.SetActive(true);
            }
        }
        else
        {
            moneyText.color = Color.blue;
            if (isAlerted == true)
            {
                isAlerted = false;
                alertPanel.SetActive(false);
            }
        }

        if(money < -1000)
        {
            if (isOver == false)
            {
                Debug.Log("Game over money");
                isOver = true;
                gameOver.Raise();
            }
        }

    }

    #region Score Operations
    public void MoneyOperation(int moneyValue)
    {
        money += moneyValue;
    }
    public void ProductOperation(int productValue)
    {
        product += productValue;
    }
    public void HappinessOperation(int happinessValue)
    {
        happiness += happinessValue;
    }
    public void MoneyTaxOperation(int tax)
    {
        moneyTax += tax;
    }

    #endregion
    #region Multi Operations
    public void MoneyMultiOperation(float multi)
    {
        globalTaxMulti *= multi;
    }
    public void ResourceMultiOperation(float multi)
    {
        globalResourceMulti *= multi;
    }
    public void HappinessMultiOperation(float multi)
    {
        globalHappinessMulti *= multi;
    }
    public void TimeMultiOperation(float multi)
    {
        globalTimeMulti *= multi;
    }
    public void TaxMultiOperatiom(float multi)
    {
        globalTaxMulti *= multi;
    }
    #endregion

}
