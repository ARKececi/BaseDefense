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

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                moneyController.transform.gameObject.SetActive(false);
            }

            if (other.CompareTag("Player"))
            {
                moneyController.ColliderTrigger();
            }
        }
    }
}