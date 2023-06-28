using Controllers.TransporterManAreaController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class TransporterManAreaManager : MonoBehaviour
    {

        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TransporterManAreaController transporterManAreaController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            TransporterManSignalable.Instance.onTurretList += OnAddTurretList;
        }

        private void UnsubscribeEvents()
        {
            TransporterManSignalable.Instance.onTurretList -= OnAddTurretList;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnAddTurretList(GameObject turret)
        {
            transporterManAreaController.AddTurretList(turret);
        }
    }
}