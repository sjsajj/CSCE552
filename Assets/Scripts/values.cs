using System.Collections;
using UnityEngine;

/// <summary> this object hold the values used for most of the functions in the game </summary>
public class Values : MonoBehaviour
{
    /// <summary> how much hunger gets restored </summary>
    public float pickUpsWorthFood = 25;

    /// <summary> how much hydration gets restored </summary>
    public float pickUpsWorthWater = 100;

    /// <summary> how much damage the bear does while in contact </summary>
    public float healthLostBearAttack = -5f;

    /// <summary> the loss rate of health </summary>
    public float healthLossRate = -2;

    /// <summary> the loss rate of hunger </summary>
    public float hungerLossRate = -2;

    /// <summary> the loss rate of hydration </summary>
    public float hydrationLossRate = -2;

    /// <summary> how many times the hungerLossRate will be increased if the player is sprinting </summary>
    public float sprintLossRateModifier = 4;

    /// <summary> how long before the food is unhidden in minutes </summary>
    public float foodWaitTime = 5;
}