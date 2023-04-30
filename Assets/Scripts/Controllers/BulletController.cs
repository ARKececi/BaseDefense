using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BulletController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                WeaponSignals.Instance.onBulletEntry?.Invoke(rigidbody);    
            }
        }
    }
}