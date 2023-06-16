using System;
using UnityEngine;

namespace Controllers.TurretAreaController
{
    public class BuyPhysics : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private TurretAreaController turretAreaController;

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
                    turretAreaController.PlayerTrigger();   
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
    }
}