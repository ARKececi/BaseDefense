using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyAnimationFightState : EnemyAnimationBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", false);
            enemyState.GetAnimator().SetBool("Fight", true);
            enemyState.GetAnimator().SetBool("Idle", false);
            enemyState.GetAnimator().SetBool("Run", false);
            enemyState.GetAnimator().SetBool("Dead", false);
        }

        public override void UpdateState(EnemyAnimationController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController playerState)
        {
            
        }
    }
}