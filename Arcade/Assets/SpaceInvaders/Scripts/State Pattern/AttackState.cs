using UnityEngine;

namespace SpaceInvaders
{
    public class ZombieAttackState : IEnemyState
    {
        private EnemyController controller;
        private EnemyShoot shootScript;
        private float shootCooldown = .5f;
        private float timer;

        public ZombieAttackState(EnemyController controller)
        {
            this.controller = controller;
            shootScript = controller.GetAttackScript();
        }

        public void Enter()
        {
            timer = 0f;
        }

        public void Exit() { }

        public void Update()
        {
            timer += Time.deltaTime;

            if (timer >= shootCooldown)
            {
                shootScript.TryShoot();
                controller.ChangeState(new MovementState(controller));
            }
        }
    }
}