using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaking : MonoBehaviour
{
    int stage = 0;
    public void Awake()
    {
        List<List<int>> Map = new List<List<int>>();
        int[] size = { 5, 50, 6, 7 };
        int[] way = { 6, 200, 9, 12 };
        int[] mapevent = { 3, 30, 5, 6 };
        int[] mapshop = { 3, 50, 1, 2 };

        int startx = Random.Range(0, size[stage] - 1);
        int starty = Random.Range(0, size[stage] - 1);

       makebasicmap(size[stage], way[stage], mapevent[stage], mapshop[stage], startx, starty, Map);
    }

    public void makebasicmap(int size, int way, int mapevent, int mapshop, int startx, int starty, List<List<int>> Map) //비어있는 맵 만들기
    {
        for (int i = 0; i < size; i++)
        {
            Map.Add(new List<int>());
            for (int j = 0; j < size; j++)
            {
                Map[i].Add(0);
            }
        }
        mapmake(size, way, mapevent, mapshop, startx, starty, Map);
    }
    public void mapmake(int size, int way, int mapevent, int mapshop, int startx, int starty, List<List<int>> Map)  //가로세로의 길이, 길 개수, 이벤트등을 인자로 받는다.
    {
        int maptile = 0;
        bool isdirsel = false; //방향선택확인
        bool istilesel = false;
        int dir;

        while (!istilesel)
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    if (way - 1 >= 0) //남아있는 way 가 있다면
                    {
                        maptile = 1;
                        way--;
                        istilesel = true;
                    }

                    break;

                case 2:
                    if (mapevent - 1 >= 0) //남아있는 mapevent 가 있다면
                    {
                        maptile = 2;
                        mapevent--;
                        istilesel = true;
                    }

                    break;
                case 3:
                    if (mapshop - 1 >= 0) //남아있는 mapshop 가 있다면
                    {
                        maptile = 3;
                        mapshop--;
                        istilesel = true;
                    }

                    break;
            }
        }
        int trynum = 0;

        while (true)
        {
            if (trynum > 20)
            {
                resetpoint(size, way, mapevent, mapshop, startx, starty, Map);
            }
            try
            {
                dir = Random.Range(1, 5); //1234가 나옴 상하좌우 순서
                switch (dir)
                {
                    case 1:
                        if (Map[startx + 1][starty] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[startx + 1][starty] = maptile;
                            startx++;
                            isdirsel = true;
                            break;
                        }
                    case 2:
                        if (Map[startx - 1][starty] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[startx - 1][starty] = maptile;
                            startx--;
                            isdirsel = true;
                            break;
                        }
                    case 3:
                        if (Map[startx][starty - 1] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[startx][starty - 1] = maptile;
                            starty--;
                            isdirsel = true;
                            break;
                        }
                    case 4:
                        if (Map[startx][starty + 1] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[startx][starty + 1] = maptile;
                            starty++;
                            isdirsel = true;
                            break;
                        }
                }
                if (isdirsel)
                {
                    trynum++;
                    break;
                }

            }
            catch
            {
                continue;
            }
        }
        if (way == 0 && mapevent == 0 && mapshop == 0)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Debug.Log(Map[i][j]);
                }
                Debug.LogError("");
            }
        }
        else
        {
            mapmake(size, way, mapevent, mapshop, startx, starty, Map);   //재귀로 구현 근데 메모리 문제 심하면 리펙토링(지금 해라)
        }
    }
    public void resetpoint(int size, int way, int mapevent, int mapshop, int startx, int starty, List<List<int>> Map)
    {
        while (true)
        {
            startx = Random.Range(0, size - 1);
            starty = Random.Range(0, size - 1);
            bool isconnect = false;

            if (Map[startx][starty] == 0)
            {
                if (startx - 1 > 0)
                {
                    if (Map[startx - 1][starty] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (startx + 1 <= size - 1)
                {
                    if (Map[startx + 1][starty] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (starty + 1 <= size - 1)
                {
                    if (Map[startx][starty + 1] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (starty - 1 > 0)
                {
                    if (Map[startx][starty - 1] != 0)
                    {
                        isconnect = true;
                    }
                }
                else
                {
                    continue;
                }
                break;
            }
            if (!isconnect)  //연결된 곳이 없을때
            {
                continue;
            }
            else
            {
                break;
            }
        }
        mapmake(size, way, mapevent, mapshop, startx, starty, Map);
    }
}
