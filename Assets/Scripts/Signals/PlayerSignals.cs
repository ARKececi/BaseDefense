using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction onTargetWall = delegate { };
        public UnityAction onSafeHouse = delegate { };
        public UnityAction<bool> onWeaponActive = delegate { };
    }
}