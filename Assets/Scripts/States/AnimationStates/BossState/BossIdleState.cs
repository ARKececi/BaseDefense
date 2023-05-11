using Controllers;
using Controllers.BossController;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class BossIdleState : BossBaseState
    {
        public override void EnterState(BossAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Fight", false);
            enemyState.GetAnimator().SetBool("Idle", true);
            enemyState.GetAnimator().SetBool("Dead", false);
        }

        public override void UpdateState(BossAnimationController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(BossAnimationController playerState)
        {
            
        }
    }
}