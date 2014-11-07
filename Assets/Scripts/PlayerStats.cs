using UnityEngine;
using System.Collections;

/*This script will be responsible for handing the players stats.
 * This includes updateing the values for all the GUI elements that depend on the players stats.
 * */
public class PlayerStats : MonoBehaviour
{

    //the players stats
    public float health = 100;
    public float hunger = 100;
    public float hydration = 100;

    //for bounds checking
    private float maxHealth = 100;
    private float maxHunger = 100;
    private float maxHydration = 100;

    //the loss rate of the stats
    public float healthLossRate = 0;
    public float hungerLossRate = 0;
    public float hydrationLossRate = 0;

    // Use this for initialization
    void Start()
    {
        //accessing the other scripts to set the initial values of the bars
        healthBar playerHealthBar = GetComponent<healthBar>();
        hydrationBar playerHydrationBar = GetComponent<hydrationBar>();
        hungerBar playerHungerBar = GetComponent<hungerBar>();

        //setting the initial values of the bars
        playerHealthBar.SetInitialValues((int)health);
        playerHydrationBar.SetInitialValues((int)hydration);
        playerHungerBar.SetInitialValues((int)hunger);

        //setting the max values
        maxHealth = health;
        maxHunger = hunger;
        maxHydration = hydration;
    }

    // Update is called once per frame
    void Update()
    {
        //decremnt the stats that go down by them selves
        PasiveStatLoss();

        //normal updating of the health values
        //we dont have to do this every update but it will keep us from forgetting to do it
        UpDateStatValues();
    }

    /// <summary>
    /// updates the GUI bars values in their respective scripts
    /// </summary>
    private void UpDateStatValues()
    {
        //accessing the players stat bars
        healthBar playerHealthBar = GetComponent<healthBar>();
        hydrationBar playerHydrationBar = GetComponent<hydrationBar>();
        hungerBar playerHungerBar = GetComponent<hungerBar>();

        //updating the bars for the stats
        playerHealthBar.SetCurrentValue((int)health);
        playerHydrationBar.SetCurrentValue((int)hydration);
        playerHungerBar.SetCurrentValue((int)hunger);
    }

    /// <summary>
    /// deducts a defined amount from hunger and hydration and health if either hunger or hydration is 0
    /// </summary>
    private void PasiveStatLoss()
    {
        hydration -= hydrationLossRate * Time.deltaTime;
        hunger -= hungerLossRate * Time.deltaTime;

        //if just one of the other stats is out we decremnt health by a small amount
        if ((hydration <= 0) || (hunger <= 0))
        {
            health -= healthLossRate * Time.deltaTime;

            //if both are out we decrment again
            if ((hydration <= 0) && (hunger <= 0))
            {
                health -= healthLossRate * Time.deltaTime;
            }
        }

        //making sure we dont go to low
        statBoundsChecking();
    }

    /// <summary>
    /// makes sure none of the values go bleow zero
    /// </summary>
    private void statBoundsChecking()
    {
        //bounds checking min
        if (hydration <= 0)
        {
            hydration = 0;
        }

        if (health <= 0)
        {
            health = 0;
        }

        if (hunger <= 0)
        {
            hunger = 0;
        }

        //bounds checking max
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

    /// <summary>
    /// lets you modify the value of hydration by sending in how much you want to change it by
    /// </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value
    /// If you would like to decrement thevalue send in a negative value
    /// The amount you send in will be added to the value of hydration
    /// </remarks>
    /// 
    /// <param name="amount"></param>
    public void adjustHydration(float amount)
    {
        hydration += amount;
    }

    /// <summary>
    /// lets you modify the value of hunger by sending in how much you want to change it by
    /// </summary>
    /// <remarks>
    /// If you would like to increment the value send in a positive value
    /// If you would like to decrement thevalue send in a negative value
    /// The amount you send in will be added to the value of hunger
    /// </remarks>
    /// 
    /// <param name="amount"></param>
    public void adjustHunger(float amount)
    {
        hunger += amount;
    }

    /// <summary>
    /// lets you modify the value of health by sending in how much you want to change it by
    /// </summary>
    ///<remarks>
    /// If you pass in a positive number it will not change the health
    /// The amount you send in will be added to the value of hunger
    ///</remarks>
    /// 
    /// <param name="amount"></param>
    public void adjustHealth(float amount)
    {
        if (amount <= 0)
        {
            health += amount;
        }
    }
}