using UnityEngine;
using Weapons.Pistol.P250.Signal;

namespace Weapons.Pistol.P250
{
    public class P250Manager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private P250State.P250 p250;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            P250Signalable.Instance.onUpgrade += OnUpgrade;

        }

        private void UnsubscribeEvents()
        {
            P250Signalable.Instance.onUpgrade -= OnUpgrade;

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnUpgrade()
        {
            p250.Upgrade();
        }
    }
}