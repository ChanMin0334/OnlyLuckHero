using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTile : MonoBehaviour
{
    static int nowx;
    static int nowy;
    static int size;
    public Button leftBtn;
    public Button rightBtn;
    public Button upBtn;
    public Button downBtn;
    static public List<List<int>> Map;
    public void setting(int x, int y, int si, List<List<int>> map)   //전역변수로 저장해줌
    {
        leftBtn = GameObject.Find("Left_btn").GetComponent<Button>();
        rightBtn = GameObject.Find("Right_btn").GetComponent<Button>();
        upBtn = GameObject.Find("Up_btn").GetComponent<Button>();
        downBtn = GameObject.Find("Down_btn").GetComponent<Button>();
        Map = map;
        nowx = x;
        nowy = y;
        size = si;
        stay();
    }
    public void stay()
    {
        leftBtn = GameObject.Find("Left_btn").GetComponent<Button>();
        rightBtn = GameObject.Find("Right_btn").GetComponent<Button>();
        upBtn = GameObject.Find("Up_btn").GetComponent<Button>();
        downBtn = GameObject.Find("Down_btn").GetComponent<Button>();

        Debug.Log(nowy + "/" + nowx);    //테스트 디버깅 코드
        var srt = "";
        for (int i = 0; i < size; i++)
        {
            srt = "|";
            for (int j = 0; j < size; j++)
            {
                srt += (Map[i][j] + "|");
            }
            Debug.Log(srt);
        }                               //테스트 디버깅 코드

        bool isLeftTile = false;
        bool isRightTile = false;
        bool isUpTile = false;
        bool isDownTile = false;

        if (nowy - 1 >= 0)
        {
            if (Map[nowx][nowy - 1] != 0)
                isLeftTile = true;
            else
                isLeftTile = false;
        }
        else
            isLeftTile = false;

        if (nowy + 1 <= size - 1)
        {
            if (Map[nowx][nowy + 1] != 0)
                isRightTile = true;
            else
                isRightTile = false;
        }
        else
            isRightTile = false;

        if (nowx - 1 >= 0)
        {
            if (Map[nowx - 1][nowy] != 0)
                isUpTile = true;
            else
                isUpTile = false;
        }
        else
            isUpTile = false;

        if (nowx + 1 <= size - 1)
        {
            if (Map[nowx + 1][nowy] != 0)
                isDownTile = true;
            else
                isDownTile = false;
        }
        else
            isDownTile = false;

        if (isUpTile)           //위쪽버튼활성화
        {
            upBtn.interactable = true;
            upBtn.gameObject.GetComponent<Image>().enabled = true;
        }
        else if (!isUpTile)
        {
            upBtn.interactable = false;   //위쪽버튼비활성화
            upBtn.gameObject.GetComponent<Image>().enabled = false;
        }

        if (isDownTile)
        {
            downBtn.interactable = true; //아래버튼활성화
            downBtn.gameObject.GetComponent<Image>().enabled = true;
        }
        else if (!isDownTile)
        {
            downBtn.interactable = false;   //아래버튼비활성화
            downBtn.gameObject.GetComponent<Image>().enabled = false;
        }

        if (isLeftTile)
        {
            leftBtn.interactable = true;  // 왼쪽버튼활성화
            leftBtn.gameObject.GetComponent<Image>().enabled = true;
        }
        else if (!isLeftTile)
        {
            leftBtn.interactable = false;   //왼쪽버튼비활성화
            leftBtn.gameObject.GetComponent<Image>().enabled = false;
        }

        if (isRightTile)
        {
            rightBtn.interactable = true;  //오른쪽버튼활성화
            rightBtn.gameObject.GetComponent<Image>().enabled = true;
        }
        else if (!isRightTile)
        {
            rightBtn.interactable = false;   //오른쪽버튼비활성화
            rightBtn.gameObject.GetComponent<Image>().enabled = false;
        }


        if (isUpTile)
        {
            if (isRightTile)
            {
                if (isDownTile)
                {
                    if (isLeftTile)
                    {
                        //15번
                    }
                    else
                    {
                        //11번
                    }
                }
                else if (isLeftTile)
                {
                    //14번
                }
                else
                {
                    //5번
                }
            }
            else if (isDownTile)
            {
                if (isLeftTile)
                {
                    //13번
                }
                else
                {
                    //9번
                }
            }
            else if (isLeftTile)
            {
                //8번
            }
            else
            {
                //1번
            }
        }
        else if (isDownTile)
        {
            if (isRightTile)
            {
                if (isLeftTile)
                {
                    //12번
                }
                else
                {
                    //6번
                }
            }
            else if (isLeftTile)
            {
                //7번
            }
            else
            {
                //2번
            }
        }
        else if (isLeftTile)
        {
            if (isRightTile)
            {
                //10번
            }
            else
            {
                //3번
            }
        }
        else if (isRightTile)
        {
            //4번
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
