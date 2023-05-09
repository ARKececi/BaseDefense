using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyDeadState : EnemyBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", false);
            enemyState.GetAnimator().SetBool("Fight", false);
            enemyState.GetAnimator().SetBool("Idle", false);
            enemyState.GetAnimator().SetBool("Dead", true);
        }

        public override void UpdateState(EnemyAnimationController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController playerState)
        {
            
        }
    }
}