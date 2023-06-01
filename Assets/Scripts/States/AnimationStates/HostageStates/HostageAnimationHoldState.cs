using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationHoldState : HostageBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Dig", false);
            hostageMinnerState.GetAnimator().SetBool("Hold", true);
            hostageMinnerState.GetAnimator().SetBool("HandW", false);
        }

        public override void UpdateState(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
    }
}