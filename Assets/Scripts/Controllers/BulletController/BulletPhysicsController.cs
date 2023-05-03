using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BulletPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;

        #endregion

        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                WeaponSignals.Instance.onBulletEntry?.Invoke(rigidbody);
            }
            if (other.CompareTag("Plane"))
            {
                WeaponSignals.Instance.onBulletEntry?.Invoke(rigidbody);
            }
        }
    }
}