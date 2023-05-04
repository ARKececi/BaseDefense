using System;
using UnityEngine;

namespace Controllers
{
    public class PlayerFieldPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                playerMovementController.AddEnemy(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                playerMovementController.RemoveEnemy(other.gameObject);
            }
        }
    }
}