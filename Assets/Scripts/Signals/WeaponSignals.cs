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
        public Func<bool> onEnemyTrigger = delegate { return false; };
        public Func<Rigidbody> onBulletExit = delegate { return null; };
        public UnityAction<Rigidbody> onBulletEntry = delegate { };
        public Func<GameObject> onBarrel = delegate { return null;};
        public UnityAction<int> onDamageAssigment = delegate { };
        public UnityAction<string> onSetWeaponFunction = delegate { };
    }
}