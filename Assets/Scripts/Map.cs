using UnityEngine;

namespace Game
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _ground;

        public MeshRenderer Ground => _ground;
    } 
}
