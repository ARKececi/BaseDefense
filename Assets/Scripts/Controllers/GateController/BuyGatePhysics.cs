using UnityEngine;

namespace Controllers.GateController
{
    public class BuyGatePhysics : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private GateController gateController;

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
                    gateController.PlayerTrigger();   
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
    }
}