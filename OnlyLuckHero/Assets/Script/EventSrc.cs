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
        if (map[x][y] != 1)
        {
            mapcanvas.SetActive(false);
            eventcanvas.SetActive(true);
        }
    }
    public void ClearCheck()
    {
        mapcanvas.SetActive(true);
        eventcanvas.SetActive(false);
        movetile.Stay();
    }
}
