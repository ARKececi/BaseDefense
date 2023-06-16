using Controllers;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class PlayerRifleIdleState : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetBool("PistolIdleAim", false);
            playerState.GetAnimator().SetBool("PistolIdle", false);
            playerState.GetAnimator().SetBool("RifleIdleAim", false);
            playerState.GetAnimator().SetBool("RifleIdle", true);
            playerState.GetAnimator().SetBool("Idle", false);
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