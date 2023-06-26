using Controllers.AmmoBoxController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class AmmoBoxManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private AmmoBoxController ammoBoxController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            AmmoBoxSignalable.Instance.onPushAmmo += OnPushAmmo;
            AmmoBoxSignalable.Instance.onPlace += OnPlace;
        }

        private void UnsubscribeEvents()
        {
            AmmoBoxSignalable.Instance.onPushAmmo -= OnPushAmmo;
            AmmoBoxSignalable.Instance.onPlace -= OnPlace;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
        
        private GameObject OnPushAmmo()
        {
            return ammoBoxController.PushAmmo();
        }

        private GameObject OnPlace()
        {
            return ammoBoxController.Place();
        }
    }
}