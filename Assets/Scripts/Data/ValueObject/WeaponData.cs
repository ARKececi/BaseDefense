using System;
using Enums;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class WeaponData
    {
        public WeaponType WeaponType;
        public float FlicTime;
        public GameObject Weapon;

    }
}