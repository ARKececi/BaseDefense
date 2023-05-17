using System;
using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signalable
{
    public class PoolSignalable : MonoSingleton<PoolSignalable>
    {
        public UnityAction<GameObject,PoolType> onListAdd = delegate {  };
        public Func<PoolType,GameObject> onListRemove = delegate { return null;};
    }
}