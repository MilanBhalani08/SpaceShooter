using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class planecontrol : MonoBehaviour
{
    bool muted = false;
    float speed = 0.1f;
    public GameObject[] bulletprefeb;
    public Transform amo;
    bool isgoingleft = false;
    bool isgoingright = false;
    int planeindex = 0;
    public Sprite[] plane;
    int num = 0;
    public int score = 0;
    public GameObject btn, btn1;
    public Text scoreprint;
    public Slider controllerhealth;
    int helth = 5;
   // public Text totalcoints;
    // Start is called before the first frame update
    void Start()
    {
        scoreprint.text = "" + score;
        score = PlayerPrefs.GetInt("score", 0);
        controllerhealth.value = helth;
        planeindex = PlayerPrefs.GetInt("planeIndex", 0);
        num = PlayerPrefs.GetInt("num", 0);
        GetComponent<SpriteRenderer>().sprite = plane[planeindex];
        InvokeRepeating("fire", 1f, .1f);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (num == 0)
        {
            keybordcontroller();
        }
        if(num ==1)
        {
            if (isgoingleft)
            {
                planecontrollrleft();
            }
            if (isgoingright)
            {
                planecontrollerright();
            }
            btn.SetActive(true);
            btn1.SetActive(true);
        }
        if(num == 2)
        {
            rotat();
        }
        if (transform.rotation.y != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speed);
        }
        /*  if (!PlayerPrefs.HasKey("muted"))
          {
              PlayerPrefs.SetInt("mute", 0);
          }
          else
          {
              muted = PlayerPrefs.GetInt("muted") == 1;
          }*/
    }
    void fire()
    {
        int r = Random.Range(0, bulletprefeb.Length);
        Instantiate(bulletprefeb[r], amo.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "e1")
        {
            controllerhealth.value = controllerhealth.value-1;
            if(controllerhealth.value==0)
            {
                SceneManager.LoadScene("restart");
            }
        }
        if(collision.gameObject.tag == "e2")
        {
            controllerhealth.value = controllerhealth.value - 1;
            if (controllerhealth.value == 0)
            {
                SceneManager.LoadScene("restart");
            }
        }
        if (collision.gameObject.tag == "e3")
        {
            controllerhealth.value = controllerhealth.value - 1;
            if (controllerhealth.value == 0)
            {
                SceneManager.LoadScene("restart");
            }
        }
        if (collision.gameObject.tag == "coin") 
        {   
            PlayerPrefs.SetInt("score",score++);
            scoreprint.text = "" + score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "fireball")
        {
            controllerhealth.value = controllerhealth.value - 1;
            if (controllerhealth.value == 0)
            {
                SceneManager.LoadScene("restart");
            }
        }
        if (collision.gameObject.tag == "depoint")
        { 
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "helth")
        {
            Destroy(collision.gameObject);
            controllerhealth.value = controllerhealth.value + 1;        
        }
    }
    void keybordcontroller()
    {
        float posx = Mathf.Clamp(transform.position.x - speed, -1.72f, 1.72f);
        float posX = Mathf.Clamp(transform.position.x + speed, -1.72f, 1.72f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(posx, transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(posX, transform.position.y);
        }
        btn.SetActive(false);
        btn1.SetActive(false);
    }
    public void leftBtndown()
    {
        isgoingleft = true;
    }
    public void leftbtnup()
    {
        isgoingleft = false;
    }
    public void planecontrollrleft()
    {
        float posx = Mathf.Clamp(transform.position.x - speed, -1.85f, +1.85f);
        transform.position = new Vector2(posx, transform.position.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 47), speed);
    }
    public void rightbtndown()
    {
        isgoingright = true;
    }
    public void rtightbtnup()
    {
        isgoingright = false;
    }
    public void planecontrollerright()
    {
        float posy = Mathf.Clamp(transform.position.x + speed, -1.85f, +1.85f);
        transform.position = new Vector2(posy, transform.position.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -47), speed);
    }
    void touch()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.position.x < Screen.width / 2)
            {
                planecontrollrleft();
            }
            else if (t.position.x > Screen.width / 2)
            {
                planecontrollerright();
            }
            btn.SetActive(false);
            btn1.SetActive(false);
        }
    }
    void rotat()
    {
        if (Input.acceleration.x < -0.1f)
        {
            planecontrollrleft();
        }
        else if (Input.acceleration.x > 0.1f)
        {
            planecontrollerright();
        }
        btn.SetActive(false);
        btn1.SetActive(false);
    }
    public void homebtn()
    {
        SceneManager.LoadScene("home");
    }
    /*  public void volume()
      {
          if (muted == false)
          {
              muted = true;
              AudioListener.pause = true;
          }
          else
          {
              muted = false;
              AudioListener.pause = false;
          }
          PlayerPrefs.SetInt("muted", muted ? 1 : 0);
      }*/
}
