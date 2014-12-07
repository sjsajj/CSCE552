using System.Collections;
using UnityEngine;

/// <summary> this class controls the player movement and stats </summary>
public class FirstPersonController : MonoBehaviour
{
    /// <summary> used to control the mouse speed </summary>
    public float upDownRange = 60.0f;

    /// <summary> how quick the player will move </summary>
    public float movementSpeed = 6.0f;

    /// <summary> how sensitive the mouse is </summary>
    public float mouseSens = 3.0f;

    /// <summary> the game values for functions </summary>
    public values gameValues;

    /// <summary> the script that has all of the players stats. assigned in the inspector </summary>
    public PlayerStats playerStatsScript;

    /// <summary> used to make sure the player can not move the Camera that a human head could not </summary>
    private float verticalRotation = 0;

    /// <summary> Use this for initialization </summary>
    private void Start()
    {
        // makes sure the mouse does not go ouside of the game window 
        Screen.lockCursor = true;

        if (this.playerStatsScript == null)
        {
            print("add the script that holds the plays stats and controls the GUI bars");
        }

        if (this.gameValues == null)
        {
            print("please add the script that has all the values for the game\nsuch as the health/food loss rates");
        }
    }

    /// <summary> updates the players movement and the Camera position </summary>
    private void Update()
    {
        // rotation 
        this.UpdateMouse();

        // movment 
        this.UpdateMovement();
    }

    /// <summary> updates the position of the player based on the keyboard input </summary>
    private void UpdateMovement()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * this.movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * this.movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);
    }

    /// <summary> updates the camera view based on the mouse movement </summary>
    private void UpdateMouse()
    {
        // rotation 
        float rotX = Input.GetAxis("Mouse X") * this.mouseSens;
        transform.Rotate(0, rotX, 0);

        this.verticalRotation -= Input.GetAxis("Mouse Y") * this.mouseSens;
        this.verticalRotation = Mathf.Clamp(this.verticalRotation, -this.upDownRange, this.upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(this.verticalRotation, 0, 0);
    }

    /// <summary> this is for pickups </summary>
    /// <param name="colliderInfo"> the object that has been hit by the player </param>
    private void OnTriggerEnter(Collider colliderInfo)
    {
        // the food pickups 
        if (colliderInfo.gameObject.tag == "food")
        {
            colliderInfo.gameObject.SetActive(false);
            this.playerStatsScript.adjustHunger(this.gameValues.pickUpsWorthFood);
        }

        // when we run into water we increment the value of hydration 
        if (colliderInfo.gameObject.tag == "water")
        {
            this.playerStatsScript.adjustHydration(this.gameValues.pickUpsWorthWater);
        }

        // if the water should be removed tage it killWater it will also not be worth as much as normal water 
        if (colliderInfo.gameObject.tag == "killWater")
        {
            this.playerStatsScript.adjustHydration(this.gameValues.pickUpsWorthWater / 4);
            colliderInfo.gameObject.SetActive(false);
        }
    }

    /// <summary> to constantly apply the affects of the code on a trigger </summary>
    /// <param name="colliderInfo"> the trigger that has be tripped by the player </param>
    private void OnTriggerStay(Collider colliderInfo)
    {
        // if the tag is enemy we apply damage 
        if (colliderInfo.gameObject.tag == "enemy")
        {
            this.playerStatsScript.adjustHealth(this.gameValues.healthLostBearAttack * Time.deltaTime);
        }
    }
}