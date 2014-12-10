using UnityEngine;
using System.Collections;

public class IvanHealthSystem : MonoBehaviour 
{
	public float health = 100;
	public string[] tags;
	public float[] healthValue;
	public bool[] willDestroy;
	//GameObject sceneManager;
	public bool willDestroySelf = true;

	// Use this for initialization
	void Start () 
	{
		//sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
		{
			//sceneManager.SendMessage("GODied", tag);
			if(willDestroySelf)
			{
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider colliderInfo)
	{
		for(int i=0; i < tags.Length; i++)
		{
			if(colliderInfo.gameObject.tag == tags[i])
			{
				health += healthValue[i];
				if(willDestroy[i])
				{
					Destroy(colliderInfo.gameObject);
				}
			}
		}
	}
}
