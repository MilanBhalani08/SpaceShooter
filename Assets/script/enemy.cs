using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour
{
    float speed = 0.1f;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
            if (transform.position.y <= -7.3)
            {
                Destroy(gameObject);
            }    
    }

}
