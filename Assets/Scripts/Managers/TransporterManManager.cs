using Controllers.TransporterManController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class TransporterManManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TransporterManAIController transporterManAIController;
        [SerializeField] private TransporterManController transporterManController;

        #endregion        

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            TransporterManSignalable.Instance.onTurretList += OnTurretList;
            TransporterManSignalable.Instance.onRemoveTurretList += OnRemoveTurretList;
            TransporterManSignalable.Instance.onTarget += OnTarget;
            TransporterManSignalable.Instance.onPushAmmo += OnPushAmmo;
        }

        private void UnsubscribeEvents()
        {
            TransporterManSignalable.Instance.onTurretList -= OnTurretList;
            TransporterManSignalable.Instance.onRemoveTurretList -= OnRemoveTurretList;
            TransporterManSignalable.Instance.onTarget -= OnTarget;
            TransporterManSignalable.Instance.onPushAmmo -= OnPushAmmo;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnTurretList(GameObject turret)
        {
            transporterManAIController.AddTurretList(turret);
        }

        private void OnRemoveTurretList(GameObject turret)
        {
            transporterManAIController.RemoveTurretList(turret);
        }

        private GameObject OnPushAmmo()
        {
            return transporterManController.PushAmmo();
        }

        private void OnTarget()
        {
            transporterManAIController.Target();
        }
    }
}