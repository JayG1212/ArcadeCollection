using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    PlayerScript playerScript;
    PlayerShooting PlayerShoot;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        PlayerShoot= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }
   
    private void OnCollisionEnter2D(Collision2D other) // When player collides with powerup
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("HpDrop"))
            {
                HpStrategy hpStrategy = new HpStrategy(); // Creates an instance of the hp strategy
                playerScript.AddHealth(hpStrategy.GetPowerUp()); // Increases player health using the strategy
            }
            else if (gameObject.CompareTag("SpeedDrop"))
            {
                SpeedStrategy speedStrategy = new SpeedStrategy();// Creates an instance of the Speed strategy
                playerScript.AddSpeedPowerUp(speedStrategy.GetPowerUp()); // Increases player speed using the strategy

            }
            else if (gameObject.CompareTag("FireRateDrop"))
            {
                FireRateStrategy fireRate = new FireRateStrategy();// Creates an instance of the Fire Rate strategy
                PlayerShoot.AddFireRate(fireRate.GetPowerUp()); // Increases player rate of fire using the strategy


            }
            Destroy(gameObject); // Destroys the power-up after being collected

        }

    }
}
