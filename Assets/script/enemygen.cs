using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class enemygen : MonoBehaviour
{
    public GameObject[] enemyprefeb;
    public GameObject[] coinprefeb;
    public GameObject[] fireballprefeb;
    public GameObject[] healthprefeb;
    public Slider sliders;
    int enemyheth = 5;
    // Start is called before the first frame update
    void Start()
    {
        sliders.value = enemyheth;
        InvokeRepeating("enemy",.2f,2f);
        InvokeRepeating("coin", 4f,4f);
        InvokeRepeating("fireball", 3f, 3.5f);
        InvokeRepeating("helthgen", 2.4f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void enemy()
    {
        sliders.value = enemyheth;
        int r = Random.Range(0, enemyprefeb.Length);
        Vector2 pos = new Vector2(Random.Range(-2.4f, +2.4f), transform.position.y);
        Instantiate(enemyprefeb[r], pos, Quaternion.identity);
    }
    void coin()
    {
        int c = Random.Range(0, coinprefeb.Length);
        Vector2 pos = new Vector2(Random.Range(-2.4f, +2.4f), transform.position.y);
        Instantiate(coinprefeb[c], pos, Quaternion.identity); 
    }
    void fireball()
    {
        int f = Random.Range(0, fireballprefeb.Length);
        Vector2 pos = new Vector2(Random.Range(-2.4f, +2.2f), transform.position.y);
        Instantiate(fireballprefeb[f], pos, Quaternion.identity);
    }
    void helthgen()
    {
        int p = Random.Range(0, healthprefeb.Length);
        Vector2 pos = new Vector2(Random.Range(-2.4f, 2f), transform.position.y);
        Instantiate(healthprefeb[p], pos, Quaternion.identity);
    }

}
