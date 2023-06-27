using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class TransporterManSignalable : MonoSingleton<TransporterManSignalable>
    {
        public UnityAction<GameObject> onTurretList = delegate { };
        public UnityAction<GameObject> onRemoveTurretList = delegate { };
        public UnityAction onTarget = delegate { };
        public Func<GameObject> onPushAmmo = delegate { return null; };
    }
}