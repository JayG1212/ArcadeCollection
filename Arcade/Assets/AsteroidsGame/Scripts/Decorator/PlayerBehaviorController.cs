using Asteroid;
using System.Collections;
using UnityEngine;

namespace Asteroid
{

    public class PlayerBehaviorController : MonoBehaviour
    {
        bool hasTripple = false;
        public GameObject bulletPrefab;
        public Transform firePoint;
        public GameObject shieldVisual;

        public IShipBehavior currentBehavior;

        private BulletProxy bulletProxy;
        private bool hasShield = false;

        void Start()
        {
            bulletProxy = new BulletProxy(bulletPrefab, 0.2f);
            currentBehavior = new BaseShip(bulletProxy, firePoint);
        }

        void Update()
        {
            currentBehavior.Update();

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                currentBehavior.Fire();
        }

        public void TakeDamage(int amount)
        {
            currentBehavior.TakeDamage(amount);
        }

        public void ActivateShield()
        {
            currentBehavior = new ShieldDecorator(currentBehavior, shieldVisual);
            hasShield = true;
        }

        public void ActivateTripleShot()
        {
            if (hasTripple) return;
            hasTripple = true;
            IShipBehavior original = currentBehavior; 

            currentBehavior = new TrippleDecorator(original, bulletProxy, firePoint);
            StartCoroutine(RevertAfterDelay(original, 10f)); ;
        }

        public void NotifyShieldExpired()
        {
            hasShield = false;
        }

        private IEnumerator RevertAfterDelay(IShipBehavior revertTo, float delay)
        {
            yield return new WaitForSeconds(delay);
            hasTripple = false;
            currentBehavior = revertTo;
        }


    }


}