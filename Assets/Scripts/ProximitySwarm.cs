using UnityEngine;
using System.Collections;

public enum AIStates { Stop, Wander, Swarm };

public class ProximitySwarm : MonoBehaviour
{
    AIStates currState;
    Swarm swarmScript;
    //Animation childAnimation;
    public float changeDistance = 30;
    public float wanderspeed = 3;
    float currMoveSpeed;

    public float minActionTime = 2;
    public float maxActionTime = 7;
    float currTime;
    public GameObject player;

    /// <summary> used to control animations</summary>
    public enum animationStates : int { isIdle = 0, isWalking = 1, isRunning = 2, isJumping = 3 };

    /// <summary> used to control animations</summary>
    //public animationStates animationState = animationStates.isIdle;

    /// <summary> local animator object </summary>
    Animator animator;

    
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        swarmScript = GetComponent<Swarm>();
        if (swarmScript == null)
        {
            gameObject.AddComponent<Swarm>();
        }
        swarmScript.enabled = false;
        //childAnimation = GetComponentInChildren<Animation>();
        //player = GameObject.Find("Player");
        currTime = Random.Range(minActionTime, maxActionTime);
        //pick random action
        PickRandomAction();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (transform.position - player.transform.position).magnitude;
        if (distanceToPlayer <= changeDistance)
        {
            //Swarm
            animator.SetInteger("animationState", (int)animationStates.isRunning);
            Swarm();
        }
        else if (currState == AIStates.Swarm)
        {
            //Pick Random Action
            //animator.SetInteger("animationState", PickRandomAction());
            PickRandomAction();
        }
        else
        {
            currTime -= Time.deltaTime;
            if (currTime <= 0)
            {
                //pick random action
                PickRandomAction();
                currTime = Random.Range(minActionTime, maxActionTime);
            }
        }
        transform.Translate(transform.forward * currMoveSpeed * Time.deltaTime, Space.World);
    }

    void Swarm()
    {
        currState = AIStates.Swarm;
        swarmScript.enabled = true;
        currMoveSpeed = 0;
        //if(childAnimation.IsPlaying("run") == false)
        //{
        //	childAnimation.CrossFade("run");
        //}
    }

    int PickRandomAction()
    {
        int returnval = 0;

        if (swarmScript.enabled == true)
        {
            swarmScript.enabled = false;
        }
        int randNum = Random.Range(0, 2);
        if (randNum == 0)
        {
            //stop
            animator.SetInteger("animationState", (int)animationStates.isIdle);
            Stop();
            returnval = 0;  //idle
        }
        else
        {
            //wander
            animator.SetInteger("animationState", (int)animationStates.isWalking);
            Wander();
            returnval = 1;
        }

        return returnval;
    }

    void Stop()
    {
        //if(childAnimation.IsPlaying("idle") == false)
        //{
        //	childAnimation.CrossFade("idle");
        //}
        currMoveSpeed = 0;
        currState = AIStates.Stop;
    }

    void Wander()
    {
        Quaternion newRot = Random.rotation;
        newRot.x = 0;
        newRot.z = 0;
        transform.rotation = newRot;
        currMoveSpeed = wanderspeed;
        currState = AIStates.Wander;
        //if(childAnimation.IsPlaying("walk") == false)
        //{
        //	childAnimation.CrossFade("walk");
        //}
    }

}







