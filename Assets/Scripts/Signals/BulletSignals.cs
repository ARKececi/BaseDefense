using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class BulletSignals : MonoSingleton<BulletSignals>
    {
        public UnityAction<int> onDamage = delegate { };
    }
}