using Controllers.HostageController;
using Controllers.HostageDefaultController;
using Extentions;

namespace HostageStates
{
    public class HostageDefaultAnimationIdleState : HostageDefaultBaseState
    {
        public override void EnterState(HostageDefaultAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", false);
            HostageState.GetAnimator().SetBool("Idle", true);
            HostageState.GetAnimator().SetBool("Hostage", false);
        }

        public override void UpdateState(HostageDefaultAnimationController HostageState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageDefaultAnimationController HostageState)
        {
            
        }
    }
}