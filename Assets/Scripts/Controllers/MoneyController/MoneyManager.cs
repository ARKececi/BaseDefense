using Signals;
using UnityEngine;

namespace Controllers
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
            PlayerSignals.Instance.onMoneyReset += OnMoneyReset;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onMoneyReset -= OnMoneyReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnMoneyReset()
        {
            moneyController.ColliderTrigger(false);
            moneyController.UseKinematic(false);
            transform.tag = "Money";
        }
    }
}