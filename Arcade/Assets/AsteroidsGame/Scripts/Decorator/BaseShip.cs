using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    using UnityEngine;


    public class BaseShip : IShipBehavior
    {
        private BulletProxy bulletProxy;
        private Transform firePoint;

        public BaseShip(BulletProxy proxy, Transform firePoint)
        {
            bulletProxy = proxy;
            this.firePoint = firePoint;
        }

        public void Fire()
        {
            bulletProxy.Fire(firePoint.position, firePoint.rotation, 10f);
        }

        public void TakeDamage(int amount)
        {
            PlayerHPManager.Instance.TakeDamage(amount);
        }

        public void Update()
        {
            // Optional movement or effects
        }
    }



}
