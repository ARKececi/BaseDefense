using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyWalkingState : EnemyBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", true);
            enemyState.GetAnimator().SetBool("Fight", false);
        }

        public override void UpdateState(EnemyAnimationController enemyState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController enemyState)
        {
            
        }
    }
}