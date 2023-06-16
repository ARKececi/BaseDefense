using System;
using UnityEngine;

namespace Controllers.TurretController
{
    public class TurretPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TurretController turretController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                turretController.OperatorPlayer(other.gameObject);
            }
        }
    }
}