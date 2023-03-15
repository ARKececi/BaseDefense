using Extentions;
using Keys;
using States.PlayerStates;
using States.PlayerStates.PlayerMoveState;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float _velocityX;
        public float _velocityZ;

        #endregion

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private bool _pistolIdle;
        private Vector3 _moveInput;
        private float _acceleration;
        private float _deceleration;
        private bool _trigger;
        private bool _aimTrigger;

        private PlayerBaseState _currentState;
        private PlayerBaseState _playerPistolIdleState;
        private PlayerBaseState _playerPistolAimingState;
        private PlayerBaseState _playerRifleIdleState;
        private PlayerBaseState _playerRifleAimingState;
        private PlayerBaseState _playerReloadState;

        private PlayerBaseState _playerAngelMovement;

        #endregion

        #endregion
        
        private void Awake()
        {
            _playerPistolIdleState = new PlayerPistolIdleState();
            _playerPistolAimingState = new PlayerPistolAimingState();
            _playerRifleIdleState = new PlayerRifleIdleState();
            _playerRifleAimingState = new PlayerRifleAimingState();
            _playerReloadState = new PlayerReloadState();
            _playerAngelMovement = new AngelMovement();

            _aimTrigger = false;
            _acceleration = 3;
            _deceleration = 3;
        }

        private void Update()
        {
            if (_moveInput != Vector3.zero)
            {
                if (_aimTrigger)
                {
                    PlayerAngelMovementInputParams();
                    if (_trigger)
                    {
                        WeaponAimingState();
                    }
                    _trigger = false;
                }
                else
                {
                    PlayerAngelMovement();
                    if (!_trigger)
                    {
                        WeaponIdleState();
                    }
                    _trigger = true;
                }
            }
            else
            {
                if (_aimTrigger)
                {
                    if (_trigger)
                    {
                        WeaponAimingState();
                    }
                    _trigger = false;
                }
                else
                {
                    if (!_trigger)
                    {
                        WeaponIdleState();
                    }
                    _trigger = true;
                }
                VelocityXZero();
                VelocityZZero();
            }
            _playerAngelMovement.UpdateState(this);
        }
        
        public Animator GetAnimator()
        {
            return animator;
        }
        
        public void PistolIdleBool(bool PistolIdle)
        {
            _pistolIdle = PistolIdle;
            WeaponIdleState();
        }
        
        public void InputController( InputParams inputParams)
        {
            _moveInput = inputParams.MoveValues;
        }
        
        private void WeaponIdleState()
        {
            if (_pistolIdle)
            {
                _currentState = _playerPistolIdleState;
                _currentState.EnterState(this);
            }
            else
            {
                _currentState = _playerRifleIdleState;
                _currentState.EnterState(this);
            }
        }

        private void WeaponAimingState()
        {
            if (_pistolIdle)
            {
                _currentState = _playerPistolAimingState;
                _currentState.EnterState(this);
            }
            else
            {
                _currentState = _playerRifleAimingState;
                _currentState.EnterState(this);
            }
        }

        private void PlayerAngelMovement()
        {
            _velocityZ = transform.eulerAngles.y switch
            {
                >= 0 and <= 90 => (Mathf.Abs(2*_moveInput.z) + Mathf.Abs(2*_moveInput.x)),
                >= 91 and <= 180 => (Mathf.Abs(2*_moveInput.x) + Mathf.Abs(2*_moveInput.z)),
                >= 181 and <= 270 => Mathf.Abs(2*_moveInput.z) + Mathf.Abs(2*_moveInput.x),
                >= 271 and <= 360 => Mathf.Abs(2*_moveInput.x) + Mathf.Abs(2*_moveInput.z),
                _ => _velocityZ
            };
        }

        private void PlayerAngelMovementInputParams()
        {
            switch (transform.eulerAngles.y)
            {
                case >= 0 and <= 44:
                    _velocityX = 2 * _moveInput.x;
                    _velocityZ = 2 * _moveInput.z;
                    break;
                case >= 45 and <= 89:
                    _velocityX = 2 * _moveInput.z;
                    _velocityZ = 2 * _moveInput.x;
                    break;
                case >= 90 and <= 134:
                    _velocityX = 2 * -_moveInput.z;
                    _velocityZ = 2 * _moveInput.x;
                    break;
                case >= 135 and <= 179:
                    _velocityX = 2 * _moveInput.x;
                    _velocityZ = 2 * -_moveInput.z;
                    break;
                case >= 180 and <= 224:
                    _velocityX = 2 * -_moveInput.x;
                    _velocityZ = 2 * -_moveInput.z;
                    break;
                case >= 225 and <= 269:
                    _velocityX = 2 * -_moveInput.z;
                    _velocityZ = 2 * -_moveInput.x;
                    break;
                case >= 270 and <= 314:
                    _velocityX = 2 * _moveInput.z;
                    _velocityZ = 2 * -_moveInput.x;
                    break;
                case >= 315 and <= 359:
                    _velocityX = 2 * _moveInput.x;
                    _velocityZ = 2 * _moveInput.z;
                    break;
            }
        }
        
        private void VelocityXZero()
        {
            if (_velocityX > 0)
            {
                if (_velocityX < 0.1)
                {
                    _velocityX = 0;
                }
                else
                {
                    _velocityX -= Time.fixedDeltaTime * _deceleration;
                }
                
            }
            else if (_velocityX < 0)
            {
                if (_velocityX > -0.1)
                {
                    _velocityX = 0;
                }
                else
                {
                    _velocityX += Time.fixedDeltaTime * _deceleration;
                }
            }
        }
        private void VelocityZZero()
        {
            if (_velocityZ > 0)
            {
                if (_velocityZ < 0.1)
                {
                    _velocityZ = 0;
                }
                else
                {
                    _velocityZ -= Time.fixedDeltaTime * _deceleration;   
                }
            }
            else if (_velocityZ < 0)
            {
                if (_velocityZ > -0.1)
                {
                    _velocityZ = 0;
                }
                else
                {
                    _velocityZ += Time.fixedDeltaTime * _deceleration;   
                }
            }
        }
    }
}