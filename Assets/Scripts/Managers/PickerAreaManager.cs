using Controllers.PickerArea;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PickerAreaManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PickerAreaController pickerAreaController;

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

        private void OnMoneyListAdd(GameObject money)
        {
            pickerAreaController.MoneyListAdd(money);
        }

        private void OnMoneyListRemove(GameObject money)
        {
            pickerAreaController.MoneyListRemove(money);
        }
        
        #endregion
    }
}