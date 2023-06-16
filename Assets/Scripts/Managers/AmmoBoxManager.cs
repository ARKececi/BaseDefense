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
            PlayerSignals.Instance.onAmmoFull += OnAmmoFull;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onAmmoFull -= OnAmmoFull;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnAmmoFull(bool AmmoFull)
        {
            ammoBoxController.Full(AmmoFull);
        }
    }
}