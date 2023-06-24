using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class AmmoBoxSignals : MonoSingleton<AmmoBoxSignals>
    {
        public UnityAction<GameObject> onAddAmmo = delegate { };
        public Func<GameObject> onPushAmmo = delegate { return null; };
    }
}