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

        #region Serialized Variables

        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [FormerlySerializedAs("stackController")] [SerializeField] private PlayerStackController playerStackController;
        [SerializeField] private PlayerController playerController;

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
                playerAnimatorController.SafeHouse(true);
                PlayerSignals.Instance.onWeaponActive?.Invoke(false);
                PlayerSignals.Instance.onTargetWall?.Invoke();
                PlayerSignals.Instance.onSafeHouse?.Invoke();
            }

            if (other.TryGetComponent<EnemyAtackController>(out EnemyAtackController damage))
            {
                playerController.HealtDamage(damage.Setdamage());
            }

            if (other.CompareTag("Mining"))
            {
                HostageSignalable.Instance.onMining?.Invoke();
                playerController.ResetHostageList();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("SafeHouse"))
            {
                playerAnimatorController.SafeHouse(false);
                PlayerSignals.Instance.onWeaponActive?.Invoke(true);
            }
        }
    }
}