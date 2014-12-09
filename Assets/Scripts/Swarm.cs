using UnityEngine;
using System.Collections;

public class Swarm : MonoBehaviour
{
    public float moveSpeed = 5;
    //public float attackDistance = 5;
    public GameObject swarmObj;


    /// <summary> used to control animations</summary>
   // public enum animationStates : int { isIdle = 0, isWalking = 1, isRunning = 2, isJumping = 3, isAttacking = 4 };

    /// <summary> used to control animations</summary>
    //public animationStates animationState = animationStates.isIdle;

    /// <summary> local animator object </summary>
   // Animator animator;

    // Use this for initialization
    void Start()
    {
       // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flock();
        
        //float distanceToPlayer = (transform.position - swarmObj.transform.position).magnitude;
        //if (distanceToPlayer <= attackDistance) animator.SetInteger("animatorState", (int)animationStates.isAttacking);
        //else animator.SetInteger("animationState", (int)animationStates.isRunning);
        //animator.SetInteger("animatorState", (int)animationStates.isRunning);
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
