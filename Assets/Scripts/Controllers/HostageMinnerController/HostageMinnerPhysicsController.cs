using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.HostageController
{
    public class HostageMinnerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private HostageMinnerController hostageMinnerController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coal"))
            {
                hostageMinnerController.Dig(other.gameObject);
            }

            if (other.CompareTag("Basket"))
            {
                hostageMinnerController.BasketTrigger();
            }
        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}