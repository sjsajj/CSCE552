using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public float mouseSens = 3.0f;

    float verticalRotation = 0;

    /// <summary> used to control the mouse speed </summary>
    public float upDownRange = 60.0f;

    public PlayerStats playerStatsScript;

    /// <summary> the game values for functions </summary>
    public values gameValues;


    // Use this for initialization
    void Start()
    {
        //makes sure the mouse does not go ouside of the game window
        Screen.lockCursor = true;

        if (playerStatsScript == null)
            print("add the script that holds the plays stats and controls the GUI bars");

        if (gameValues == null)
            print("please add the script that has all the values for the game\nsuch as the health/food loss rates");
    }

    void Update()
    {
        //rotation
        UpdateMouse();

        //movment
        UpdateMovement();
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
        //the food pickups
        if (colliderInfo.gameObject.tag == "food")
        {
            colliderInfo.gameObject.SetActive(false);
            playerStatsScript.adjustHunger(gameValues.pickUpsWorthFood);
        }

        //when we run into water we increment the value of hydration
        if (colliderInfo.gameObject.tag == "water")
        {
            playerStatsScript.adjustHydration(gameValues.pickUpsWorthWater);
        }

        //if the water should be removed tage it killWater it will also not be worth as much as normal water
        if (colliderInfo.gameObject.tag == "killWater")
        {
            playerStatsScript.adjustHydration(gameValues.pickUpsWorthWater / 4);
            colliderInfo.gameObject.SetActive(false);
        }
    }

    //to constantly apply the affects of the code on a trigger
    void OnTriggerStay(Collider colliderInfo)
    {
        //if the tag is enemy we apply damage
        if (colliderInfo.gameObject.tag == "enemy")
        {
            playerStatsScript.adjustHealth(gameValues.healthLostBearAttack * Time.deltaTime);
        }
    }
}
