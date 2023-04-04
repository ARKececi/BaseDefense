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

        public void ColliderTrigger()
        {
            collider.isTrigger = true;
        }
    }
}