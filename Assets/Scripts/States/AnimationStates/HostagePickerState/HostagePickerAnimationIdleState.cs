using Controllers.HostagePickerController;
using Extentions;

namespace States.AnimationStates.HostagePickerState
{
    public class HostagePickerAnimationIdleState : HostagePickerBaseState
    {
        public override void EnterState(HostagePickerAnimationController hostagePickerState)
        {
            hostagePickerState.GetAnimator().SetBool("Walking", false);
            hostagePickerState.GetAnimator().SetBool("Idle", true);
        }

        public override void UpdateState(HostagePickerAnimationController hostagePickerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostagePickerAnimationController hostagePickerState)
        {
            
        }
    }
}