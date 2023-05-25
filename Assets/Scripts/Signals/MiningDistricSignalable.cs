using System;
using System.Collections.Generic;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;

namespace Signals
{
    public class MiningDistricSignalable : MonoSingleton<MiningDistricSignalable>
    {
        public Func<List<GameObject>> onCoalsList = delegate { return null; };
    }
}