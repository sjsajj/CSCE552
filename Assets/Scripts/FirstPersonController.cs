using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    public float movementSpeed = 6.0f;
    public float mouseSens = 3.0f;

    private int foodPickUpsCounter = 0;
    private int waterPickUpsCounter = 0;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;
    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
    }



    // Update is called once per frame
    void Update()
    {
        //rotation
        float rotX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, rotX, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);
    }

    //this is for pickups
    void OnTriggerEnter(Collider colliderInfo)
    {
        //the food pickups
        if (colliderInfo.gameObject.tag == "food")
        {
            colliderInfo.gameObject.SetActive(false);
            foodPickUpsCounter += 1;
        }

        //the water pickups
        if (colliderInfo.gameObject.tag == "water")
        {
            colliderInfo.gameObject.SetActive(false);
            waterPickUpsCounter += 1;
        }
    }

}
