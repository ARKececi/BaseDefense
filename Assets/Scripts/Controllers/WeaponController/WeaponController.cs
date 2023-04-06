using System;
using Data.UnityObject;
using Data.ValueObject;
using UnityEngine;
using UnityEngine.Rendering;

namespace Controllers.WeaponController
{
    public class WeaponController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        public SerializedDictionary<string, WeaponData> WeaponData;

        #endregion

        #region Private Variables
        
        

        #endregion

        #endregion

        private void Awake()
        {
            WeaponData = GetWeaponData();
        }

        private SerializedDictionary<string, WeaponData> GetWeaponData()
        {
            return Resources.Load<CD_Weapon>("Data/CD_Weapon").WeaponDatas;
        }
    }
}