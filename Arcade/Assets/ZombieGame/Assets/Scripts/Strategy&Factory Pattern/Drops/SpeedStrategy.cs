using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStrategy : IDropStrategy
{
    public float speedDuration = 8f;
    public float GetPowerUp()
    {
        return speedDuration;
    }
}
