using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSrc : MonoBehaviour
{
    public GameObject start;
    void Start()
    {
        Invoke("tick", 0.5f);
    }
    void tick()
    {
        if(start.GetComponent<Text>().enabled == true)
        {
            start.GetComponent<Text>().enabled = false;
        }
        else if (start.GetComponent<Text>().enabled == false)
        {
            start.GetComponent<Text>().enabled = true;
        }
        Invoke("tick", 0.5f);
    }
    public void gotomain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
