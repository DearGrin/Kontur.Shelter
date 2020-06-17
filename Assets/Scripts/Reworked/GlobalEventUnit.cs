using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Global Event Unit", menuName = "Global Event Unit" + "", order = 54)]
public class GlobalEventUnit : ScriptableObject
{
    [SerializeField]
    private string label;
    [SerializeField]
    private string subject;
    [SerializeField]
    private string pros;
    [SerializeField]
    private string cons;
    /*
    [SerializeField]
    private string impactType;
    [SerializeField]
    private float prosValue;
    [SerializeField]
    private float consValue;
    [SerializeField]
    private float globalMoneyMulti = 1;
    [SerializeField]
    private float globalResourceMulti = 1;
    [SerializeField]
    private float globalTaxMulti = 1;
    [SerializeField]
    private float globalHappinessMulti = 1;
    [SerializeField]
    private float globalTimeMulti = 1;
    */
    //
    [SerializeField]
    private int moneyPros;
    [SerializeField]
    private int happinessPros;
    [SerializeField]
    private int productPros;
    [SerializeField]
    private float taxMultiPros;
    [SerializeField]
    private float timeMultiPros;
    [SerializeField]
    private float moneyMultiPros;
    [SerializeField]
    private int moneyCons;
    [SerializeField]
    private int happinessCons;
    [SerializeField]
    private int productCons;
    [SerializeField]
    private float taxMultiCons;
    [SerializeField]
    private float timeMultiCons;
    [SerializeField]
    private float moneyMultiCons;

    public string Label
    {
        get
        {
            return label;
        }
    }
    public string Subject
    {
        get
        {
            return subject;
        }
    }
    public string Pros
    {
        get
        {
            return pros;
        }
    }
    public string Cons
    {
        get
        {
            return cons;
        }
    }
    public int MoneyPros
    {
        get
        {
            return moneyPros;
        }
    }
    public int HappinessPros
    {
        get
        {
            return happinessPros;
        }
    }
    public int ProductPros
    {
        get
        {
            return productPros;
        }
    }
    public float TaxMultiPros
    {
        get
        {
            return taxMultiPros;
        }
    }
    public float TimeMultiPros
    {
        get
        {
            return timeMultiPros;
        }
    }
    public float MoneyMultiPros
    {
        get
        {
            return moneyMultiPros;
        }
    }
    public int MoneyCons
    {
        get
        {
            return moneyCons;
        }
    }
    public int HappinessCons
    {
        get
        {
            return happinessCons;
        }
    }
    public int ProductCons
    {
        get
        {
            return productCons;
        }
    }
    public float TaxMultiCons
    {
        get
        {
            return taxMultiCons;
        }
    }
    public float TimeMultiCons
    {
        get
        {
            return timeMultiCons;
        }
    }
    public float MoneyMultiCons
    {
        get
        {
            return moneyMultiCons;
        }
    }

    /*
    public float GlobalMoneyMulti
    {
        get
        {
            return globalMoneyMulti;
        }
    }
    public float GlobalResourceMulti
    {
        get
        {
            return globalResourceMulti;
        }
    }
    public float GlobalTaxMulti
    {
        get
        {
            return globalTaxMulti;
        }
    }
    public float GlobaHappinessMulti
    {
        get
        {
            return globalHappinessMulti;
        }
    }
    public float GlobalTimeMulti
    {
        get
        {
            return globalTimeMulti;
        }
    }
    public float ProsValue
    {
        get
        {
            return prosValue;
        }
    }
    public float ConsValue
    {
        get
        {
            return consValue;
        }
    }
    public string ImpactType
    {
        get
        {
            return impactType;
        }
    }
    */
}
