using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Miner", menuName = "Data/CD_Miner", order = 0)]
    public class CD_Miner : ScriptableObject
    {
        public MinerData MinerData;
    }
}