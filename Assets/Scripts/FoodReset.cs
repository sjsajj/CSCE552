using System.Collections;
using UnityEngine;

public class FoodReset : MonoBehaviour
{
    /// <summary> if the food is hidden currently </summary>
    public bool hidden = false;

    /// <summary> how long before the food is unhidden in minutes </summary>
    public float waitTime = 5;

    // Use this for initialization 
    private void Start()
    {
    }

    // Update is called once per frame 
    private void Update()
    {
        if (hidden /*&& this.renderer.enabled*/)
        {
            //this.renderer.enabled = false;
            this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            //this.collider.enabled = false;
            this.hidden = false;
            StartCoroutine("WaitUnhide");
        }
    }

    /// <summary> when the player hits the food it should hide then reset </summary>
    /// <param name="other"> what triggered the collider </param>
    //public void OnTriggerEnter(Collider other)
    //{
    //    hidden = true;
    //    print("player hit the food");
    //}

    /// <summary> unhides the food after the set time </summary>
    /// <returns> unknown don't know what it should be </returns>
    IEnumerator WaitUnhide()
    {
        yield return (new WaitForSeconds(waitTime * 60));
        //renderer.enabled = true;

        this.GetComponent<SphereCollider>().enabled = true;
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}