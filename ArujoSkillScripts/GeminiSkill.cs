using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeminiSkill : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public SpriteRenderer sr;
    float alphavalue;
    bool sena;
    public float geminiTime;

    public bool enough;
    void Start()
    {
        enough = false;
        sena = false;
    }

    public void GeminiActiveButton()
    {
        sena = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            sena = true;
        }

        /*if (sena == true)
        {

            if (sr.color.a > 0.510f)
            {
                Debug.Log("alpha" + sr.color.a);
                BecameGemini();
            }
            if (sr.color.a < 0.510f)
            {
                Invoke("TimeHasDone", geminiTime);
            }
        }

        if (sena == false)
        {
            if (sr.color.a <= 1.00f)
            {
                Debug.Log("alpha" + sr.color.a);
                BecameDefault();
            }
        }*/
        if (sena == true)
        {
            BecameGemini();
        }

    }

    public void BecameGemini()
    {
        sena = true;
        if (enough == false)
        {
            if (sr.color.a < 0.510f)
            {
                enough = true;
                sena = false;
            }
            sr.color -= new Color(0.01f, 0.01f, 0.01f, 0.01f);
        }
        
    }

    public void BecameDefault()
    {
        sr.color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
    }

    public void TimeHasDone()
    {
        sena = false;
    }
}////////
