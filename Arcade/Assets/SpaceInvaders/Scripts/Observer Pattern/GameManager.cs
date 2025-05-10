using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    /* Explained:
       Keeps track of UI objects
       and alerts them when they need to be updated
     
     */
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private int score = 0;
        private int playerHealth = 3;
        private List<IObserverUI> observers = new List<IObserverUI>(); // List of UI observers

        // Singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }


        // Observer
        public void AddObserver(IObserverUI observer)    // Add a UI observer to the list

        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void RemoveObserver(IObserverUI observer)    // Remove a UI observer from the list

        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        private void NotifyObservers()    // Notify all observers that the game state has changed

        {
            foreach (var observer in observers)
            {
                observer.OnGameStateChanged(score, playerHealth);
            }
        }


        // UI Methods
        public void AddScore(int amount)
        {
            score += amount;
            NotifyObservers();

        }
        public void DecreaseHealth(int damage)
        {
            playerHealth -= damage;
            NotifyObservers();

        }

        // Getters and Setters
        public int GetScore() => score;
        public int GetHealth() => playerHealth;

    }
}