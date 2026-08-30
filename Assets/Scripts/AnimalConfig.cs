using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = Consts.ANIMAL_CONFIG_FILE_NAME, menuName = Consts.ANIMAL_CONFIG_MENU_NAME)]
    public class AnimalConfig : ScriptableObject
    {
        [SerializeField] private string _name = Consts.ANIMAL_DEFAULT_NAME;
        [SerializeField] private AnimalVisual _animalVisual;
        [SerializeReference, SubclassSelector] private AnimalRoleProvider _animalRoleProvider;
        [SerializeReference, SubclassSelector] private MovementBehaviour _movementBehaviour;

        public string Name => _name;
        public AnimalVisual AnimalVisual => _animalVisual;
        public AnimalRoleProvider AnimalRoleProvider => _animalRoleProvider;
        public MovementBehaviour MovementBehaviour => _movementBehaviour;
    } 
}
