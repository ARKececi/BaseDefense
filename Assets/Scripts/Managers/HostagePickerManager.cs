using Controllers.HostagePickerController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class HostagePickerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private HostagePickerController hostagePickerController;
        [SerializeField] private HostagePickerAIController hostagePickerAIController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            HostagePickerSignalable.Instance.onMoneyListAdd += OnMoneyListAdd;
            HostagePickerSignalable.Instance.onMoneyListRemove += OnMoneyListRemove;
        }

        private void UnsubscribeEvents()
        {
            HostagePickerSignalable.Instance.onMoneyListAdd -= OnMoneyListAdd;
            HostagePickerSignalable.Instance.onMoneyListRemove -= OnMoneyListRemove;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnMoneyListAdd(GameObject money)
        {
            hostagePickerAIController.MoneyListAdd(money);
        }

        private void OnMoneyListRemove(GameObject money)
        {
            hostagePickerAIController.MoneyListRemove(money);
        }
        
    }
}