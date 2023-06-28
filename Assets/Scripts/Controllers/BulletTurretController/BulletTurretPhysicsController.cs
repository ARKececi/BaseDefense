using System;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BulletTurretPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BulletTurretController bulletTurretController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                bulletTurretController.RemoveAmmo();
            }
        }
    }
}