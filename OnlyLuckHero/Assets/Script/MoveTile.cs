using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTile : MonoBehaviour
{   
    private Sprite tileimage;
    private Image image;
    static int nowx;
    static int nowy;
    static int size;
    MapMaking mapdata;
    public Button leftbtn;
    public Button rightbtn;
    public Button upbtn;
    public Button downbtn;
    public void setting(int x, int y, int si)   //전역변수로 저장해줌
    {
        mapdata = GameObject.Find("Main Camera").GetComponent<MapMaking>();        
        leftbtn = GameObject.Find("Left_btn").GetComponent<Button>();
        rightbtn = GameObject.Find("Right_btn").GetComponent<Button>();
        upbtn = GameObject.Find("Up_btn").GetComponent<Button>();
        downbtn = GameObject.Find("Down_btn").GetComponent<Button>();
        nowx = x;
        nowy = y;
        size = si;
        stay();
    }
    public void stay() 
    {
        Debug.Log(nowy + "/" + nowx);
        leftbtn = GameObject.Find("Left_btn").GetComponent<Button>();
        rightbtn = GameObject.Find("Right_btn").GetComponent<Button>();
        upbtn = GameObject.Find("Up_btn").GetComponent<Button>();
        downbtn = GameObject.Find("Down_btn").GetComponent<Button>();
        //사진 불러오기
        //화살표 불러오기

        if (nowy - 1 >= 0)
        {
            /*if (mapdata.Map[nowx-1][nowy] != 0)
            {
                leftbtn.enabled = true;
                Debug.Log("왼쪽나타남");

            }
            else
            {
                leftbtn.enabled = false;
                Debug.Log("왼쪽사라짐");
            }*/
            leftbtn.interactable = true;
            Debug.Log("왼쪽나타남");
        }
        else if(nowy - 1 < 0)
        {
            leftbtn.interactable = false;
            Debug.Log("왼쪽사라짐");
        }
        if (nowy + 1 <= size-1)
        {
            /*if (mapdata.Map[nowx+1][nowy] != 0)
            {
                rightbtn.enabled = true;
                Debug.Log("오른쪽나타남");
            }
            else
            {
                rightbtn.enabled = false;
                Debug.Log("오른쪽사라짐");
            }*/
            rightbtn.interactable= true;
            Debug.Log("오른쪽나타남");
        }
        else if (nowy + 1 > size-1)
        {
            rightbtn.interactable = false;
            Debug.Log("오른쪽사라짐");
        }
        if (nowx - 1 >= 0)
        {
            /*if (mapdata.Map[nowx][nowy-1] != 0)
            {
                upbtn.enabled = true;
                Debug.Log("위쪽나타남");
            }
            else
            {
                upbtn.enabled = false;
                Debug.Log("위쪽사라짐");
            }*/
            upbtn.interactable = true;
            Debug.Log("위쪽나타남");
        }
        else if (nowx - 1 < 0)
        {
            upbtn.interactable = false;
            Debug.Log("위쪽사라짐");
        }
        if (nowx + 1 <= size -1)
        {
            /*if (mapdata.Map[nowx][nowy + 1] != 0)
            {
                downbtn.enabled = true;
                Debug.Log("아래쪽나타남");
            }
            else
            {
                downbtn.enabled = false;
                Debug.Log("아래쪽사라짐");
            }*/
            downbtn.interactable = true;
            Debug.Log("아래쪽나타남");
        }
        else if (nowx + 1 > size-1)
        {
            downbtn.interactable = false;
            Debug.Log("아래쪽사라짐");
        }
    }
    public void Leftmove()
    {
        nowy -= 1;
        stay();
    }
    public void Rightmove()
    {
        nowy += 1;
        stay();
    }
    public void Upmove()
    {
        nowx -= 1;
        stay();
    }
    public void Downmove()
    {
        nowx += 1;
        stay();
    }
}
