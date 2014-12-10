using System.Collections;
using UnityEngine;

/// <summary>
/// This script will be responsible for handing the players stats. This includes updating the values for all the GUI elements that depend on the
/// players stats.
/// </summary>
public class PlayerStats : MonoBehaviour
{
    /// <summary> how many days until the player wins the game </summary>
    public int daysUntilRescued = 10;

    /// <summary> how many days until the player looses the game </summary>
    public int daysUntilFound = 10;

    /// <summary> the game values for functions </summary>
    public Values gameValues;

    /// <summary> the players current health </summary>
    public float health = 100;

    /// <summary> the players current hunger </summary>
    public float hunger = 100;

    /// <summary> the plays current hydration </summary>
    public float hydration = 100;

    /// <summary> the maximum amount of health the player can have </summary>
    private float maxHealth = 100;

    /// <summary> the maximum amount of hunger the player can have </summary>
    private float maxHunger = 100;

    /// <summary> the maximum amount of hydration the player can have </summary>
    private float maxHydration = 100;

    private GameObject sceneManager;

    // Use this for initialization 
    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");

        // accessing the other scripts to set the initial values of the GUI elements 
        HealthBar playerHealthBar = GetComponent<HealthBar>();
        HungerBar playerHungerBar = GetComponent<HungerBar>();
        HydrationBar playerHydrationBar = GetComponent<HydrationBar>();
        WinLoss playerWinLoss = GetComponent<WinLoss>();

        // setting the max values
        maxHealth = health;
        maxHunger = hunger;
        maxHydration = hydration;

        // setting the initial values of the bars 
        playerHealthBar.CurrentHealth = (int)health;
        playerHealthBar.MaxHealth = (int)maxHealth;

        playerHydrationBar.CurrentHydration = (int)hydration;
        playerHydrationBar.MaxHydration = (int)maxHydration;

        playerHungerBar.CurrentHunger = (int)hunger;
        playerHungerBar.MaxHunger = (int)maxHunger;

        // setting the intital values of the win loss conditons 
        playerWinLoss.DaysUntilFound = daysUntilFound;
        playerWinLoss.DaysUntilRescued = daysUntilRescued;

        if (gameValues == null)
            print("please add the script that has all the values for the game\nsuch as the health/food loss rates");
    }

    // Update is called once per frame 
    private void Update()
    {
        // decremnt the stats that go down by them selves 
        PasiveStatLoss();

        // normal updating of the health values we dont have to do this every update but it will keep us from forgetting to do it 
        UpDateStatValues();

        // TODO update the win loss conditions 
    }

    #region Stat updates

    /// <summary> deducts a defined amount from hunger and hydration and health if either hunger or hydration is 0 </summary>
    private void PasiveStatLoss()
    {
        // how much sprinting will affect the loss rate of hunger and hydration 
        if (Input.GetButton("Sprint"))
        {
            // print("increaced loss rate"); 
            hunger -= gameValues.hungerLossRate * Time.deltaTime * gameValues.sprintLossRateModifier;
            hydration -= gameValues.hydrationLossRate * Time.deltaTime * gameValues.sprintLossRateModifier;
        }

        else
        {
            // the normal loss rate of hunger nad hydration if not sprinting 
            hunger -= gameValues.hungerLossRate * Time.deltaTime;
            hydration -= gameValues.hydrationLossRate * Time.deltaTime;
        }

        // if just one of the other stats is out we decremnt health by a small amount 
        if ((hydration <= 0) || (hunger <= 0))
        {
            health -= gameValues.healthLossRate * Time.deltaTime;

            // if both are out we decrment again 
            if ((hydration <= 0) && (hunger <= 0))
            {
                health -= gameValues.healthLossRate * Time.deltaTime;
            }
        }

        // making sure we dont go to low
        statBoundsChecking();
    }

    /// <summary> makes sure none of the values go below zero </summary>
    private void statBoundsChecking()
    {
        // bounds checking min 
        if (hydration <= 0)
        {
            hydration = 0;
        }

        if (health <= 0)
        {
            health = 0;
            sceneManager.SendMessage("GODied", tag);
        }

        if (hunger <= 0)
        {
            hunger = 0;
        }

        // bounds checking max 
        if (hydration > maxHydration)
        {
            hydration = maxHydration;
        }

        if (health > maxHealth)
        {
            health = 0;
        }

        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
    }

    /// <summary> updates the GUI bars values in their respective scripts </summary>
    private void UpDateStatValues()
    {
        // accessing the players stat bars 
        HealthBar playerHealthBar = GetComponent<HealthBar>();
        HydrationBar playerHydrationBar = GetComponent<HydrationBar>();
        HungerBar playerHungerBar = GetComponent<HungerBar>();

        // updating the bars for the stats 
        playerHealthBar.CurrentHealth = (int)health;
        playerHydrationBar.CurrentHydration = (int)hydration;
        playerHungerBar.CurrentHunger = (int)hunger;
    }

    #endregion Stat updates

    #region Adjustment for stat values

    /// <summary> lets you modify the value of daysUntilFound by sending in how much you want to change it by </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value If you would like to decrement the value send in a negative value The amount
    /// you send in will be added to the value of daysUntilFound
    /// </remarks>
    /// <param name="amount"> the amount to adjust by </param>
    public void adjustDaysUntilFound(int amount)
    {
        daysUntilFound += amount;
    }

    /// <summary> lets you modify the value of daysUntilRescued by sending in how much you want to change it by </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value If you would like to decrement the value send in a negative value The amount
    /// you send in will be added to the value of daysUntilRescued
    /// </remarks>
    /// <param name="amount"> the amount to adjust by </param>
    public void adjustDaysUntilRescued(int amount)
    {
        daysUntilRescued += amount;
    }

    /// <summary> lets you modify the value of health by sending in how much you want to change it by </summary>
    /// <remarks> If you pass in a positive number it will not change the health The amount you send in will be added to the value of health </remarks>
    /// <param name="amount"> the amount to adjust by </param>
    public void adjustHealth(float amount)
    {
        if (amount <= 0)
        {
            health += amount;
        }
    }

    /// <summary> lets you modify the value of hunger by sending in how much you want to change it by </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value If you would like to decrement the value send in a negative value The amount
    /// you send in will be added to the value of hunger
    /// </remarks>
    /// <param name="amount"> the amount to adjust by </param>
    public void adjustHunger(float amount)
    {
        hunger += amount;
    }

    /// <summary> lets you modify the value of hydration by sending in how much you want to change it by </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value If you would like to decrement the value send in a negative value The amount
    /// you send in will be added to the value of hydration
    /// </remarks>
    /// <param name="amount"> the amount to change the value by</param>
    public void adjustHydration(float amount)
    {
        hydration += amount;
    }

    #endregion Adjustment for stat values
}