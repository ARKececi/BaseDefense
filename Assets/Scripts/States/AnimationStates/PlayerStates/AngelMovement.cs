using Controllers;
using Extentions;
using UnityEngine;

namespace States.PlayerStates.PlayerMoveState
{
    public class AngelMovement : PlayerBaseState
    {
        public override void EnterState(PlayerAnimatorController playerState)
        {

        }
        public override void UpdateState(PlayerAnimatorController playerState)
        {
            playerState.GetAnimator().SetFloat("Horizontal", playerState._velocityZ);
            playerState.GetAnimator().SetFloat("Vertical", playerState._velocityX);
        }
        public override void OnCollisionEnter(PlayerAnimatorController playerState)
        {
            
        }
    }
}