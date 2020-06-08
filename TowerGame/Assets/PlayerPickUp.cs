using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
   public bool pickableP1;
   public bool pickableP2;

    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    private Crusorr curso1;

    private Crusorr curso2;

    
    Rigidbody rigidbody;

    public float multiplicationFactor;
    // Start is called before the first frame update
    void Start()
    {
        curso1 = GameObject.Find("CrusorUI1").GetComponent<Crusorr>();
        curso2 = GameObject.Find("CrusorUI2").GetComponent<Crusorr>();

       

        rigidbody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickableP1 == true && Input.GetKey(KeyCode.Joystick1Button6))
        {
            Vector3 item = transform.position;
            Vector3 Player1 = PlayerOne.transform.position;

            item = new Vector3(Player1.x, (Player1.y + 2.3f), Player1.z);

            transform.position = item;
                
            if(Input.GetKeyUp(KeyCode.Joystick1Button7))
            {
                pickableP1 = false;
                rigidbody.AddForce((curso1.currenthitpoint1 - transform.position) * multiplicationFactor);
            }

        }

        if (pickableP2 == true && Input.GetKey(KeyCode.Joystick2Button6))
        {
            Vector3 item = transform.position;
        Vector3 Player2 = PlayerTwo.transform.position;

        item = new Vector3(Player2.x, (Player2.y + 2.3f), Player2.z);

            transform.position = item;
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {

                pickableP2 = false;
                rigidbody.AddForce((curso1.currenthitpoint2 - transform.position) * multiplicationFactor);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
        pickableP1 = true;
            Debug.Log("P1Pick");
        }

        if (collision.gameObject.tag == "Player2")
            pickableP2 = true;
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
            pickableP1 = true;

        if (collision.gameObject.tag == "Player2")
            pickableP2 = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
            pickableP1 = false;

        if (collision.gameObject.tag == "Player2")
            pickableP2 = false;
    }
}
