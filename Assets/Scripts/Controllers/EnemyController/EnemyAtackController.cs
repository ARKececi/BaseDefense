using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyAtackController : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private int _damage;

        #endregion

        #endregion

        public void GetDamage(int Damage)
        {
            _damage = Damage;
        }
        
        public int Setdamage()
        {
            return _damage;
        }
    }
}