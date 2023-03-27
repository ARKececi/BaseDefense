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
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputDragged -= playerMovementController.InputController;
            InputSignals.Instance.onInputDragged -= playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased -= playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken -= playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget -= OnPlayer;
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
    }
}