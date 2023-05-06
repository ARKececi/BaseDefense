using System;
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
            if (other.CompareTag("Plane"))
            {
                //moneyController.transform.gameObject.SetActive(false);
            }

            if (other.CompareTag("Player"))
            {
                    moneyController.ColliderTrigger(true);
                    moneyController.UseKinematic(true);
            }

            if (other.CompareTag("Enemy"))
            {
                    moneyController.ColliderTrigger(false);
                    moneyController.UseKinematic(false);
            }
        }
    }
}