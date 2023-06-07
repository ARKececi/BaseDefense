using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class HostageDefaultSignalable : MonoSingleton<HostageDefaultSignalable>
    {
        public UnityAction Reset = delegate { };
    }
}