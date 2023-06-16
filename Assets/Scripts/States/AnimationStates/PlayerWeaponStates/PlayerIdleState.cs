using Controllers;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class PlayerIdleState : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetBool("RifleIdleAim", false);
            playerState.GetAnimator().SetBool("PistolIdle", false);
            playerState.GetAnimator().SetBool("RifleIdle", false);
            playerState.GetAnimator().SetBool("PistolIdleAim", false);
            playerState.GetAnimator().SetBool("Idle", true);
            playerState.GetAnimator().SetBool("Walking", false);
            playerState.GetAnimator().SetBool("Dead", false);
            playerState.GetAnimator().SetBool("Hold", false);
        }

        public override void UpdateState(PlayerAnimatorController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(PlayerAnimatorController playerState)
        {
            
        }
    }
}