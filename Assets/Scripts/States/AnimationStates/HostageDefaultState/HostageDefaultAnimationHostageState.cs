using Controllers.HostageController;
using Controllers.HostageDefaultController;
using Extentions;

namespace HostageStates
{
    public class HostageDefaultAnimationHostageState : HostageDefaultBaseState
    {
        public override void EnterState(HostageDefaultAnimationController HostageState)
        {
            HostageState.GetAnimator().SetBool("Walking", false);
            HostageState.GetAnimator().SetBool("Idle", false);
            HostageState.GetAnimator().SetBool("Hostage", true);
        }

        public override void UpdateState(HostageDefaultAnimationController HostageState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageDefaultAnimationController HostageState)
        {
            
        }
    }
}