
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedPlayer = 5f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;


    private Animator animPlayer;
    private Rigidbody rbPlayer;
    private bool isGrounded = true;
   

    

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
               Jump();
                animPlayer.SetTrigger("jump");
            }
        }
        
        
    }
    private void PlayerMovement()
    {
        float ejeVertical = Input.GetAxis("Vertical");
        float ejeHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, ejeHorizontal * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, ejeVertical * Time.deltaTime * speedPlayer);
        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animPlayer.SetBool("isRunning", true);
        }
        else
        {
            animPlayer.SetBool("isRunning", false);
        }
       
    }
    private void Jump()
    {
        Debug.Log("Deberia saltar");
        rbPlayer.AddForce(0, 1 * jumpForce ,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = true;
            Debug.Log("Floor");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }




}
