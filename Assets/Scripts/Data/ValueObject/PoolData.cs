using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Rendering;

namespace Data.ValueObject
{
    [Serializable]
    public class PoolData
    {
        public List<GameObject> PoolObj;
        public List<int> PoolCount;
    }
}