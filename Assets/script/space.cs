using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space : MonoBehaviour
{
    Renderer r;
    float yset = 0;
    // Start is called before the first frame update
    void Start()
    {
        r=GetComponent<Renderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        yset = Time.time * 0.05f;
        r.material.SetTextureOffset("_MainTex", new Vector2(0, yset));
    }
}
