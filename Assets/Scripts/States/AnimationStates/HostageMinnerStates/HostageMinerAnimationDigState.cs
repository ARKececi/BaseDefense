using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageMinerAnimationDigState : HostageMinerBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Dig", true);
            hostageMinnerState.GetAnimator().SetBool("Hold", false);
            hostageMinnerState.GetAnimator().SetBool("HandW", false);
            hostageMinnerState.GetAnimator().SetBool("HandI", false);
        }

        public override void UpdateState(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
    }
}