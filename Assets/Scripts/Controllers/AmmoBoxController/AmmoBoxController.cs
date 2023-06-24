using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.AmmoBoxController
{
    public class AmmoBoxController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject dot;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        public GameObject PushAmmo()
        {
            var ammo = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.AmmoPackage);
            ammo.transform.position = dot.transform.position;
            return ammo;
        }
    }
}