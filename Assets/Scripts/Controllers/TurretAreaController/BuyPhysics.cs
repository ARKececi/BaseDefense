using System;
using UnityEngine;

namespace Controllers.TurretAreaController
{
    public class BuyPhysics : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TurretAreaController turretAreaController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
            }
        }
    }
}