using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipBehavior 
{
    void Fire();
    void TakeDamage(int amount);
    void Update();

}
