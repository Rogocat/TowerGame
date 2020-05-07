using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crusor : MonoBehaviour
{
    //public GameObject cursor; //drag n drop UI object in inspector
    //public Canvas canvas; //drag n drop canvas in inspector
    //float pixelX;
    //float pixelY;
    //float posX;
    //float posY;

    public float speed = 10;

    float borderXLeft = -900f;
    float borderXRight = 900f;
    float borderYLeft = -900f;
    float borderYRight = 900f;

    public float distance = 2000f;

    public GameObject cruso;

    public LayerMask IgnoreRaycast;
    void Start()
    {
     
    }
    void Update()
    {


        Vector3 newPosition = transform.position;

        newPosition.x += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, borderXLeft, borderXRight);

        newPosition.y += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, borderYLeft, borderYRight);


        transform.position = newPosition;


   
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Ray ray = Camera.main.ScreenPointToRay(cruso.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, ~IgnoreRaycast))
            {

                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.point);

                if (hit.collider.gameObject.tag == "Player2")
                {
                    Debug.Log("HIT PLAYER");
                }

            }
        }
    }

}
