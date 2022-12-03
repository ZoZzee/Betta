using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float speedMouse;
    public float jumpSpeed;

    private float horizontalImput;
    private float verticalImput;
    private float mouseMove;
    private bool jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalImput = Input.GetAxis("Horizontal") * Time.deltaTime;
        verticalImput = Input.GetAxis("Vertical") * Time.deltaTime;
        mouseMove = Input.GetAxis("Mouse X") * Time.deltaTime;
        jump = Input.GetButtonDown("Jump");
        transform.Translate(horizontalImput * speed , 0 , verticalImput * speed );
        transform.Rotate( 0, mouseMove * speedMouse , 0);
    }

    void Jump()
    {

    }
}
//(horizontalImput . 0. verticalImput)