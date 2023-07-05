using System;
using UnityEngine;

namespace Controllers.WeaponShopController
{
    public class WeaponShopPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private WeaponShopController weaponShopController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                weaponShopController.PanelOpen();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                weaponShopController.PanelClose();
            }
        }
    }
}