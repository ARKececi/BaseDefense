using DG.Tweening;
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
        public bool AimTrigger;

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
        private bool _safehouse;
        private bool _dead;
        private bool _deadTrigger;
        private bool _turretHold;
        private bool _turretTrigger;

        private PlayerBaseState _currentState;
        private PlayerBaseState _playerPistolIdleState;
        private PlayerBaseState _playerPistolAimingState;
        private PlayerBaseState _playerRifleIdleState;
        private PlayerBaseState _playerRifleAimingState;
        private PlayerBaseState _playerReloadState;
        private PlayerBaseState _playerIdleState;
        private PlayerBaseState _playerWalkingState;

        private PlayerBaseState _playerAngelMovement;

        private PlayerBaseState _playerDeadState;
        private PlayerBaseState _playerTurretHoldState;

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
            _playerIdleState = new PlayerIdleState();
            _playerWalkingState = new PlayerWalkingState();
            _playerDeadState = new PlayerDeadState();
            _playerTurretHoldState = new PlayerTurretHoldState();

            AimTrigger = false;
            _acceleration = 3;
            _deceleration = 3;
            _safehouse = true;
            _deadTrigger = false;
        }

        private void Update()
        {
            if (_turretHold)
            {
                if (_turretTrigger != true)
                {
                    PlayerTurretHoldState();
                    _turretTrigger = true;
                }
            }
            else
            {
                _turretTrigger = false;
                if (_dead)
                {
                    if (_deadTrigger != true)
                    {
                        PlayerDeadState();
                        _deadTrigger = true;
                    }
                }
                else
                {
                    if (_moveInput != Vector3.zero)
                    {
                        if (_safehouse)
                        {
                            PlayerWalkingState();
                            PlayerAngelMovement();
                            _trigger = false;
                            _deadTrigger = false;
                        }
                        else
                        {
                            if (AimTrigger)
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
                                    _velocityX = 0;
                                    WeaponIdleState();
                                }
                                _trigger = true;
                            }
                        }
                    }
                    else
                    {
                        if (_safehouse)
                        {
                            PlayerIdleState();
                            PlayerAngelMovement();
                            _trigger = false;
                        }
                        else
                        {
                            
                            if (AimTrigger)
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
                                    _velocityX = 0;
                                    WeaponIdleState();
                                }
                                _trigger = true;
                            }
                        }
                        VelocityXZero();
                        VelocityZZero();
                    }
                    _playerAngelMovement.UpdateState(this);
                }
            }
        }

        public void TurretHold(bool hold)
        {
            _turretHold = hold;
        }

        public void Dead(bool dead)
        {
            _dead = dead;
        }
        
        public Animator GetAnimator()
        {
            return animator;
        }

        public void SafeHouse(bool safebool)
        {
            _safehouse = safebool;
        }
        
        public void PistolIdleBool(bool PistolIdle)
        {
            _pistolIdle = PistolIdle;
        }
        
        public void InputController( InputParams inputParams)
        {
            _moveInput = inputParams.MoveValues;
        }

        private void PlayerWalkingState()
        {
            _currentState = _playerWalkingState;
            _currentState.EnterState(this);
        }

        private void PlayerIdleState()
        {
            _currentState = _playerIdleState;
            _currentState.EnterState(this);
        }

        private void PlayerDeadState()
        {
            _currentState = _playerDeadState;
            _currentState.EnterState(this);
        }

        private void PlayerTurretHoldState()
        {
            _currentState = _playerTurretHoldState;
            _currentState.EnterState(this);
        }
        
        public void WeaponIdleState()
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

        public void WeaponAimingState()
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

        public void OnAimTrigger(bool status)
        {
            AimTrigger = status;
        }
    }
}