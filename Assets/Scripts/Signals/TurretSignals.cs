using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class TurretSignals : MonoSingleton<TurretSignals>
    {
        public UnityAction<bool, GameObject> onTurretHold = delegate { };
        public UnityAction<GameObject> onPullAmmo = delegate { };
        public Func<bool> onFullAmmo = delegate { return true; };
        public Func<GameObject> onPushAmmo = delegate { return null; };
    }
}