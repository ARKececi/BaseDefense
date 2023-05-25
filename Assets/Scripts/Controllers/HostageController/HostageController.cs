using UnityEngine;

namespace Controllers.HostageController
{
    public class HostageController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject diamondBag;
        [SerializeField] private Collider collider;

        #endregion

        #endregion

        public void GetCollider(bool ColliderTrigger)
        {
            collider.isTrigger = ColliderTrigger;
        }
    }
}