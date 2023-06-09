using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class BasketSignalable : MonoSingleton<BasketSignalable>
    {
       public UnityAction<GameObject> onDiamondAdd = delegate { };
    }
}