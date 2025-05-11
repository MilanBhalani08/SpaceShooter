using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class shope : MonoBehaviour
{
    AudioSource audio1;
    public GameObject shopepanle,settingpannal;
    public Button[] allPlanesBtns;
    //player score
    int score;
    // total cost plane 
    int p1 = 5, p2 = 10;

    bool hasplane = false;
    
   
    // score text 
    public Text panelscore;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        panelscore.text = "" + score;
        for (int i=1;i<allPlanesBtns.Length;i++)
        {
            if (PlayerPrefs.HasKey("planeIndex_"+(i)))
            {
                allPlanesBtns[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void openshoppenal()
    {
        shopepanle.SetActive(true); 
        settingpannal.SetActive(false);
    }
    public void play()
    {
        SceneManager.LoadScene("play");
    }
    public void buyplane(int planeIndex)
    {
        PlayerPrefs.SetInt("planeIndex_0",0);
        if(score>=p1 )
        {
            score-=p1;
            PlayerPrefs.SetInt("score", score);
            //PlayerPrefs.Save();
            // hasplane = true;
            PlayerPrefs.SetInt("planeIndex_1",1);
        }
        else if(score >= p2)
        {
            score -= p2;
            PlayerPrefs.SetInt("score", score);
            //PlayerPrefs.Save();
            // hasplane = true;
            PlayerPrefs.SetInt("planeIndex_2", 2);
        }
        else if(hasplane)
        {
            print("alrady own this ");
        }
        else
        {
            print("collect more coins ");
        }
    }
    public void controllerselect(int num)
    {
        PlayerPrefs.SetInt("num", num);
    }
    public void close()
    {
        shopepanle.SetActive(false);
        settingpannal.SetActive(false);
    }
    public void opensettingpanel()
    {
        settingpannal.SetActive(true);
        shopepanle.SetActive(false);
    }
} 
