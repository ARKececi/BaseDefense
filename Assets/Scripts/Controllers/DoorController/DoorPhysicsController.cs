using System;
using UnityEngine;

namespace Controllers.DoorController
{
    public class DoorPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private DoorController doorController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Picker"))
            {
                doorController.OpenDoor();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Picker"))
            {
                doorController.CloseDoor();
            }
        }
    }
}