using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalZone : MonoBehaviour
{
    // Start is called before the first frame update
    public StarGuard smc;
    void Start()
    {
        //smc = GameObject.FindGameObjectWithTag("starguard").GetComponent<StarGuard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            smc.player_is_in_internalZone = true;
        }
        if (nesne.gameObject.tag == "pisces")
        {
            //Area.gameObject.SetActive(false);
        }

    }
    void OnTriggerExit2D(Collider2D nesne) // when player enter the field
    {

        if (nesne.gameObject.tag == "Player")
        {
            smc.player_is_in_internalZone = false;
        }


    }

}///////////////
