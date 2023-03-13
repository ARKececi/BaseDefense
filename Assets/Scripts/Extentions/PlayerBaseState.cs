using Controllers;
using Managers;
using UnityEngine;

namespace Extentions
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerAnimatorController playerState);
        public abstract void UpdateState(PlayerAnimatorController playerState);
        public abstract void OnCollisionEnter(PlayerAnimatorController playerState);
    }
}