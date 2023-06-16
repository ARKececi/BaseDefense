using System;
using UnityEngine;

namespace Controllers.AmmoBoxController
{
    public class AmmoBoxPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private AmmoBoxController ammoBoxController;

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
                    ammoBoxController.CreateAmmo();
                    _timer = Timer;
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
    }
}