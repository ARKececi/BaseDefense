using System;
using System.Collections.Generic;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signalable;
using Signals;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Extentions
{
    public class WeaponBaseState : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> _bulletList;

        #endregion

        #region Protected Variables

        protected virtual float fireRate { get; set; }
        protected virtual GameObject barrelBase { get; set; }
        protected int damage { get; set; }
        protected SerializedDictionary<string, WeaponData> WeaponData;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private SerializedDictionary<string, WeaponData> GetWeaponData()
        {
            return Resources.Load<CD_Weapon>("Data/CD_Weapon").WeaponDatas;
        }

        private void Awake()
        {
            WeaponData = GetWeaponData();
        }

        protected virtual void Fire()
        {
            var bulletObj = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.Bullet);
            BulletController bulletController = bulletObj.GetComponent<BulletController>();
            Rigidbody bulletRigidbody = bulletController.SetRigidbody();
            bulletController.ZeroVelocty();
            bulletController.GetDamage(damage);
            bulletController.transform.gameObject.SetActive(true);
            bulletController.transform.position = barrelBase.transform.position;
            bulletController.transform.eulerAngles = barrelBase.transform.eulerAngles;
            bulletRigidbody.AddForce(barrelBase.transform.forward * 20,ForceMode.VelocityChange);
        }
    }
}