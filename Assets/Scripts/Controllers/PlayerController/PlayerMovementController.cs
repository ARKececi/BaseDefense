using Data.UnityObject;
using Data.ValueObject;
using Keys;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody move;
        [SerializeField] private GameObject character;
        [SerializeField] private bool _isReadyToMove, _isReadyToPlay;

        #endregion

        #region Private Variables
        
        private Vector3 _moveInput;
        private Vector3 _lookInput;
        private PlayerData _playerData;

        #endregion

        #endregion

        #region SubscribedMethods

        public void EnableMovement() { _isReadyToMove = true; }
        public void DeactiveMovement() { _isReadyToMove = false; }
        public void EnablePlay() { _isReadyToPlay = true; }
        public void DeactivePlay() { _isReadyToPlay = false; }

        #endregion

        private void Awake()
        {
            _playerData = GetPlayerData();
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").PlayerData;
        }
        
        public void InputController( InputParams inputParams)
        {
            _moveInput = inputParams.MoveValues;
            _lookInput = inputParams.LookValues;
        }

        private void Move()
        {
            move.velocity = new Vector3(_moveInput.x * _playerData.MovementSide, move.velocity.y, _moveInput.z * _playerData.MovementSide);
            Vector3 direction = Vector3.forward * _moveInput.z + Vector3.right * _moveInput.x;
            if (_lookInput != Vector3.zero)
            {
                character.transform.localRotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(_lookInput), 6 * Time.deltaTime);
            }
            else
            {
                if (direction != Vector3.zero)
                {
                    character.transform.localRotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(direction), 6 * Time.deltaTime);
                }
            }
        }
        public void Stop()
        {
            move.velocity = Vector3.zero;
            move.angularVelocity = Vector3.zero;
        }
        
        private void FixedUpdate()
        {
            if (_isReadyToPlay)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }
    }
}