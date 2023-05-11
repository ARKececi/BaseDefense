using Controllers;
using Controllers.BossController;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class BossFightState : BossBaseState
    {
        public override void EnterState(BossAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Fight", true);
            enemyState.GetAnimator().SetBool("Idle", false);
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