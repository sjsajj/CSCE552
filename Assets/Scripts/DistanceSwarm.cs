using System.Collections;
using UnityEngine;

/// <summary> a script that will make the GameObject move towards another object </summary>
public class DistanceSwarm : MonoBehaviour
{
    /// <summary> how quickly the GameObject will move towards the target </summary>
    public float moveSpeed = 5;

    /// <summary> the object that is being targeted </summary>
    public GameObject swarmObj;

    /// <summary> Use this for initialization </summary>
    private void Start()
    {
    }

    /// <summary> Update is called once per frame </summary>
    private void Update()
    {
        float distance = Vector3.Distance(this.swarmObj.transform.position, transform.position);
        if (distance <= 10)
        {
            this.Flock();
        }
    }

    /// <summary> moves the GameObject towards the target object </summary>
    private void Flock()
    {
        transform.LookAt(this.swarmObj.transform);
        Vector3 tempVect = transform.eulerAngles;
        tempVect.x = 0;
        tempVect.z = 0;
        transform.eulerAngles = tempVect;
        transform.Translate(this.moveSpeed * transform.forward * Time.deltaTime, Space.World);
    }
}