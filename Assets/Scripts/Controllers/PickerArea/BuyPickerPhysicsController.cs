using System;
using Controllers.PickerArea;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.TurretAreaController
{
    public class BuyPickerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private PickerAreaController pickerAreaController;

        #endregion

        #region Private Variables

        private float _timer;

        #endregion

        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_timer < 0)
                {
                    _timer = Timer;
                    pickerAreaController.PlayerTrigger();   
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
    }
}