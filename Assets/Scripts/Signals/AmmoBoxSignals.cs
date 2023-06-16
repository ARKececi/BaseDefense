using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class AmmoBoxSignals : MonoSingleton<AmmoBoxSignals>
    {
        public UnityAction<GameObject> onAddAmmo = delegate { };
    }
}