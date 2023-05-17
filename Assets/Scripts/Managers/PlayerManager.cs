using Controllers;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [FormerlySerializedAs("stackController")] [SerializeField] private PlayerStackController playerStackController;
        [SerializeField] private GameObject arm;
        
        #endregion

        #endregion
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputDragged += playerMovementController.InputController;
            InputSignals.Instance.onInputDragged += playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased += playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken += playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget += OnPlayer;
            PlayerSignals.Instance.onSafeHouse += playerStackController.RemoveMoney;
            WeaponSignals.Instance.onArm += OnArm;
            WeaponSignals.Instance.onWeaponAnimation += playerAnimatorController.PistolIdleBool;
            WeaponSignals.Instance.onEnemyTrigger += OnEnemyTrigger;
            EnemySignals.Instance.onEnemyRemove += playerMovementController.RemoveEnemy;
            EnemySignals.Instance.onEnemyList += playerMovementController.EnemyList;
            EnemySignals.Instance.onContains += playerStackController.OnContain;
            PlayerSignals.Instance.onListCount += OnListCount;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputDragged -= playerMovementController.InputController;
            InputSignals.Instance.onInputDragged -= playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased -= playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken -= playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget -= OnPlayer;
            PlayerSignals.Instance.onSafeHouse -= playerStackController.RemoveMoney;
            WeaponSignals.Instance.onArm -= OnArm;
            WeaponSignals.Instance.onWeaponAnimation -= playerAnimatorController.PistolIdleBool;
            WeaponSignals.Instance.onEnemyTrigger -= OnEnemyTrigger;
            EnemySignals.Instance.onEnemyRemove -= playerMovementController.RemoveEnemy;
            EnemySignals.Instance.onEnemyList -= playerMovementController.EnemyList;
            EnemySignals.Instance.onContains -= playerStackController.OnContain;
            PlayerSignals.Instance.onListCount -= OnListCount;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private Transform OnPlayer()
        {
            return transform;
        }

        private GameObject OnArm()
        {
            return arm;
        }

        private bool OnEnemyTrigger()
        {
            return playerMovementController.EnemyTrigger;
        }

        private int OnListCount()
        {
            return playerStackController.ListCount();
        }
    }
}