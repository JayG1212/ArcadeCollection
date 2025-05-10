using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class ShootCommand : ICommand
    {
        private PlayerShoot playerShoot;

        public ShootCommand(PlayerShoot playerShoot)
        {
            this.playerShoot = playerShoot;
        }

        public void Execute()
        {
            playerShoot.Shoot();
        }

    }
}
