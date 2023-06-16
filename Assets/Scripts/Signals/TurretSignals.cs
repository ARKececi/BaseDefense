using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;

namespace Signals
{
    public class TurretSignals : MonoSingleton<TurretSignals>
    {
        public Func<GameObject> onRemoveAmmo = delegate { return null;};
    }
}