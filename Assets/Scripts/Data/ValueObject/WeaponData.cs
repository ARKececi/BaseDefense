using System;
using Enums;
using UnityEngine;
using UnityEngine.UIElements;
using Image = System.Drawing.Image;

namespace Data.ValueObject
{
    [Serializable]
    public class WeaponData
    {
        public WeaponType WeaponType;
        public float FlicTime;
        public int Damage;
        public GameObject Weapon;
        public Texture2D Image;

    }
}