using UnityEngine;

public class ShieldDecorator : IShipBehavior
{
    private IShipBehavior wrappedBehavior;
    private bool shieldActive = true;
    private GameObject shieldVisual;

    public ShieldDecorator(IShipBehavior behaviorToWrap, GameObject visual)
    {
        wrappedBehavior = behaviorToWrap;
        shieldVisual = visual;

        if (shieldVisual != null)
            shieldVisual.SetActive(true);
    }

    public void Fire()
    {
        wrappedBehavior.Fire();
    }

    public void TakeDamage(int amount)
    {
        if (shieldActive)
        {
            shieldActive = false;
            Debug.Log("Shield absorbed the hit!");

            if (shieldVisual != null)
                shieldVisual.SetActive(false);
        }
        else
        {
            wrappedBehavior.TakeDamage(amount);
        }
    }

    public void Update()
    {
        wrappedBehavior.Update();
    }
}
