using UnityEngine;
using System.Collections;

public class DistanceSwarm : MonoBehaviour 
{
	public float moveSpeed = 5;
	public GameObject swarmObj;
	//public string swarmName = "Player";

	// Use this for initialization
	void Start () 
	{
		//swarmObj = GameObject.Find(swarmName);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance(swarmObj.transform.position, transform.position);
		if (distance <= 10)
		{
			Flock ();
		}
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
