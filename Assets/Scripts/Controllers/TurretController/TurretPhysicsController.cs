using System;
using Signals;
using UnityEngine;

namespace Controllers.TurretController
{
    public class TurretPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        [SerializeField] private TurretController turretController;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                turretController.AddEnemy(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                turretController.RemoveEnemy(other.gameObject);
            }
        }
    }
}