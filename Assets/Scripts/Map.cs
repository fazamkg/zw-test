using UnityEngine;

namespace Game
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _spawnArea;

        public MeshRenderer SpawnArea => _spawnArea;
    } 
}
