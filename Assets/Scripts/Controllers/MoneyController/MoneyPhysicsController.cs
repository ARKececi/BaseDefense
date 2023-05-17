using System;
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
            if (other.CompareTag("Player"))
            {
                if (PlayerSignals.Instance.onListCount?.Invoke() <= 14)
                {
                    moneyController.UseKinematic(true);
                    moneyController.ColliderTrigger(true);
                    _trigger = true;
                }
            }

            if (other.CompareTag("Dead"))
            {
                if (_trigger == false)
                {
                    moneyController.UseKinematic(false);
                    moneyController.ColliderTrigger(false);
                }
            }
        }
    }
}