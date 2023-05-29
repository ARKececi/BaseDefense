using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationIdleState : HostageBaseState
    {
        public override void EnterState(HostageAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", false);
            HostageState.GetAnimator().SetBool("Idle", true);
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