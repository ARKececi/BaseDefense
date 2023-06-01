using Controllers.HostageController;
using Controllers.HostageDefaultController;
using Extentions;

namespace HostageStates
{
    public class HostageDefaultAnimationWalkingState : HostageDefaultBaseState
    {
        public override void EnterState(HostageDefaultAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", true);
            HostageState.GetAnimator().SetBool("Idle", false);
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