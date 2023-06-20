using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class HostagePickerSignalable : MonoSingleton<HostagePickerSignalable>
    {
        public UnityAction<GameObject> onMoneyListAdd = delegate { };
        public UnityAction<GameObject> onMoneyListRemove = delegate { };
        public Func<GameObject> onHome = delegate { return null;};
    }
}