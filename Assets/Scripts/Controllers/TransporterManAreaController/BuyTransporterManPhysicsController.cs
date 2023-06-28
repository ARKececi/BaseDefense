using UnityEngine;

namespace Controllers.TransporterManAreaController
{
    public class BuyTransporterManPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TransporterManAreaController transporterManController;

        #endregion

        #region Private Variables

        private float _timer;

        #endregion

        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transporterManController.BuyTimer();
            }
        }
    }
}