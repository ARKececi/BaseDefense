using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BulletController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int _damage;
        public PoolType Type;

        #endregion

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;

        #endregion

        #region Private Variables

        

        #endregion

        #endregion

        public int SetDamage()
        {
            return _damage;
        }

        public void GetDamage(int damage)
        {
            _damage = damage;
        }

        public Rigidbody SetRigidbody()
        {
            return rigidbody;
        }

        public void ZeroVelocty()
        {
            rigidbody.velocity = Vector3.zero;
        }
        
        public void RemoveAmmo()
        {
            PoolSignalable.Instance.onListAdd?.Invoke(transform.gameObject,Type);
        }
    }
}