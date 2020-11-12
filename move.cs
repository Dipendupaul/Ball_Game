using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Ball;
    private Vector3 m_movementVector = new Vector3();
    public float Speed;
    public float jump;
    
    void Start()
    {
    
        Screen.orientation = ScreenOrientation.LandscapeRight;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Jump when user taps on the ball
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 jumpForce= new Vector3(0.0f,jump,0.0f);
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit= new RaycastHit();
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.name == "Ball")
                {
                    rb.AddForce(jumpForce * Speed * Time.deltaTime);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        GetInput_Android();
    }

    private void GetInput_Android()
    {
        if (Input.touchCount > 0)
        {
            // Update the movement vector
                m_movementVector.x += Input.touches[0].deltaPosition.x;
                m_movementVector.y = 0.0f;
                m_movementVector.z += Input.touches[0].deltaPosition.y;
            m_movementVector.Normalize();
            rb.AddForce(m_movementVector * Speed * Time.deltaTime);
        } 
        
    }
}