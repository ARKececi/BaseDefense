using Controllers;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class PlayerWalkingState : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetBool("RifleIdleAim", false);
            playerState.GetAnimator().SetBool("PistolIdle", false);
            playerState.GetAnimator().SetBool("RifleIdle", false);
            playerState.GetAnimator().SetBool("PistolIdleAim", false);
            playerState.GetAnimator().SetBool("Idle", false);
            playerState.GetAnimator().SetBool("Walking", true);
        }

        public override void UpdateState(PlayerAnimatorController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(PlayerAnimatorController playerState)
        {
            
        }
    }
}