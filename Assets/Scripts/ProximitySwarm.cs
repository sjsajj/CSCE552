using System.Collections;
using UnityEngine;

public enum AIStates
{
    /// <summary> tells the AI to stop </summary>
    Stop,

    /// <summary> tells the AI to wander </summary>
    Wander,

    /// <summary> tells the AI to swarm </summary>
    Swarm
}

public class ProximitySwarm : MonoBehaviour
{
    private AIStates currState;
    private Swarm swarmScript;

    // Animation childAnimation; 
    public float changeDistance = 30;
    public float attackDistance = 5;
    public float wanderspeed = 3;
    private float currMoveSpeed;

    public float minActionTime = 2;
    public float maxActionTime = 7;
    private float currTime;
    public GameObject player;

    /// <summary> used to control animations </summary>
    public enum animationStates : int
    {
        /// <summary> the idle state </summary>
        isIdle = 0,

        /// <summary> the waking state </summary>
        isWalking = 1,

        /// <summary> the running state </summary>
        isRunning = 2,

        /// <summary> the jumping state </summary>
        isJumping = 3,

        /// <summary> the attacking state </summary>
        isAttacking = 4
    }

    /// <summary> used to control animations </summary>
    // public AnimationStates animationState = AnimationStates.isIdle; 

    /// <summary> local animator object </summary>
    private Animator animator;

    // Use this for initialization 
    private void Start()
    {
        animator = GetComponent<Animator>();

        swarmScript = GetComponent<Swarm>();
        if (swarmScript == null)
        {
            gameObject.AddComponent<Swarm>();
        }

        swarmScript.enabled = false;
        // childAnimation = GetComponentInChildren<Animation>(); player = GameObject.Find("Player"); 
        currTime = Random.Range(minActionTime, maxActionTime);

        // pick random action 
        PickRandomAction();
    }

    // Update is called once per frame 
    private void Update()
    {
        float distanceToPlayer = (transform.position - player.transform.position).magnitude;
        if (distanceToPlayer <= changeDistance && distanceToPlayer > attackDistance)
        {
            // Swarm 
            animator.SetInteger("animationState", (int)animationStates.isRunning);
            Swarm();
        }
        else if (distanceToPlayer <= changeDistance && distanceToPlayer <= attackDistance)
        {
            // Swarm 
            animator.SetInteger("animationState", (int)animationStates.isAttacking);
            Swarm();
        }
        else if (currState == AIStates.Swarm)
        {
            // Pick Random Action animator.SetInteger("animationState", PickRandomAction()); 
            PickRandomAction();
        }
        else
        {
            currTime -= Time.deltaTime;
            if (currTime <= 0)
            {
                // pick random action 
                PickRandomAction();
                currTime = Random.Range(minActionTime, maxActionTime);
            }
        }

        transform.Translate(transform.forward * currMoveSpeed * Time.deltaTime, Space.World);
    }

    private void Swarm()
    {
        currState = AIStates.Swarm;
        swarmScript.enabled = true;
        currMoveSpeed = 0;
        // if(childAnimation.IsPlaying("run") == false) { childAnimation.CrossFade("run"); } 
    }

    private int PickRandomAction()
    {
        int returnval = 0;

        if (swarmScript.enabled == true)
        {
            swarmScript.enabled = false;
        }

        int randNum = Random.Range(0, 2);
        if (randNum == 0)
        {
            // stop 
            animator.SetInteger("animationState", (int)animationStates.isIdle);
            Stop();

            // idle 
            returnval = 0;
        }
        else
        {
            // wander 
            animator.SetInteger("animationState", (int)animationStates.isWalking);
            Wander();
            returnval = 1;
        }

        return returnval;
    }

    private void Stop()
    {
        // if(childAnimation.IsPlaying("idle") == false) { childAnimation.CrossFade("idle"); } 
        currMoveSpeed = 0;
        currState = AIStates.Stop;
    }

    private void Wander()
    {
        Quaternion newRot = Random.rotation;
        newRot.x = 0;
        newRot.z = 0;
        transform.rotation = newRot;
        currMoveSpeed = wanderspeed;
        currState = AIStates.Wander;
        // if(childAnimation.IsPlaying("walk") == false) { childAnimation.CrossFade("walk"); } 
    }
}