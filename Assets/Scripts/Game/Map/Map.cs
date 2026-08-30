using UnityEngine;

namespace Game
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MeshRenderer _spawnArea;

        public Camera Camera => _camera;
        public MeshRenderer SpawnArea => _spawnArea;
    } 
}
