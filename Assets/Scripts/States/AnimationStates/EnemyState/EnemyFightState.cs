using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyFightState : EnemyBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", false);
            enemyState.GetAnimator().SetBool("Fight", true);
        }

        public override void UpdateState(EnemyAnimationController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController playerState)
        {
            
        }
    }
}