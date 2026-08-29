using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = Consts.GAME_CONFIG_FILE_NAME, menuName = Consts.GAME_CONFIG_MENU_NAME)]
    public class GameConfig : ScriptableObject
    {
        [SerializeReference, SubclassSelector] private AnimalSpawnBehaviour _animalSpawnBehaviour;

        public AnimalSpawnBehaviour AnimalSpawnBehaviour => _animalSpawnBehaviour;
    } 
}
