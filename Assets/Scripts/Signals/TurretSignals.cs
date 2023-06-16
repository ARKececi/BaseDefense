using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class TurretSignals : MonoSingleton<TurretSignals>
    {
        public Func<GameObject> onRemoveAmmo = delegate { return null;};
        public UnityAction<bool, GameObject> onTurretHold = delegate { };
    }
}