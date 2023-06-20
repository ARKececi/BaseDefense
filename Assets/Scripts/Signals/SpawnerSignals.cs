using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class SpawnerSignals : MonoSingleton<SpawnerSignals>
    {
        public UnityAction<bool> onFullMiner = delegate { };
    }
}