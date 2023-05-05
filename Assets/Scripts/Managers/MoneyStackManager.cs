using Controllers;
using Controllers.MoneyStackController;
using UnityEngine;

namespace Signals
{
    public class MoneyStackManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private MoneyStackController moneyStackController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onSetMoneyObj += moneyStackController.SetMoneyObj;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onSetMoneyObj -= moneyStackController.SetMoneyObj;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private GameObject OnSetMoneyObj()
        {
            var money = moneyStackController.SetMoneyObj();
            return money;
        }
    }
}