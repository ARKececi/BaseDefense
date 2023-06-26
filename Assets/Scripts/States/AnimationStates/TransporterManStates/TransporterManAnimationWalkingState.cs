using Controllers.TransporterManController;
using Extentions;

namespace States.AnimationStates.TransporterManStates
{
    public class TransporterManAnimationWalkingState : TransporterManBaseState
    {
        public override void EnterState(TransporterManAnimationController hostagePickerState)
        {
            hostagePickerState.GetAnimator().SetBool("Walking", true);
            hostagePickerState.GetAnimator().SetBool("Idle", false);
        }

        public override void UpdateState(TransporterManAnimationController hostagePickerState)
        {
            
        }
        
        public override void OnCollisionEnter(TransporterManAnimationController hostagePickerState)
        {
            
        }
    }
}