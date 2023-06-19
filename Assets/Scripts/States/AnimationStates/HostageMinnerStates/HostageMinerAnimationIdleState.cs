using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageMinerAnimationIdleState : HostageMinerBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Walking", false);
            hostageMinnerState.GetAnimator().SetBool("Idle", true);
        }

        public override void UpdateState(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
    }
}