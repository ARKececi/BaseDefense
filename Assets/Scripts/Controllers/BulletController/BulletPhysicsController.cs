using System;
using Enums;
using Signalable;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                PoolSignalable.Instance.onListAdd?.Invoke(transform.gameObject,PoolType.BulletNormal);
            }
        }
    }
}