using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform checkpoint;
    GameObject player;
    GameObject wahadlo;
    GameObject bonus;
    GameObject kol_roof;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wahadlo = GameObject.Find("wahadlo");
        bonus = GameObject.FindGameObjectWithTag("kolce");
        kol_roof = GameObject.FindGameObjectWithTag("kolce_roof");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = checkpoint.transform.position;
            player.GetComponent<Rigidbody>().Sleep();
        }

    }
}
