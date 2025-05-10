using UnityEngine;

namespace SpaceInvaders
{
    public class MovementState : IEnemyState
    {
        private EnemyController controller;
        private EnemyMove moveScript;
        private float moveDuration = 2.5f;
        private float timer;

        public MovementState(EnemyController controller)
        {
            this.controller = controller;
            moveScript = controller.GetMoveScript();
        }

        public void Enter()
        {
            timer = 0f;
        }

        public void Exit() { }

        public void Update()
        {
            timer += Time.deltaTime;

            Vector2 direction = controller.GetDirection();
            moveScript.TryMove(direction);

            HandleScreenEdge();

            if (timer >= moveDuration)
            {
                controller.ChangeState(new ZombieIdleState(controller));
            }
        }

        private void HandleScreenEdge()
        {
            Vector3 pos = controller.transform.position;
            float padding = 0.5f; // adjust as needed

            float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
            float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;


            if (pos.x >= screenRight && controller.GetDirection() == Vector2.right)
            {
                controller.FlipDirection();
                controller.transform.position += Vector3.down * 1f;
            }
            else if (pos.x <= screenLeft && controller.GetDirection() == Vector2.left)
            {
                controller.FlipDirection();
                controller.transform.position += Vector3.down * 1f;
            }
        }
    }
}