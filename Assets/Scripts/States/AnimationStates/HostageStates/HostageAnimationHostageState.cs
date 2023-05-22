using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationHostageState : HostageBaseState
    {
        public override void EnterState(HostageAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", false);
            HostageState.GetAnimator().SetBool("Dig", false);
            HostageState.GetAnimator().SetBool("Idle", false);
            HostageState.GetAnimator().SetBool("Hold", false);
            HostageState.GetAnimator().SetBool("Hostage", true);
        }

        public override void UpdateState(HostageAnimationController HostageState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageAnimationController HostageState)
        {
            
        }
    }
}