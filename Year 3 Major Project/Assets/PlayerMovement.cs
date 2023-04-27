using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerMove;
    Animator anim;
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;

    //[SerializeField] float xsens = 5.0f;
    
    /*[SerializeField] float ysens = 5.0f;
    public float minY = -30f;
    public float maxY = 30f;
    float rotateY = 0f;*/


    void Start()
    {
        playerMove = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        //transform.Rotate(0, Input.GetAxis("Mouse X") * xsens, 0);

        /*rotateY += Input.GetAxis("Mouse Y") * ysens;
        rotateY = Mathf.Clamp(rotateY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotateY, transform.localEulerAngles.y, 0);*/

        if (playerMove.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;
        velocity = transform.TransformDirection(velocity);
        playerMove.Move(velocity * Time.deltaTime);
        //Debug.Log("Player movement detected");
        if (gameObject.GetComponent<CharacterController>().velocity.magnitude > 0.1f)
        { anim.SetBool("isMoving", true); }
    }    
}