using Managers;
using Signals;
using UnityEngine;

namespace Commands
{
    public class StartOfDraggingCommand
    {
        #region Self Variables

        #region Private Variables

        private Vector3 _joystickPos;
        private bool _isFirstTimeTouchTaken;
        private readonly Joystick _joystick;

        #endregion

        #endregion

        public StartOfDraggingCommand(ref Vector3 joystickPos, ref bool isFirstTimeTouchTaken,
            ref Joystick joystick)
        {
            _joystickPos = joystickPos;
            _isFirstTimeTouchTaken = isFirstTimeTouchTaken;
            _joystick = joystick;
        }

        public void Execute()
        {
            InputSignals.Instance.onLookStart?.Invoke();
            InputSignals.Instance.onInputTaken?.Invoke();
            if (!_isFirstTimeTouchTaken)
            {
                _isFirstTimeTouchTaken = true;
                InputSignals.Instance.onFirstTimeTouchTaken?.Invoke();
            }
            
            _joystickPos = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
    }
}