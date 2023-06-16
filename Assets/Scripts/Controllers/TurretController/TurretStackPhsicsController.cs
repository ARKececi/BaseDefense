using Signals;
using UnityEngine;

namespace Controllers.TurretController
{
    public class TurretStackPhsicsController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private TurretController turretController;

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
                    turretController.AddAmmo(TurretSignals.Instance.onRemoveAmmo?.Invoke());
                    _timer = Timer;
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
    }
}