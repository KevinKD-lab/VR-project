using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScipt : MonoBehaviour
{
    //player movement
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float force = 700.0f;

    // Start is called before the first frame update
    void Start()
    {
        //lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //move the player
        transform.Translate(0, 0, translation);

        //rotate the player
        transform.Rotate(0, rotation, 0);

        //player jump
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * force);
        }
    }

}
