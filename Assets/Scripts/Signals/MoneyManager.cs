using Controllers;
using UnityEngine;

namespace Signals
{
    public class MoneyManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private MoneyController moneyController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onSafeHouse += moneyController.onRigidbodyOn;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onSafeHouse -= moneyController.onRigidbodyOn;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
    }
}