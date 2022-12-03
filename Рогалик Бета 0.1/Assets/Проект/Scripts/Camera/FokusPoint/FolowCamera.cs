using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public GameObject playerPosition;
    //private Vector3 distanse = new Vector3(0,3.9f,-4f);
    public float speedMouse;

    private bool control=true;
    private float mouseMoveX;
    private float mouseMoveY;

    void Start()
    {
        playerPosition = GameObject.Find("Player");
    }

    

// Update is called once per frame
void Update()
    {
        transform.position = playerPosition.transform.position;
        //transform.rotation = playerPosition.transform.rotation;
        mouseMoveY = Input.GetAxis("Mouse X") * Time.deltaTime;
        mouseMoveX = Input.GetAxis("Mouse Y") * Time.deltaTime;
        //transform.Rotate( mouseMove * speedMouse, playerPosition.transform.rotation.y ,0);

        
        if(Input.GetButton("Fire2"))
        {
            transform.Rotate(mouseMoveX * speedMouse, mouseMoveY * speedMouse, 0);
            //transform.rotation += new Vector3(mouseMoveX * speedMouse, mouseMoveY * speedMouse, 0);
            control = false;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            control= true;
        }
        if (control == true)
        {
            transform.rotation = playerPosition.transform.rotation;

        }

        //print(playerPosition.transform.position.x * Time.deltaTime * speed - 4.5f);*/
    }
     
}
