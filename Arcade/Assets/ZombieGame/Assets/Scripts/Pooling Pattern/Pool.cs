using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
[System.Serializable]

// Defines the item that is pooled
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton; // For global access
    public List<PoolItem> items;
    public List<GameObject> pooledItems;
    GameObject anObject;
    void Awake()
    {
        // Initializes the the list and singleton instance
        singleton = this;
        pooledItems = new List<GameObject>();

        // Loop through each item type and instantiate the specified amount
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject anObject = Instantiate(item.prefab);
                anObject.SetActive(false); // Sets false on start
                pooledItems.Add(anObject); // adds to the pool
            }

        }
    }
    /// Retrieves an inactive object from the pool.

    public GameObject GetObject()
    {
        string aTag = "Enemy";

        foreach (var obj in pooledItems)
        {
            if (!obj.activeInHierarchy && obj.CompareTag(aTag)) // If the object is innactive and is an Enemy
            {
                obj.SetActive(true); // Activate the object before returning it
                return obj;
            }
        
        }

        return null; // When there are none available


    }

    // Returns the object to the pool
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);  // Deactivate the object
        StartCoroutine(DelayedReset(obj));  // Delays the reactivation of the object

    }

    /// Resets the object to a random spawn position after a delay.
    private IEnumerator DelayedReset(GameObject obj)
    {
        yield return new WaitForSeconds(2f); 
        int randomNum = Random.Range(0,4); 
        switch (randomNum)
        {
            case 0:
                // Spawnpoint 1
                obj.transform.position = new Vector3(0,-2,0);  
                break;

            case 1:
                // Spawnpoint 2
                obj.transform.position = new Vector3(29, -27, 0);
                break;

            case 2:
                // Spawnpoint 3
                obj.transform.position = new Vector3(0,-49,0);  
                break;

            case 3:
                // Spawnpoint 4
                obj.transform.position = new Vector3(-27,-27,0);  
                break;
        }

        obj.transform.rotation = Quaternion.identity; // Reset 
        
        // Reset enemy-specific properties if the object is an enemy
        Enemy enemyScript = obj.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ResetEnemy();
        }
    }




}


