using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class HostageSignalable : MonoSingleton<HostageSignalable>
    {
        public UnityAction onMining = delegate { };
    }
}