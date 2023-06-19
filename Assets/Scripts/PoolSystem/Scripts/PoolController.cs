using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using UnityEngine;
using UnityEngine.Rendering;

namespace Controllers.PoolController
{
    public class PoolController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<PoolType, PoolData> PoolData;

        public SerializedDictionary<PoolType, PoolChange> PoolChanges;
        
        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject place;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private void Awake()
        {
            PoolData = GetWeaponData();
            foreach (var VARIABLE in PoolData.Keys)
            {
                PoolChanges.Add(VARIABLE,new PoolChange());
            }

            Pooling();
        }
        
        private SerializedDictionary<PoolType, PoolData> GetWeaponData()
        {
            return Resources.Load<CD_Pool>("Data/CD_Pool").PoolDatas;
        }
        
        private void Pooling()
        {
            foreach (var PoolType in PoolData.Keys)
            {
                GameObject PoolObj = PoolData[PoolType].PoolObj;
                    int PoolCount = PoolData[PoolType].PoolCount;
                    for (int i = 0; i < PoolCount; i++)
                    {
                        var poolObj = Instantiate(PoolObj);
                        Listadd(poolObj, PoolType);
                    }
            }
        }
        
        public void Listadd(GameObject poolObj, PoolType poolType)
        {
            PoolChanges[poolType].Pool.Add(poolObj);
            poolObj.transform.SetParent(place.transform,true);
            poolObj.transform.position = Vector3.zero;
            poolObj.SetActive(false);
            if (PoolChanges[poolType].Use.Contains(poolObj))
            {
                PoolChanges[poolType].Use.Remove(poolObj);
            }
        }
        
        public GameObject ListRemove(PoolType poolType)
        {
            if (PoolChanges[poolType].Pool.Count != 0)
            {
                GameObject poolObj = PoolChanges[poolType].Pool[0];
                PoolChanges[poolType].Use.Add(poolObj);
                poolObj.SetActive(true);
                if (PoolChanges[poolType].Pool.Contains(poolObj))
                {
                    PoolChanges[poolType].Pool.Remove(poolObj);
                }
                return poolObj;
            }
            else return null;
        }
    }
}