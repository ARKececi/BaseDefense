using System;
using UnityEngine;

namespace Controllers.BasketController
{
    public class BasketPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BasketController basketController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                basketController.PlayerTrigger(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                basketController.PlayerTrigger(false);
            }
        }
    }
}