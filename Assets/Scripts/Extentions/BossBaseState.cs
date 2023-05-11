using Controllers.BossController;
using Controllers.EnemyController;

namespace Extentions
{
    public abstract class BossBaseState
    {
        public abstract void EnterState(BossAnimationController enemyState);
        public abstract void UpdateState(BossAnimationController playerState);
        public abstract void OnCollisionEnter(BossAnimationController playerState);
    }
}