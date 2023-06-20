using System;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class MoneyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private MoneyController moneyController;

        #endregion

        #region Private Variables

        private bool _trigger;

        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Picker"))
            {
                if (PlayerSignals.Instance.onListCount?.Invoke() <= 14)
                {
                    moneyController.UseKinematic(true);
                    moneyController.ColliderTrigger(true);
                    _trigger = true;
                }
            }

            if (other.CompareTag("Dead") || other.CompareTag("Enemy"))
            {
                if (_trigger == false)
                {
                    moneyController.UseKinematic(false);
                    moneyController.ColliderTrigger(false);
                }
            }

            if (other.CompareTag("SafeHouse"))
            {
                DOVirtual.DelayedCall(2,()=>_trigger = false);
            }
        }
    }
}