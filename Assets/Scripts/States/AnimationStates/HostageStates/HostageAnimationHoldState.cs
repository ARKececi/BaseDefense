using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationHoldState : HostageBaseState
    {
        public override void EnterState(HostageAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Dig", false);
            HostageState.GetAnimator().SetBool("Hold", true);
            HostageState.GetAnimator().SetBool("Hostage", false);
        }

        public override void UpdateState(HostageAnimationController HostageState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageAnimationController HostageState)
        {
            
        }
    }
}