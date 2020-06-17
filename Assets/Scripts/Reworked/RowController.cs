using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> row;
    [SerializeField]
    private bool isUnlocked = false;
    [SerializeField]
    private GameObject lockPanel;
    [SerializeField]
    private int unlockCost;
    [SerializeField]
    private Score score;
    [SerializeField]
    private GameObject unlockDialog;
    [SerializeField]
    private RowController prevRow;


    public void OpenDialog()
    {
        if (prevRow.isUnlocked == true)
        {
            unlockDialog.SetActive(true);
        }
    }
    public void Unlock()
    {
        
            if (score.money >= unlockCost)
            {
                lockPanel.SetActive(false);
                unlockDialog.SetActive(false);
                score.MoneyOperation(-unlockCost);
                foreach (var room in row)
                {
                    room.SetActive(true);
                }
                isUnlocked = true;
            }
            else
            {
                // no money Alert
            }
        
    }    

    public void RefreshInfo()
    {
        // next item
        for (int n = 0; n<row.Count; n++)
        {

        }
        // row[n] current item
        // if ((n-1)>=0) row[n-1].Count left item
        // if ((n+1)<=row.Length) row[n+1].Count right item
    }

}
