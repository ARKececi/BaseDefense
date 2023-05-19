using Controllers.EnemyController;

namespace Extentions
{
    public abstract class EnemyAnimationBaseState
    {
        public abstract void EnterState(EnemyAnimationController enemyState);
        public abstract void UpdateState(EnemyAnimationController playerState);
        public abstract void OnCollisionEnter(EnemyAnimationController playerState);
    }
}