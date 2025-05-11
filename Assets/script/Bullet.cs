using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Bullet : MonoBehaviour
{
    float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        float posx = Mathf.Clamp(transform.position.x - speed, -2f, 2f);
        float posx1 = Mathf.Clamp(transform.position.x + speed, -2f, 2f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(posx, transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(posx1, transform.position.y);
        }
        if (transform.position.y >= 2.8)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "e1")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="e2")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="e3")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "fireball")
        {
            Destroy(collision.gameObject);
        }
    }
}
