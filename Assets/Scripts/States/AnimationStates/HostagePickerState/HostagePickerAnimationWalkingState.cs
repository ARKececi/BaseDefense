using Controllers.HostagePickerController;
using Extentions;

namespace States.AnimationStates.HostagePickerState
{
    public class HostagePickerAnimationWalkingState : HostagePickerBaseState
    {
        public override void EnterState(HostagePickerAnimationController hostagePickerState)
        {
            hostagePickerState.GetAnimator().SetBool("Walking", true);
            hostagePickerState.GetAnimator().SetBool("Idle", false);
        }

        public override void UpdateState(HostagePickerAnimationController hostagePickerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostagePickerAnimationController hostagePickerState)
        {
            
        }
    }
}