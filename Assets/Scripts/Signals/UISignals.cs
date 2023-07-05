using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanel> onOpenPanel = delegate { };
        public UnityAction<UIPanel> onClosePanel = delegate { };
    }
}