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
            AmmoBoxSignals.Instance.onPushAmmo += OnPushAmmo;
        }

        private void UnsubscribeEvents()
        {
            AmmoBoxSignals.Instance.onPushAmmo -= OnPushAmmo;
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
    }
}