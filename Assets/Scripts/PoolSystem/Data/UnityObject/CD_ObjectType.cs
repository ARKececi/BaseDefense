using System;
using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using UnityEngine;
using UnityEngine.Rendering;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_ObjectType", menuName = "Data/CD_ObjectType", order = 0)]
    public class CD_ObjectType : ScriptableObject
    {
        public SerializedDictionary<PoolType, List<string>> ObjectType;
    }
}