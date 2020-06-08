using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crusorr : MonoBehaviour
{
    public float speed = 10;
    float distance = 50f;

    public GameObject cruso;

    public Vector3 currenthitpoint1;

    public Vector3 currenthitpoint2;

    public LayerMask IgnoreRaycast;

   public Material mat;
    Color Defaultcolor;

    void Start()
    {
        Defaultcolor = mat.GetColor("_Color");
    }

    void Update()
    {
        if (cruso.tag == "Player1")
        {
            float h = Input.GetAxisRaw("Mouse X");
            float v = Input.GetAxisRaw("Mouse Y");

            cruso.transform.position = new Vector2(transform.position.x + (h * speed * Time.deltaTime), transform.position.y + (v * speed * Time.deltaTime));
        }

        if (cruso.tag == "Player2")
        {
            float h = Input.GetAxisRaw("Mouse X2");
            float v = Input.GetAxisRaw("Mouse Y2");

            cruso.transform.position = new Vector2(transform.position.x + (h * speed * Time.deltaTime), transform.position.y + (v * speed * Time.deltaTime));
        }
    }

    void FixedUpdate()
    {
        //SHOOT PLAYER 1
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Ray ray = Camera.main.ScreenPointToRay(cruso.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, ~IgnoreRaycast))
            {

                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.point);
                currenthitpoint1 = hit.point;


                if (hit.collider.gameObject.tag == "Player2")
                {
                    Debug.Log("HIT PLAYER 2");
                    mat.SetColor("_Color", Color.yellow);
                    Invoke("SetColor", 0.5f);
                }

            }
        }
        //SHOOT PLAYER 2
        if (Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            Ray ray = Camera.main.ScreenPointToRay(cruso.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, ~IgnoreRaycast))
            {

                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.point);
                currenthitpoint2 = hit.point;

                if (hit.collider.gameObject.tag == "Player1")
                {
                    Debug.Log("HIT PLAYER 1");
                    mat.SetColor("_Color", Color.yellow);
                    Invoke("SetColor", 0.5f);
                }

            }
        }
    }

    void SetColor()
    {
        mat.SetColor("_Color", Defaultcolor);
    }
}

