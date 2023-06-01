using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationDigState : HostageBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Dig", true);
            hostageMinnerState.GetAnimator().SetBool("Hold", false);
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