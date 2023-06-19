using System;
using UnityEngine;

namespace Controllers.HostagePickerController
{
    public class HostagePickerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private HostagePickerController hostagePickerController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Money"))
            {
                hostagePickerController.MoneyListAdd(other.gameObject);
            }

            if (other.CompareTag("SafeHouse"))
            {
                
            }
        }
    }
}