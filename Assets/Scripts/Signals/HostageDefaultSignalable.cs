using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class HostageDefaultSignalable : MonoSingleton<HostageDefaultSignalable>
    {
        public UnityAction<GameObject> Reset = delegate { };
        public UnityAction hostageStackRemove = delegate { };
    }
}