using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room List", menuName = "New Room List" + "", order = 54)]
public class NewRoomList : ScriptableObject
{
    [SerializeField]
    private List<NewRoom> rooms;

    public List<NewRoom> Rooms
    {
        get
        {
            return rooms;
        }
    }
}
