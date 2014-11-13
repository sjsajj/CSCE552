using UnityEngine;
using System.Collections;

/// <summary>
/// this object hold the values used for most of the functions in the game
/// </summary>
public class values : MonoBehaviour
{
    /// <summary> how much hunger gets restored </summary>
    public float pickUpsWorthFood = 25;

    /// <summary> how much hydration gets restored </summary>
    public float pickUpsWorthWater = 100;

    /// <summary> how much damage the bear does while in contact </summary>
    public float healthLostBearAttack = -5f;

    /// <summary> the loss rate of health </summary>
    public float healthLossRate = 0;

    /// <summary> the loss rate of hunger </summary>
    public float hungerLossRate = 0;

    /// <summary> the loss rate of hydration </summary>
    public float hydrationLossRate = 0;
}
