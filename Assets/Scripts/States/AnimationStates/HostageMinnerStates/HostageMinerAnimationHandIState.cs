using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageMinerAnimationHandIState : HostageMinerBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Dig", false);
            hostageMinnerState.GetAnimator().SetBool("Hold", false);
            hostageMinnerState.GetAnimator().SetBool("HandW", false);
            hostageMinnerState.GetAnimator().SetBool("HandI", true);
        }

        public override void UpdateState(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
    }
}