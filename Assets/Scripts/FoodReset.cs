using System.Collections;
using UnityEngine;

public class FoodReset : MonoBehaviour
{
    /// <summary> if the food is hidden currently </summary>
    public bool hidden = false;

    /// <summary> the game values for functions </summary>
    private Values gameValues;

    /// <summary> Use this for initialization </summary>
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        gameValues = player.GetComponent<Values>();
        //if (this.gameValues == null)
        //{
        //    print("please add the script that has all the values for the game\nsuch as the health/food loss rates");
        //}
    }

    // Update is called once per frame 
    private void Update()
    {
        if (hidden && this.renderer.enabled)
        {
            //this.renderer.enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            this.hidden = false;
            StartCoroutine("WaitUnhide");
        }
    }

    /// <summary> unhides the food after the set time </summary>
    /// <returns> unknown don't know what it should be </returns>
    private IEnumerator WaitUnhide()
    {
        yield return (new WaitForSeconds(gameValues.foodWaitTime * 60));
        this.GetComponent<SphereCollider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}