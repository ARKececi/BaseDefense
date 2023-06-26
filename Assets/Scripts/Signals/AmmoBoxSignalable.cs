using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class AmmoBoxSignalable : MonoSingleton<AmmoBoxSignalable>
    {
        public Func<GameObject> onPushAmmo = delegate { return null; };
        public Func<GameObject> onPlace = delegate { return null;};
    }
}