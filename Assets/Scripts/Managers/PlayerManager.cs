using Controllers;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private StackController stackController;
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
            PlayerSignals.Instance.onSafeHouse += stackController.RemoveMoney;
            WeaponSignals.Instance.onArm += OnArm;
            WeaponSignals.Instance.onWeaponAnimation += playerAnimatorController.PistolIdleBool;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputDragged -= playerMovementController.InputController;
            InputSignals.Instance.onInputDragged -= playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased -= playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken -= playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget -= OnPlayer;
            PlayerSignals.Instance.onSafeHouse -= stackController.RemoveMoney;
            WeaponSignals.Instance.onArm -= OnArm;
            WeaponSignals.Instance.onWeaponAnimation -= playerAnimatorController.PistolIdleBool;
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
    }
}