using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStat : MonoBehaviour
{
    public string label;
    public int lvl;

    public RoomStat()
    {

    }
    public RoomStat(string label, int lvl)
    {
        this.label = label;
        this.lvl = lvl;
    }  
}
