using Data.ValueObject;
using UnityEngine;
using UnityEngine.Rendering;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Weapon", menuName = "Data/CD_Weapon", order = 0)]
    public class CD_Weapon : ScriptableObject
    {
        public SerializedDictionary<string, WeaponData> WeaponDatas;
    }
}