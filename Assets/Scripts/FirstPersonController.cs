using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    public float movementSpeed = 6.0f;
    public float mouseSens = 3.0f;

    //used for falldamange
    private float lastPositionY = 0;
    private float fallDistance = 0;
    private int fallThreshold = 1;
    private int fallDamageAmount = -5;
    private CharacterController playerController;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;


    // Use this for initialization
    void Start()
    {
        //makes sure the mouse does not go ouside of the game window
        Screen.lockCursor = true;

        //gets the CharacterController assigned to a variable
        playerController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //applys fall damage if necessary
        fallDamage();

        //rotation
        UpdateMouse();

        //movement
        UpdateMovement();
    }

    /// <summary>
    /// applys fall damage if the player falls to far
    /// </summary>
    private void fallDamage()
    {
        //the current player y position
        float playerY = transform.position.y;

        //gets the players stat script so we can acces it
        PlayerStats statValues = GetComponent<PlayerStats>();

        if (!playerController.isGrounded && (lastPositionY != 0))
        {
            print("start fall mark");
            lastPositionY = playerY;
        }

        if (playerController.isGrounded)
        {
            if ((lastPositionY - playerY) > fallThreshold)
            {
                print("falling damage apllyed");
                statValues.adjustHealth(fallDamageAmount);
                resetFallDamageTrigers();
            }
        }
        /*

        //checking if we need to update the fallDistance
        if (lastPositionY > transform.position.y)
        {
            print("incrementing fall distance");
            fallDistance += lastPositionY - transform.position.y;
        }

        //updating the lastPositionY
        lastPositionY = transform.position.y;

        if ((fallDistance >= fallThreshold) && (playerController.isGrounded))
        {
            print("falling damage not apllyed");
            statValues.adjustHealth(fallDamageAmount);
            resetFallDamageTrigers();
        }

        else
        {
            resetFallDamageTrigers();
        }*/
    }

    /// <summary>
    /// sets the fall distance and last position y to zero
    /// </summary>
    private void resetFallDamageTrigers()
    {
        fallDistance = 0;
        lastPositionY = 0;
    }

    /// <summary>
    /// updates the position of the player based on the keyboard input
    /// </summary>
    private void UpdateMovement()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);
    }

    /// <summary>
    /// updats the camra view based on the mouse movement
    /// </summary>
    private void UpdateMouse()
    {
        //rotation
        float rotX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, rotX, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    //this is for pickups
    void OnTriggerEnter(Collider colliderInfo)
    {
        float pickUpsWorth = 25;
        float pickUpsWorthWater = 100;

        //access the script PlayerStats, we can now use statValues to get to the functions of the script
        PlayerStats statValues = GetComponent<PlayerStats>();

        //the food pickups
        if (colliderInfo.gameObject.tag == "food")
        {
            colliderInfo.gameObject.SetActive(false);
            statValues.adjustHunger(pickUpsWorth);
        }

        //when we run into water we increment the value of hydration
        if (colliderInfo.gameObject.tag == "water")
        {
            statValues.adjustHydration(pickUpsWorthWater);
        }
    }

}
