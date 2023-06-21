using System;
using UnityEngine;

namespace Controllers.PickerArea
{
    public class UpgradePickerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PickerAreaController pickerAreaController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}