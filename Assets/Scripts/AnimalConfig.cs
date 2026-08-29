using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = Consts.ANIMAL_CONFIG_FILE_NAME, menuName = Consts.ANIMAL_CONFIG_MENU_NAME)]
    public class AnimalConfig : ScriptableObject
    {
        [SerializeField] private string _name = Consts.ANIMAL_DEFAULT_NAME;
        [SerializeReference, SubclassSelector] private AnimalRoleProvider _animalRoleProvider;

        public string Name => _name;
    } 
}
