using UnityEngine;

namespace SpaceInvaders
{
    public class EnemyController : MonoBehaviour
    {
        private IEnemyState currentState;

        private EnemyMove moveScript;
        private EnemyShoot shootScript;

        private Vector2 currentDirection = Vector2.right;

        void Awake()
        {
            moveScript = GetComponent<EnemyMove>();
            shootScript = GetComponent<EnemyShoot>();
        }

        void Start()
        {
            ChangeState(new ZombieIdleState(this));
        }

        void Update()
        {
            currentState?.Update();
        }

        public void ChangeState(IEnemyState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        // Direction helpers
        public Vector2 GetDirection() => currentDirection;
        public void FlipDirection()
        {
            currentDirection = (currentDirection == Vector2.right) ? Vector2.left : Vector2.right;
        }

        public EnemyMove GetMoveScript() => moveScript;
        public EnemyShoot GetAttackScript() => shootScript;
    }
}