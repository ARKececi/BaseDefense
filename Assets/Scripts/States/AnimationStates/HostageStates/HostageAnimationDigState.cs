using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationDigState : HostageBaseState
    {
        public override void EnterState(HostageAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Dig", true);
            HostageState.GetAnimator().SetBool("Hold", false);
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