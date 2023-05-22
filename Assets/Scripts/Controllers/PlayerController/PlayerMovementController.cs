using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Keys;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> Enemy;
        public bool EnemyTrigger;

        #endregion

        #region Serialized Variables

        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private Rigidbody move;
        [SerializeField] private GameObject character;
        [SerializeField] private bool _isReadyToMove, _isReadyToPlay;

        #endregion

        #region Private Variables
        
        private Vector3 _moveInput;
        private int _moveSpeed;
        private PlayerData _playerData;
        #endregion
        
        #endregion

        #region SubscribedMethods

        public void EnableMovement() { _isReadyToMove = true; }
        public void DeactiveMovement() { _isReadyToMove = false; }
        public void EnablePlay() { _isReadyToPlay = true; }
        public void DeactivePlay() { _isReadyToPlay = false; }

        #endregion

        public void GetMoveSpeed(int Speed)
        {
            _moveSpeed = Speed;
        }

        public void InputController( InputParams inputParams)
        {
            _moveInput = inputParams.MoveValues;
        }

        private void Move()
        {
            move.velocity = new Vector3(_moveInput.x * _moveSpeed, move.velocity.y, _moveInput.z * _moveSpeed);
            Vector3 direction = Vector3.forward * _moveInput.z + Vector3.right * _moveInput.x;
            if (Enemy.Count != 0)
            {
                transform.LookAt(Enemy[0].gameObject.transform);
            }
            else
            {
                playerAnimatorController.OnAimTrigger(false);
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

        public void AddEnemy(GameObject enemy)
        {
            Enemy.Add(enemy);
            playerAnimatorController.OnAimTrigger(true);
            if (Enemy.Count == 1)
            {
                EnemyTrigger = true;
            }
        }

        public void RemoveEnemy(GameObject enemy)
        {
            Enemy.Remove(enemy);
            if (Enemy.Count == 0)
            {
                EnemyTrigger = false;
            }
        }

        public void DeadPlayer()
        {
            var count = Enemy.Count;
            for (int i = 0; i < count; i++)
            {
                Enemy.Remove(Enemy[0]);
            }
        }

        public List<GameObject> EnemyList()
        {
            return Enemy;
        }
    }
}