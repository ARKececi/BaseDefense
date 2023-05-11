using System;
using System.Collections.Generic;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.BossController
{
    public class BossController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> grenadeList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject hand;
        [SerializeField] private GameObject grenade;

        #endregion

        #region Private Variables

        private int _count;

        #endregion

        #endregion

        private void Awake()
        {
            for (int i = 0; i < 5; i++)
            {
                var grenadeObj = Instantiate(grenade);
                grenadeList.Add(grenadeObj);
            }
        }

        public void Fire()
        {

            if (_count <= grenadeList.Count)
            {

            }
            
        }
    }
}