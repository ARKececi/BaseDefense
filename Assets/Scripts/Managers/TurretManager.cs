using Controllers.TurretController;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class TurretManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TurretController turretController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onEnemyRemove += OnRemoveEnemy;
            InputSignals.Instance.onInputDragged += OnInputController;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onEnemyRemove -= OnRemoveEnemy;
            InputSignals.Instance.onInputDragged -= OnInputController;;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnRemoveEnemy(GameObject enemy)
        {
            turretController.RemoveEnemy(enemy);
        }

        private void OnAddAmmo(GameObject ammo)
        {
            turretController.AddAmmo(ammo);
        }

        private void OnInputController(InputParams inputParams)
        {
            turretController.InputController(inputParams);
        }

    }
}