using Commands;
using Data.UnityObject;
using Data.ValueObject;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        [SerializeField] private Joystick moveJoystick;
        [SerializeField] private bool isReadyForTouch, isFirstTimeTouchTaken;

        #endregion

        #region Private Variables

        private bool _isTouching; 
        private Vector3 _joystickPos;
        private Vector3 _moveVector;
        private InputData _inputData;
        private EndOfDraggingCommand _endOfDraggingCommand;
        private StartOfDraggingCommand _startOfDraggingCommand;

        #endregion
        #endregion
        
        private void Awake()
        {
            _inputData = GetInputData();
            Init();
        }
            
        private InputData GetInputData()
        {
            return Resources.Load<CD_Input>("Data/CD_Input").InputData;
        }
        
        private void Init()
        {
            _endOfDraggingCommand = new EndOfDraggingCommand(ref _joystickPos, ref _moveVector);
            _startOfDraggingCommand = new StartOfDraggingCommand(ref _joystickPos, ref isFirstTimeTouchTaken,
                ref moveJoystick);
        }
        
        public void Move()
        {
            _joystickPos = new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);
            _moveVector = _joystickPos;
            InputSignals.Instance.onInputDragged?.Invoke(new InputParams
            {
                MoveValues = _moveVector,
            });
        }

        private void Update()
        {
            if (!isReadyForTouch) return;
            if (Input.GetMouseButtonUp(0))
            {
                _isTouching = false;
                _endOfDraggingCommand.Execute();
            }

            if (Input.GetMouseButtonDown(0))
            {
                _isTouching = true;
                _startOfDraggingCommand.Execute();
            }

            if (Input.GetMouseButton(0))
            {
                if (_isTouching)
                {
                    Move();
                }
            }
        }
        
        #region SubscribedMethods

        private void OnPlay()
        {
            isReadyForTouch = true;
        }

        private void OnReset()
        {
            _isTouching = false;
            isReadyForTouch = false;
            isFirstTimeTouchTaken = false;
        }

        #endregion
    }
}