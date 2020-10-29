using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declare and Initialise variables
    float speed = 10.0f;
    float limit = 10f;
    float planeBz = 20.0f;
    float planeBx = 5.0f;

    float gravityModifier = 2.5f;
    int jumpTimes = 0;
    bool onGround = false;

    Rigidbody playerRb;

    int planeIndicator = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Declare and In it variables to reference to User Interaction inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move Player (GameObject) according to user interactions
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Plane A
        if (planeIndicator == 0)
        {
            if (transform.position.z < -limit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -limit);
            }
            if (transform.position.z > limit && transform.position.x > planeBx)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limit);
            }
            if (transform.position.z > limit && transform.position.x < -planeBx)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limit);
            }
            if (transform.position.x < -limit)
            {
                transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
            }
            if (transform.position.x > limit)
            {
                transform.position = new Vector3(limit, transform.position.y, transform.position.z);
            }
        }
        // Plane B
        if (planeIndicator == 1)
        {
            if (transform.position.x < -planeBx)
            {
                transform.position = new Vector3(-planeBx, transform.position.y, transform.position.z);
            }
            if (transform.position.x > planeBx)
            {
                transform.position = new Vector3(planeBx, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -limit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -limit);
            }
            if ( transform.position.z > planeBz)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, planeBz);
            }
        }

        JumpPlayer();
    }   

    // Jump Code
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes < 2)
        {
            playerRb.AddForce(Vector3.up * 8, ForceMode.Impulse);

            // Track my jump if single jump or double jump
            jumpTimes++;
        }
    }

    // Event Listener for a collision by the GameObject "Player" with another possible GameObject
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("Ïn Plane A");
            planeIndicator = 0;
            jumpTimes = 0;
        }

        if (collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("Ïn Plane B");
            planeIndicator = 1;
            jumpTimes = 0;
        }
    }

}