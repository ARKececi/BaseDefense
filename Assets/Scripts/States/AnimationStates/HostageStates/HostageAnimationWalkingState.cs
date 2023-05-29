using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationWalkingState : HostageBaseState
    {
        public override void EnterState(HostageAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", true);
            HostageState.GetAnimator().SetBool("Idle", false);
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