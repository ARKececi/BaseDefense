using System;
using UnityEngine;

namespace Controllers.TransporterManController
{
    public class TransporterManPhysicsController : MonoBehaviour
    {
        #region Self variables

        #region Serialized Variables

        [SerializeField] private TransporterManController transporterManController;
        [SerializeField] private TransporterManAnimationController transporterManAnimationController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BulletArea"))
            {
                transporterManController.TrueAmmoBox();
                transporterManAnimationController.Idle();
            }
            
                        
            if (other.CompareTag("TurretStack"))
            {
                transporterManController.TrueTurretStack();
                transporterManAnimationController.Idle();
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