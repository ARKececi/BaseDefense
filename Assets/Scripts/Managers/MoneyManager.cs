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

        }

        private void UnsubscribeEvents()
        {

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
    }
}