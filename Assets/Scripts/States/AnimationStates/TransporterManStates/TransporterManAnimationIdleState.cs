using Controllers.TransporterManController;
using Extentions;

namespace States.AnimationStates.TransporterManStates
{
    public class TransporterManAnimationIdleState : TransporterManBaseState
    {
        public override void EnterState(TransporterManAnimationController hostagePickerState)
        {
            hostagePickerState.GetAnimator().SetBool("Walking", false);
            hostagePickerState.GetAnimator().SetBool("Idle", true);
        }

        public override void UpdateState(TransporterManAnimationController hostagePickerState)
        {
            
        }
        
        public override void OnCollisionEnter(TransporterManAnimationController hostagePickerState)
        {
            
        }
    }
}