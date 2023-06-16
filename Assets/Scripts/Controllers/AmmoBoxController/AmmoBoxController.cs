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

        private bool _full;

        #endregion

        #endregion

        public void Full(bool AmmoFull)
        {
            _full = AmmoFull;
        }

        public void CreateAmmo()
        {
            if (_full == false)
            {
                var ammo = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.AmmoPackage);
                ammo.transform.position = dot.transform.position;
                AmmoBoxSignals.Instance.onAddAmmo?.Invoke(ammo);
            }
        }
    }
}