using Controllers;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class PlayerPistolAimingState : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetBool("RifleIdleAim", false);
            playerState.GetAnimator().SetBool("PistolIdle", false);
            playerState.GetAnimator().SetBool("RifleIdle", false);
            playerState.GetAnimator().SetBool("PistolIdleAim", true);
            playerState.GetAnimator().SetBool("Idle", false);
            playerState.GetAnimator().SetBool("Walking", false);
        }

        public override void UpdateState(PlayerAnimatorController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(PlayerAnimatorController playerState)
        {
            
        }
    }
}