using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Rifle.AK_47.Signal
{
    public class AK_47Signalable : MonoSingleton<AK_47Signalable>
    {
        public UnityAction onUpgrade = delegate { };
    }
}