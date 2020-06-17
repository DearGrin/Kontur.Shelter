using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine : MonoBehaviour
{
    [System.Serializable]
    private class BreakPoint
    {
        public List<GlobalEventUnit> breakpoint;
    }
    [System.Serializable]
    private class ListofBreakPoints
    {
        public List<BreakPoint> listOfPoints;
    }
    [SerializeField]
    private ListofBreakPoints allpoints;
    [SerializeField]
    private float gameTime = 0;
    [SerializeField]
    public float currrentTime;
    [SerializeField]
    private int breakpointCount = 0;
    [SerializeField]
    private List<float> breakpointTime;
     
    [SerializeField]
    private GameEvent taxes;
    [SerializeField]
    private List<string> months;
    [SerializeField]
    private float currentMonth = 1;
    [SerializeField]
    private float lastMonth = 1;
    [SerializeField]
    private float currentYear;
    [SerializeField]
    private float yearCount = 0;
    [SerializeField]
    private float secInMonht;
    [SerializeField]
    private float endGameTime;
    [SerializeField]
    private GameEvent endGame;
    [SerializeField]
    private Text dateText;
    [SerializeField]
    private Text subjectEvent;
    [SerializeField]
    private Text causeEvent;
    [SerializeField]
    private Text impactEvent;
    [SerializeField]
    private GameObject eventPanel;
    [SerializeField]
    private TimeControl timeControl;
    [SerializeField]
    private Score score;
    [SerializeField]
    public float eventChance = 40;
    [SerializeField]
    private bool isOver = false;
    [SerializeField]
    private GameEvent eventSound;
    private string moneytext;
    private string happytext;
    private string producttext;
    private string timemultitext;
    private string taxmultitext;
    private string moneymultitext;
    private int eventIndex;

 

    void Update()
    {
        gameTime += Time.deltaTime;
        currrentTime = Mathf.Round(gameTime);
                
        #region BreakPoint
        if(breakpointCount < breakpointTime.Count)
        {
            
            if (breakpointTime[breakpointCount] == currrentTime)
            {
                eventSound.Raise();
                breakpointCount += 1;
                eventIndex = Random.Range(0, allpoints.listOfPoints[breakpointCount-1].breakpoint.Count);
                Debug.Log("event!!! + " + breakpointCount);
                timeControl.Pause();
                eventPanel.SetActive(true);
                subjectEvent.text = allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].Subject;

                int e = Random.Range(0, 100);
                if (e <= eventChance)
                {
                    causeEvent.text = allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].Pros;
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyPros == 0)
                    {
                        moneytext = "";
                    }
                    else
                    {
                        moneytext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyPros.ToString() + " контуриков";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].HappinessPros == 0)
                    {
                        happytext = "";
                    }
                    else
                    {
                        happytext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].HappinessPros.ToString() + " счастья";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].ProductPros == 0)
                    {
                        producttext = "";
                    }
                    else
                    {
                        producttext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].ProductPros.ToString() + " продукта";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiPros == 1)
                    {
                        timemultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiPros < 1)
                        {
                            timemultitext = Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiPros * 100)).ToString() + "%" + " производительности";
                        }
                        else
                        {
                            timemultitext = "-" + System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiPros * 100) - 100),2).ToString() + "%" + " производительности";
                        }
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiPros == 1)
                    {
                        taxmultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiPros < 1)
                        {
                            taxmultitext = Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiPros * 100)).ToString() + "%" + " снижение издержек";
                        }
                        else
                        {
                            taxmultitext = System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiPros * 100) - 100),2).ToString() + "%" + " рост издержек";
                        }
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiPros == 1)
                    {
                        moneymultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiPros > 1)
                        {
                            moneymultitext = System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiPros * 100) - 100),2).ToString() + "%" + " к доходу";
                        }
                        else
                        {
                            moneymultitext = "-" + Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiPros * 100)).ToString() + "%" + " к доходу";
                        }
                    }

                    impactEvent.text = "Эффект: " + moneytext + " " + happytext + " " + producttext + " " + timemultitext + " " + taxmultitext + " " + moneymultitext;

                    score.MoneyOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].MoneyPros);
                    score.HappinessOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].HappinessPros);
                    score.ProductOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].ProductPros);
                    score.TimeMultiOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].TimeMultiPros);
                    score.TaxMultiOperatiom(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].TaxMultiPros);
                    score.ResourceMultiOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].MoneyMultiPros);
                }
                else
                {
                    causeEvent.text = allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].Cons;
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyCons == 0)
                    {
                        moneytext = "";
                    }
                    else
                    {
                        moneytext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyCons.ToString() + " контуриков";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].HappinessCons == 0)
                    {
                        happytext = "";
                    }
                    else
                    {
                        happytext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].HappinessCons.ToString() + " счастья";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].ProductCons == 0)
                    {
                        producttext = "";
                    }
                    else
                    {
                        producttext = allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].ProductCons.ToString() + " продукта";
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiCons == 1)
                    {
                        timemultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiCons > 1)
                        {
                            timemultitext = "-" + System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiCons * 100) - 100),2).ToString() + "%" + " производительности";
                        }
                        else
                        {
                            timemultitext = Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TimeMultiCons * 100)).ToString() + "%" + " производительности";
                        }
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiCons == 1)
                    {
                        taxmultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiCons < 1)
                        {
                            taxmultitext = Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiCons * 100)).ToString() + "%" + " снижение издержек";
                        }
                        else
                        {
                            taxmultitext = System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].TaxMultiCons * 100) - 100),2).ToString() + "%" + " рост издержек";
                        }
                    }
                    if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons == 1)
                    {
                        moneymultitext = "";
                    }
                    else
                    {
                        if (allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons > 1)
                        {
                            Debug.Log(allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons + "/// " + System.Math.Round((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons-1),2));
                           
                            moneymultitext = System.Math.Round(((allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons - 1) * 100),2).ToString() + "%" + " к доходу";
                        }
                        else
                        {
                            moneymultitext = "-" + Mathf.Round((100 - allpoints.listOfPoints[breakpointCount - 1].breakpoint[eventIndex].MoneyMultiCons * 100)).ToString() + "%" + " к доходу";
                        }
                    }

                    impactEvent.text = "Эффект: " + moneytext + " " + happytext + " " + producttext + " " + timemultitext + " " + taxmultitext + " " + moneymultitext;

                    score.MoneyOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].MoneyCons);
                    score.HappinessOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].HappinessCons);
                    score.ProductOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].ProductCons);
                    score.TimeMultiOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].TimeMultiCons);
                    score.TaxMultiOperatiom(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].TaxMultiCons);
                    score.ResourceMultiOperation(allpoints.listOfPoints[breakpointCount-1].breakpoint[eventIndex].MoneyMultiCons);
                  
                }
            }
            
        }
        #endregion

        #region Clock
        // Clock ticking
        
            if (currrentTime - 12 * secInMonht * (yearCount+1) > 0)
            {
                yearCount++;
            }
        
        currentMonth = Mathf.Floor((currrentTime - 12*secInMonht*yearCount)/secInMonht);
        currentYear = 1988 + yearCount;

        // show current date
        if(currentMonth == 12)
        {
            dateText.text = months[0] + " " + currentYear.ToString();
        }
        else
        {
            dateText.text = months[Mathf.RoundToInt(currentMonth)] + " " + currentYear.ToString();
        }

        // collect taxes event
        if (lastMonth != currentMonth)
        {
            taxes.Raise();
            lastMonth = currentMonth;
        }



        // End Game
        if (currrentTime >= endGameTime)
        {
            if (isOver == false)
            {
                Debug.Log("end game");
                isOver = true;
                endGame.Raise();
            }
        }
        #endregion

    }
}
