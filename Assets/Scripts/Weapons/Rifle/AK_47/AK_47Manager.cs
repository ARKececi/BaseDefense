using UnityEngine;
using Weapons.Rifle.AK_47.Signal;

namespace Weapons.Rifle.AK_47
{
    public class AK_47Manager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private AK_47State.AK_47 AK_47;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            AK_47Signalable.Instance.onUpgrade += OnUpgrade;
        }

        private void UnsubscribeEvents()
        {
            AK_47Signalable.Instance.onUpgrade -= OnUpgrade;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnUpgrade()
        {
            AK_47.Upgrade();
        }
    }
}