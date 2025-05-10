using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleDecorator : IShipBehavior
{
    private IShipBehavior wrapped;
    private BulletProxy bulletProxy;
    private Transform firePoint;

    public TrippleDecorator(IShipBehavior wrappedBehavior, BulletProxy proxy, Transform firePoint)
    {
        wrapped = wrappedBehavior;
        bulletProxy = proxy;
        this.firePoint = firePoint;
    }

    public void Fire()
    {
        FireBullet(0);     // center
        FireBullet(-15f);  // left
        FireBullet(15f);   // right
    }

    private void FireBullet(float angleOffset)
    {
        Quaternion offsetRotation = firePoint.rotation * Quaternion.Euler(0, 0, angleOffset);
        bulletProxy.FireImmediate(firePoint.position, offsetRotation, 10f);
    }

    public void TakeDamage(int amount) => wrapped.TakeDamage(amount);
    public void Update() => wrapped.Update();
}



