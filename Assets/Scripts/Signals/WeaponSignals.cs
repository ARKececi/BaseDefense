using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class WeaponSignals : MonoSingleton<WeaponSignals>
    {
        public Func<GameObject> onArm = delegate { return null; };
        public UnityAction<bool> onWeaponAnimation = delegate { };
    }
}