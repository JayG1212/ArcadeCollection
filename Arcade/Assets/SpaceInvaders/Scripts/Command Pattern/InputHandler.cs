using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class InputHandler : MonoBehaviour
    {
        // Command Scripts
        private ICommand moveLeftCommand;
        private ICommand moveRightCommand;
        private ICommand shootCommand;

        // Player Scripts
        [SerializeField] private PlayerMove playerMovement;
        [SerializeField] private PlayerShoot playerShoot;
        private bool canShoot;

        void Awake()
        {
            moveLeftCommand = new MoveLeftCommand(playerMovement);
            moveRightCommand = new MoveRightCommand(playerMovement);
            shootCommand = new ShootCommand(playerShoot);
            canShoot = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
            {

                shootCommand.Execute();
                canShoot = false;
                StartCoroutine(WaitShoot(.35f));
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveLeftCommand.Execute();
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveRightCommand.Execute();
            }
        }

        private IEnumerator WaitShoot(float time)
        {
            yield return new WaitForSeconds(time);
            canShoot = true;
        }
    }
}