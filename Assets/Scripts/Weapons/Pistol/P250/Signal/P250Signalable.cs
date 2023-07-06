using System;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Pistol.P250.Signal
{
    public class P250Signalable : MonoSingleton<P250Signalable>
    {
        public UnityAction onUpgrade = delegate { };
        public Func<GameObject> onSetWeapon = delegate { return null; };
    }
}