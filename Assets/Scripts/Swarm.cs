using UnityEngine;
using System.Collections;

public class Swarm : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject swarmObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Flock();
    }

    void Flock()
    {
        transform.LookAt(swarmObj.transform);
        Vector3 tempVect = transform.eulerAngles;
        tempVect.x = 0;
        tempVect.z = 0;
        transform.eulerAngles = tempVect;
        transform.Translate(moveSpeed * transform.forward * Time.deltaTime, Space.World);
    }
}
