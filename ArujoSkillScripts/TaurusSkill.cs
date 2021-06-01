using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaurusSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taurus;
    public float taurus_direction;
    public Transform start_point;
    BasicMovements bmc_class;
    PlayerEntity pe;

    public bool is_available_taurus_skill;
    void Start()
    {
        taurus_direction = 1;
        is_available_taurus_skill = true;
        bmc_class = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {

        }
        else if (true)
        {
            if (Input.GetKeyDown(KeyCode.V)) //arujo
            {
                create_taurus_object();
            }
        }
        
    }

    public void UseTaurusSkill(bool value)
    {
        if (pe.playerMana >= 100)
        {
            //is_available_taurus_skill = true;
            if (value == true && is_available_taurus_skill == true)
            {

                pe.playerMana = pe.playerMana - 100;
                FindObjectOfType<AudioManager>().Play("taurusBump");
                create_taurus_object();
            }
            
            //pe.playerMana = pe.playerMana - 100;
            // playerre.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }

    void create_taurus_object()
    {
        if (is_available_taurus_skill == true)
        {
            // taurus_direction = bmc_class.my_player_scale;
            taurus_direction = bmc_class.Sagittarius.transform.localScale.x;
            //ASLINDA BURADA SAĞ SOL BUTONLARI İLE ÇAĞIRACAKSIN TAM OLCAK YİĞNEİM !!!
            Vector3 vv =  new Vector3(start_point.position.x, start_point.position.y, -3);
            GameObject my_taurus = Instantiate(taurus, vv, start_point.rotation);
            my_taurus.transform.localScale = new Vector3(taurus_direction * 0.3f, 0.3f, 0.3f);
            is_available_taurus_skill = false;
            Invoke("destroy_taurus", 5f);
        }

        else
        {
            Debug.Log("yavas la gac tane basıyon");
        }


        //my_taurus.GetComponent<Rigidbody2D>().velocity = transform.right * bump_force;
    }
    void destroy_taurus()
    {
        is_available_taurus_skill = true;
        //GameObject.FindGameObjectWithTag("arrow");
        //Destroy(GameObject.FindGameObjectWithTag("taurus_prefab"));
        // de
    }
}
