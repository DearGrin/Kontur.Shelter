using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "New Room" + "", order = 54)]
public class NewRoom : ScriptableObject
{
    [SerializeField]
    private string label;
    [SerializeField]
    private List<string> descripton;
    [SerializeField]
    private string resourceType;
    [SerializeField]
    private int roomIndex;
    [SerializeField]
    private List<int> animationIndex;
    [SerializeField]
    private int lvl;
    [SerializeField]
    private List<int> resource;
    [SerializeField]
    private List<int> productConsume;
    [SerializeField]
    private List<int> happiness;
    [SerializeField]
    private List<int> taxes;
    [SerializeField]
    private List<int> productionTime;
    [SerializeField]
    private List<int> buildCost;
    [SerializeField]
    private List<float> moneyMulti;
    [SerializeField]
    private List<float> timeMulti;
    [SerializeField]
    private List<float> eventMulti;
    [SerializeField]
    private List<float> taxMulti;
    [SerializeField]
    private List<float> localProductMulti;
    [SerializeField]
    private List<float> localMoneyMulti;
    [SerializeField]
    private List<float> localSupportMulti;
    [SerializeField]
    private List<Sprite> image;

    public string Label
    {
        get
        {
            return label;
        }
    }
    public List<string> Description
    {
        get
        {
            return descripton;
        }
    }
    public string ResourceType
    {
        get
        {
            return resourceType;
        }
    }
    public int RoomIndex
    {
        get
        {
            return roomIndex;
        }
    }
    public List<int> AnimationIndex
    {
        get
        {
            return animationIndex;
        }
    }
    

    public int Lvl
    {
        get
        {
            return lvl ;
        }
    }
    public List<int> Resource
    {
        get
        {
            return resource;
        }
    }
    public List<int> ProductConsume
    {
        get
        {
            return productConsume;
        }
    }
    public List<int> Happiness
    {
        get
        {
            return happiness;
        }
    }
    public List<int> Taxes
    {
        get
        {
            return taxes;
        }
    }
    public List<int> ProductionTime
    {
        get
        {
            return productionTime;
        }
    }
    public List<int> BuildCost
    {
        get
        {
            return buildCost;
        }
    }
    public List<float> MoneyMulti
    {
        get
        {
            return moneyMulti;
        }
    }
    public List<float> TimeMulti
    {
        get
        {
            return timeMulti;
        }
    }
    public List<float> EventMulti
    {
        get
        {
            return eventMulti;
        }
    }
    public List<float> TaxMulti
    {
        get
        {
            return taxMulti;
        }
    }
    public List<float> LocalProductMulti
    {
        get
        {
            return LocalProductMulti;
        }
    }
    public List<float> LocalMoneyMulti
    {
        get
        {
            return localMoneyMulti;
        }
    }
    public List<float> LocalSupportMulti
    {
        get
        {
            return localSupportMulti;
        }
    }
    public List<Sprite> Image
    {
        get
        {
            return image;
        }
    }
}
