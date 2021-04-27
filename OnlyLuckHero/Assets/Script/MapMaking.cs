using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaking : MonoBehaviour
{
    static public int stage = 0;
    public int[] size = { 5, 10, 6, 7 };
    int[] way = { 6, 50, 9, 12 };
    int[] mapevent = { 3, 10, 5, 6 };
    int[] mapshop = { 3, 5, 1, 2 };
    public List<List<int>> Map;
    public MoveTile move;

    public void Awake()
    {
        Map = new List<List<int>>();

        int tilex = Random.Range(0, size[stage] - 1);
        int tiley = Random.Range(0, size[stage] - 1);

        Makebasicmap(size[stage], way[stage], mapevent[stage], mapshop[stage], tilex, tiley, Map);
    }

    public void Makebasicmap(int size, int way, int mapevent, int mapshop, int x, int y, List<List<int>> Map) //비어있는 맵 만들기
    {
        for (int i = 0; i < size; i++)
        {
            Map.Add(new List<int>());
            for (int j = 0; j < size; j++)
            {
                Map[i].Add(0);
            }
        }
        Mapmake(size, way, mapevent, mapshop, x, y, Map);
    }
    public void Mapmake(int size, int way, int mapevent, int mapshop, int x, int y, List<List<int>> Map)  //가로세로의 길이, 길 개수, 이벤트등을 인자로 받는다.
    {
        int maptile = 0;
        bool isdirsel = false; //방향선택확인
        bool istilesel = false;
        int dir;
        int trynum = 0;

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
        trynum = 0;

        while (true)
        {
            if (trynum > 20)
            {
                Resetpoint(size, way, mapevent, mapshop, x, y, Map);
            }
            try
            {
                dir = Random.Range(1, 5); //1234가 나옴 상하좌우 순서
                switch (dir)
                {
                    case 1:
                        if (Map[x + 1][y] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[x + 1][y] = maptile;
                            x++;
                            isdirsel = true;
                            break;
                        }
                    case 2:
                        if (Map[x - 1][y] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[x - 1][y] = maptile;
                            x--;
                            isdirsel = true;
                            break;
                        }
                    case 3:
                        if (Map[x][y - 1] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[x][y - 1] = maptile;
                            y--;
                            isdirsel = true;
                            break;
                        }
                    case 4:
                        if (Map[x][y + 1] != 0)
                        {
                            trynum++;
                            break;
                        }
                        else
                        {
                            Map[x][y + 1] = maptile;
                            y++;
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
            Makestart(size, Map);
        }
        else
        {
            Mapmake(size, way, mapevent, mapshop, x, y, Map);   //재귀로 구현 근데 메모리 문제 심하면 리펙토링
        }
    }
    public void Resetpoint(int size, int way, int mapevent, int mapshop, int x, int y, List<List<int>> Map)
    {
        while (true)
        {
            x = Random.Range(0, size - 1);
            y = Random.Range(0, size - 1);
            bool isconnect = false;

            if (Map[x][y] == 0)
            {
                if (x - 1 > 0)
                {
                    if (Map[x - 1][y] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (x + 1 <= size - 1)
                {
                    if (Map[x + 1][y] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (y + 1 <= size - 1)
                {
                    if (Map[x][y + 1] != 0)
                    {
                        isconnect = true;
                    }
                }
                else if (y - 1 > 0)
                {
                    if (Map[x][y - 1] != 0)
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
        Mapmake(size, way, mapevent, mapshop, x, y, Map);
    }
    public void Makestart(int size, List<List<int>> Map)
    {
        bool isselect = false;
        int startx = 0;
        int starty = 0;
        while (!isselect)
        {
            startx = Random.Range(0, size - 1);
            starty = Random.Range(0, size - 1);

            if (Map[startx][starty] != 0)
            {
                isselect = true;
            }
        }

        move.Setting(startx, starty, size, Map);
    }
}
