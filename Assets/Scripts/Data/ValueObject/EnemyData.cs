using System;
using UnityEngine.Serialization;

namespace Data.ValueObject
{
    [Serializable]
    public class EnemyData
    {
        public int Healt;
        public int Damage;
        public int NormalSpeed;
        public int FastSpeed;
    }
}