using UnityEngine;

namespace Controllers
{
    public class MoneyController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Collider collider;

        #endregion

        #endregion

        public void ColliderTrigger(bool trigger)
        {
            collider.isTrigger = trigger;
        }

        public void UseKinematic(bool kinematic)
        {
            rigidbody.isKinematic = kinematic;
        }
    }
}