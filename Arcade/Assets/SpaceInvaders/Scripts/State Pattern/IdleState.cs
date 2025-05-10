using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class ZombieIdleState : IEnemyState
    {
        private EnemyController controller;

        private float idleDuration = .2f; // seconds to wait
        private float timer;


        public void Enter()
        {
            timer = 0f;

        }
        public void Exit()
        {

        }

        public void Update()
        {
            timer += Time.deltaTime;

            if (timer >= idleDuration)
            {
                controller.ChangeState(new ZombieAttackState(controller));

            }
        }

        public ZombieIdleState(EnemyController controller)
        {
            this.controller = controller;
        }
    }
}