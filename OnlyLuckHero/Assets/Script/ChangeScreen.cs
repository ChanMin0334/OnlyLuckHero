using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    public Sprite tile1;
    public Sprite tile2;
    public Sprite tile3;
    public Sprite tile4;
    public Sprite tile5;
    public Sprite tile6;
    public Sprite tile7;
    public Sprite tile8;
    public Sprite tile9;
    public Sprite tile10;
    public Sprite tile11;
    public Sprite tile12;
    public Sprite tile13;
    public Sprite tile14;
    public Sprite tile15;
    public Image background;

    public void changetile(int tilenum)
    {
        switch (tilenum)
        {
            case 1:
                background.sprite = tile1;
                break;
            case 2:
                background.sprite = tile2;
                break;
            case 3:
                background.sprite = tile3;
                break;
            case 4:
                background.sprite = tile4;
                break;
            case 5:
                background.sprite = tile5;
                break;
            case 6:
                background.sprite = tile6;
                break;
            case 7:
                background.sprite = tile7;
                break;
            case 8:
                background.sprite = tile8;
                break;
            case 9:
                background.sprite = tile9;
                break;
            case 10:
                background.sprite = tile10;
                break;
            case 11:
                background.sprite = tile11;
                break;
            case 12:
                background.sprite = tile12;
                break;
            case 13:
                background.sprite = tile13;
                break;
            case 14:
                background.sprite = tile14;
                break;
            case 15:
                background.sprite = tile15;
                break;

        }
    }
}
