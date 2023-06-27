using System;
using UnityEngine;

namespace Controllers.TurretController
{
    public class TurretStackPhysicsController : MonoBehaviour
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
                turretController.TruePlayerAmmo();
            }

            if (other.CompareTag("TransporterMan"))
            {
                turretController.TrueTransporterManAmmo();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                turretController.FalsePlayerAmmo();
            }

            if (other.CompareTag("TransporterMan"))
            {
                turretController.FalseTransporterManAmmo();
            }
        }
    }
}