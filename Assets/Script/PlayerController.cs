using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declare and Initialise variables
    float speed = 10.0f;
    float limit = 9.5f;
    float enter = 4.5f;

    float gravityModifier = 2.5f;
    int jumpTimes = 0;
    bool onGround = false;

    Rigidbody playerRb;

    bool planeB = false;

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

        // Player Border at Z Axis
        if (collision.gameObject.CompareTag("PlaneA"))
            if (transform.position.z < -limit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -limit);
            }
            else if (transform.position.z > limit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limit);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            }

            // Player Border at X Axis
            if (transform.position.x < -limit)
            {
            transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > limit)
            {
                transform.position = new Vector3(limit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
            }

        // Jump Code
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes < 2)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            // Track my jump if single jump or double jump
            jumpTimes++;
        }
    }

    // Event Listener for a collision by the GameObject "Player" with another possible GameObject
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA" || "PlaneB"))
        {
            jumpTimes = 0;
        }

        if (collision.gameObject.CompareTag("PlaneA"))
        {
            debug.log
        }
    }

}