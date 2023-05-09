using Controllers;
using Extentions;
using UnityEngine;

namespace States.PlayerStates.PlayerMoveState
{
    public class PlayerDeadState : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetFloat("Horizontal", 0);
            playerState.GetAnimator().SetFloat("Vertical", 0);
            playerState.GetAnimator().SetBool("RifleIdleAim", false);
            playerState.GetAnimator().SetBool("PistolIdle", false);
            playerState.GetAnimator().SetBool("RifleIdle", false);
            playerState.GetAnimator().SetBool("PistolIdleAim", false);
            playerState.GetAnimator().SetBool("Idle", false);
            playerState.GetAnimator().SetBool("Walking", false);
            playerState.GetAnimator().SetBool("Dead", true);
        }
        public override void UpdateState(PlayerAnimatorController playerState)
        {

        }
        public override void OnCollisionEnter(PlayerAnimatorController playerState)
        {
            
        }
    }
}