using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public interface IEnemyState
    {
        void Enter();
        void Update();
        void Exit();
    }
}