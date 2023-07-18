using System;
using Controllers.EnemyController;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private PlayerStackController playerStackController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #region Private Variables

        private float _timer;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Money"))
            {
                playerStackController.AddMoney(other.gameObject);
            }

            if (other.CompareTag("SafeHouse"))
            {
                playerController.SafeHouse(true);
                playerMovementController.TrueSafeHouse();
                playerAnimatorController.SafeHouse(true);
                PlayerSignals.Instance.onWeaponActive?.Invoke(false);
                PlayerSignals.Instance.onPlayerSafeHouse?.Invoke(true);
                PlayerSignals.Instance.onTargetWall?.Invoke();
                PlayerSignals.Instance.onSafeHouse?.Invoke();
                playerController.GetHealt(100);
            }

            if (other.TryGetComponent<EnemyAtackController>(out EnemyAtackController damage))
            {
                playerController.HealtDamage(damage.Setdamage());
            }

            if (other.CompareTag("Mining"))
            {
                playerController.MinerHostageChange();
                playerController.ResetHostageList();
            }

            if (other.CompareTag("BulletArea"))
            {
                playerStackController.TrueAmmoBox();
            }

            if (other.CompareTag("TurretStack"))
            {
                playerStackController.TrueTurretStack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("SafeHouse"))
            {
                playerMovementController.FalseSafeHouse();
                playerController.SafeHouse(false);
                playerAnimatorController.SafeHouse(false);
                PlayerSignals.Instance.onWeaponActive?.Invoke(true);
                PlayerSignals.Instance.onPlayerSafeHouse?.Invoke(false);
            }

            if (other.CompareTag("BulletArea"))
            {
                playerStackController.FalseAmmoBox();
            }
            
            if (other.CompareTag("TurretStack"))
            {
                playerStackController.FalseTurretStack();
            }
        }
    }
}