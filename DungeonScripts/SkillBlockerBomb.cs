using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBlockerBomb : MonoBehaviour
{
    public GameObject TriggerPlatform;
    public Button skillButton;
    InGamePanelsBehaviors mt;
    PlayerEntity pe;
    bool explosionPermission;
    bool bombfunct;
    bool isitworked;
    void Start()
    {
        isitworked = true;
        explosionPermission = false;
        bombfunct = false;
        mt = GameObject.FindGameObjectWithTag("gamecanvas").GetComponent<InGamePanelsBehaviors>();
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        bombisactiveted();
        bombfuctions();
    }

    public void bombisactiveted()
    {
        if (!TriggerPlatform.activeInHierarchy && isitworked)
        {
            Debug.Log("block kayboldu");
            explosionPermission = true;
            isitworked = false;
        }
    }

    /*public void onetime()
    {
        if (!TriggerPlatform.activeInHierarchy)
        {
            bombisactiveted();
        }
    }*/

    void OnTriggerStay2D(Collider2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            if (explosionPermission == true)
            {
                bombfunct = true;
            }
        }

    }

    public void skillactivetedtimer()
    {
        mt.skill = true;
        skillButton.image.color = Color.white;
    }

    public void bombfuctions()
    {
        if (bombfunct == true)
        {
            skillButton.image.color = Color.red;
            //hasarAl(0.1f);
            pe.hasarAl(66);
            mt.skill = false;
            Invoke("skillactivetedtimer", 5f);
            bombfunct = false;
            explosionPermission = false;
        }
    }
}////////
