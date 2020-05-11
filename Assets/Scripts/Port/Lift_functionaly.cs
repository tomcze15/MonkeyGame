using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_functionaly : MonoBehaviour
{
    public GameObject Komunikat;
    public GameObject Komunikat1;

    public Animator L1;
    public Animator L2;
    public static bool first_lift = false;
    public static bool end_lift = false;

    private void Awake()
    {
        Komunikat = GameObject.FindGameObjectWithTag("komunikat");
        Komunikat1 = GameObject.FindGameObjectWithTag("komunikat1");

    }

    // Start is called before the first frame update
    void Start()
    {

        Komunikat.SetActive(false);
        Komunikat1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!first_lift)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Komunikat.SetActive(false);
                L1.SetBool("lift_up", true);
                L2.SetBool("lift_down", false);
                first_lift = true;

            }
        }

        else if (!end_lift)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Komunikat1.SetActive(false);
                L2.SetBool("lift_down", true);
                L1.SetBool("lift_up", false);
                end_lift = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !first_lift)
        {
            Komunikat.SetActive(true);
            
        }
        else if (other.tag == "Player" && !end_lift)
        {
            Komunikat1.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !first_lift)
        {
            Komunikat.SetActive(false);

        }
        else if (other.tag == "Player" && !end_lift)
        {
            Komunikat1.SetActive(false);

        }
    }
}
