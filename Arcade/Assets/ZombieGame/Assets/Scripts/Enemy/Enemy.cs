using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    ScoreManager scoreManager;
    IDropStrategy dropStrat; 
    public Transform player;  
    public Animator animator;  

    public int enemyHP = 15;
    public bool isDead = false; 


    public GameObject bloodEffect;
    public int attackRange = 1;  
    public float chaseRange = 1000f;
    

    private EnemyStateMachine currentState; 
    private Pool pool;  // Reference to the object pool

    public GameObject[] powerUpPrefabs;  // The Prefabs of the Drops
    private float dropChance = 0.1f; // 10% Chance of Drop

    public String[] drops= {"HpDrop", "SpeedDrop", "FireRateDrop"}; // Zombie Drops
    void Start()
    {
        dropStrat = new HpStrategy(); // Default
        animator = GetComponent<Animator>();  // Get the Animator component
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
        scoreManager = FindObjectOfType<ScoreManager>();
        ChangeState(new IdleState(this)); // Start in Idle state
        pool = Pool.singleton;  // Initialize the pool

    }

    void Update()
    {
        if (isDead) return; // Stop updates if dead

        currentState.Update(); 


    }
    public void ChangeState(EnemyStateMachine newState)
    {
        if (isDead || (currentState != null && newState.GetType() == currentState.GetType())) return; // Avoid redundant transitions

        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, 2f * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return; // Prevent taking damage after death

        if (other.CompareTag("Bullet"))  
        {
            Destroy(other.gameObject);
            TakeDamage(5); // Reduce health
            
        }
    }

    private void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;

        if(enemyHP <= 0)
        {
            DropPowerUp();  // Drop a power-up before dying
            print("The Enemy is Dead");
            ChangeState(new DeadState(this));
            scoreManager.AddScore(100);

        }
        else
        {
            print("The Enemy was hit");
            GameObject effect = Instantiate(bloodEffect, transform.position, transform.rotation);
            StartCoroutine(RemoveBloodEffect(effect));
        }
    }

    private IEnumerator RemoveBloodEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1f); // Waits for 2 seconds
        Destroy(effect); // Destroys the blood effect object

    }

    void DropPowerUp()
    {
        // Randomly chooses one of the three drops
        int x = Random.Range(0, drops.Length); 
        string aDrop = drops[x]; // Chooses one of the 3 drops randomly
        
        IDropStrategy strategy = DropStrategyFactory.GetStrategy(aDrop); // Initializes a new drop with factory 
        
        // Retrieves the corresponding power-up prefab based on the chosen strategy
        GameObject powerUpPrefab = GetPowerUpPrefab(strategy);  

        // Determines if the Drop will spawn or not
        if (Random.value <= dropChance) // Chance to drop the power-up
        {
            // Instantiate the power-up at the enemy's position
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Power-up did not drop"); // Doesn't spawn

        }

    }

    // Determines which prefab to return based on the provided drop strategy
    GameObject GetPowerUpPrefab(IDropStrategy strategy)
    {
        if (strategy is HpStrategy)
        {
            // If the strategy is HpStrategy
            return powerUpPrefabs[0];  
        }
        else if (strategy is SpeedStrategy)
        {
            // Return the Speed power-up prefab
            return powerUpPrefabs[1]; 
        }
        else if (strategy is FireRateStrategy)
        {
            // Return the Fire Rate power-up prefab
            return powerUpPrefabs[2]; 
        }
        else
        {
            return null;  // Default case if no match
        }
    }


    public void ResetEnemy()
    {
        gameObject.SetActive(true); //  Make sure it's active first!

        isDead = false;
        enemyHP = 15; // Reset health

        animator.Rebind(); //  Safe to reset now that it's active!
        animator.Play("Idle"); // Reset to Idle animation

        GetComponent<Collider2D>().enabled = true; // Re-enable collision
        GetComponent<Rigidbody2D>().simulated = true; // Re-enable physics

        ChangeState(new IdleState(this)); // Reset to idle state
    }




    public IEnumerator RemoveZombie()
    {
        yield return new WaitForSeconds(3f); // Wait 3 seconds
        pool.ReturnObject(gameObject); // Return to the object pool instead of destroying
    }
}
