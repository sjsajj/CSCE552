using System.Collections;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    public float moveSpeed = 5;

    // public float attackDistance = 5; 
    public GameObject swarmObj;

    /// <summary> used to control animations </summary>
    //// public enum AnimationStates : int { isIdle = 0, isWalking = 1, isRunning = 2, isJumping = 3, isAttacking = 4 }; 

    /// <summary> used to control animations </summary>
    //// public AnimationStates animationState = AnimationStates.isIdle; 

    /// <summary> local animator object </summary>
    //// Animator animator; 

    // Use this for initialization 
    private void Start()
    {
        // animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame 
    private void Update()
    {
        this.Flock();

        //// float distanceToPlayer = (transform.position - swarmObj.transform.position).magnitude; if (distanceToPlayer <= attackDistance)
        //// animator.SetInteger("animatorState", (int)AnimationStates.isAttacking); else animator.SetInteger("animationState",
        //// (int)AnimationStates.isRunning); animator.SetInteger("animatorState", (int)AnimationStates.isRunning);
    }

    private void Flock()
    {
        this.transform.LookAt(swarmObj.transform);
        Vector3 tempVect = transform.eulerAngles;
        tempVect.x = 0;
        tempVect.z = 0;
        transform.eulerAngles = tempVect;
        transform.Translate(moveSpeed * transform.forward * Time.deltaTime, Space.World);
    }
}