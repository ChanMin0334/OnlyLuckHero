using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaking : MonoBehaviour
{   
    public int[,] map = new int[100, 100];
    static void Main(string[] args)  //지금은 Main메소드이지만 나중에는 다른 메소드로 바꾼후 다른 클래스에서 호출하는 방식으로 할 것
    {
        int size = 4;
        int way = 5;
        int mapevent = 2;
        int mapshop = 1;

        MapMaking mapmaking = new MapMaking();
        mapmaking.mapmake(size, way, mapevent, mapshop); //맵메이킹 테스트 나중에는 맵크기와 모든것을 배열로 관리후 각 스테이지에 맞게 배분
    }
    public void mapmake(int size,int way,int mapevent,int mapshop)  //가로세로의 길이, 길 개수, 이벤트등을 인자로 받는다.
    {

    }
  
}
