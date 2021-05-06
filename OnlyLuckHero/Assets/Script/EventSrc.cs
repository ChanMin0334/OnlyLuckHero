using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSrc : MonoBehaviour
{
    public MoveTile movetile;
    public GameObject eventcanvas;
    public GameObject mapcanvas;

    public void Event_check(List<List<int>> map, int x, int y)
    {   
        mapcanvas.SetActive(false);
        eventcanvas.SetActive(true);      
    }
}
