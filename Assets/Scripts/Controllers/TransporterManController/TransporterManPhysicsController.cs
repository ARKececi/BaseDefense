using System;
using UnityEngine;

namespace Controllers.TransporterManController
{
    public class TransporterManPhysicsController : MonoBehaviour
    {
        #region Self variables

        #region Serialized Variables

        [SerializeField] private TransporterManController transporterManController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BulletArea"))
            {
                transporterManController.TrueAmmoBox();
            }
            
                        
            if (other.CompareTag("TurretStack"))
            {
                transporterManController.TrueTurretStack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("BulletArea"))
            {
                transporterManController.FalseAmmoBox();
            }
            
                        
            if (other.CompareTag("TurretStack"))
            {
                transporterManController.FalseTurretStack();
            }
        }
    }
}