using System;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;

namespace Managers
{
    public class WeaponManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<string, WeaponData> WeaponData;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject weaponBag;
        [SerializeField] private GameObject arm;

        #endregion

        #region Private Variables

        private GameObject _weaponPoint;

        #endregion

        #endregion

        private void Awake()
        {
            WeaponData = GetWeaponData();
            WeaponInstantiate();
        }

        private void Start()
        {
            arm = WeaponSignals.Instance.onArm?.Invoke();
            weaponBag.transform.SetParent(arm.transform);
            weaponBag.transform.localPosition = Vector3.zero;
            weaponBag.transform.localRotation = Quaternion.Euler(0,0,0);
        }

        private SerializedDictionary<string, WeaponData> GetWeaponData()
        {
            return Resources.Load<CD_Weapon>("Data/CD_Weapon").WeaponDatas;
        }

        private void WeaponInstantiate()
        {
            foreach (var Weapon in WeaponData)
            {
                GameObject weapon = Instantiate(Weapon.Value.Weapon, weaponBag.transform, true);
                if (Weapon.Value.WeaponType == WeaponType.Pistol)
                {
                    weapon.transform.SetParent(weaponBag.transform.GetChild(0));
                    weapon.transform.localPosition = new Vector3(0, 0, -0);
                    weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    weapon.SetActive(false);
                }
                else if (Weapon.Value.WeaponType == WeaponType.Rifle)
                {
                    weapon.transform.SetParent(weaponBag.transform.GetChild(1));
                    weapon.transform.localPosition = new Vector3(0, 0, -0);
                    weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    weapon.SetActive(false);
                }
            }
        }

        private void WeaponSetActive()
        {
            
        }
    }
}