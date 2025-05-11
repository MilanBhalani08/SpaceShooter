using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    public Slider lifebar;
    int lifeValue = 5;
    // Start is called before the first frame update
    void Start()
    {
        lifebar.value = lifeValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseLife()
    {
        //lifeValue++;
        lifebar.value = lifebar.value+1;
    }
    public void decreaseLife()
    {
        //lifeValue--;
        lifebar.value =lifebar.value-1;
    }
}
