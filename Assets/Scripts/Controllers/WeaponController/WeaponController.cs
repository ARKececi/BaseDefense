using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Controllers.WeaponController
{
    public class WeaponController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<string, WeaponData> WeaponData;
        public List<GameObject> Weapons;
        public List<string> _weaponsName;
        public List<GameObject> bulletPoolList;
        public List<Rigidbody> bulletRigidbodyList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject weaponBag;
        [SerializeField] private GameObject arm;
        [SerializeField] private List<GameObject> weaponSlot;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bulletPool;

        #endregion

        #region Private Variables

        private GameObject _weaponPoint;
        private GameObject _weapon;

        #endregion

        #endregion

        private void Awake()
        {
            WeaponData = GetWeaponData();
            WeaponInstantiate();
            BulletInstantiate();
        }

        private void Start()
        {
            SetWeaponFunction(Weapons[0]);
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
                Weapons.Add(weapon);
                if (Weapon.Value.WeaponType == WeaponType.Pistol)
                {
                    weapon.transform.SetParent(weaponSlot[0].transform);
                    weapon.transform.localPosition = new Vector3(0, 0, -0);
                    weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    weapon.SetActive(false);
                }
                else if (Weapon.Value.WeaponType == WeaponType.Rifle)
                {
                    weapon.transform.SetParent(weaponSlot[1].transform);
                    weapon.transform.localPosition = new Vector3(0, 0, -0);
                    weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    weapon.SetActive(false);
                }
                _weaponsName.Add(Weapon.Key);
                
            }
        }
        
        private void BulletInstantiate()
        {
            for (int i = 0; i < 20; i++)
            {
                var bulletObj = Instantiate(bullet);
                var bulletRigidbody = bulletObj.GetComponent<Rigidbody>();
                bulletObj.transform.SetParent(bulletPool.transform);
                bulletRigidbodyList.Add(bulletRigidbody);
                bulletObj.SetActive(false);
            }
        }

        public Rigidbody BulletPoolExit()
        {
            var Bullet = bulletRigidbodyList[0];
            bulletRigidbodyList.Remove(bulletRigidbodyList[0]);
            return Bullet ;
        }
        
        public void BulletPoolEntry(Rigidbody bullet)
        {
            bulletRigidbodyList.Add(bullet);
            bullet.transform.gameObject.SetActive(false);
        }
        
        private void SetWeaponFunction(GameObject Weapon)
        {
            _weapon = Weapon;
            if (WeaponData[_weaponsName[Weapons.IndexOf(_weapon)]].WeaponType == WeaponType.Pistol)
            {
                WeaponSignals.Instance.onWeaponAnimation?.Invoke(true);
            }
            else
            {
                WeaponSignals.Instance.onWeaponAnimation?.Invoke(false);
            }
        }

        public void WeaponSetActive(bool safebool)
        {
            _weapon.SetActive(safebool);
        }
        
        
    }
}