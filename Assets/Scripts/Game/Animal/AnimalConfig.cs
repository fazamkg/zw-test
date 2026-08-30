using UnityEngine;
using Core;
using System;

namespace Game
{
    [CreateAssetMenu(fileName = Consts.ANIMAL_CONFIG_FILE_NAME, menuName = Consts.ANIMAL_CONFIG_MENU_NAME)]
    public class AnimalConfig : ScriptableObject
    {
        [SerializeField] private string _name = Consts.ANIMAL_DEFAULT_NAME;
        [SerializeField] private AnimalVisual _animalVisual;
        [SerializeReference, SubclassSelector] private AnimalRoleProvider _animalRoleProvider =
            new AnimalStaticRoleProvider();
        [SerializeReference, SubclassSelector] private MovementBehaviour _movementBehaviour =
            new LinearMovementBehaviour();

        public string Name => _name;
        public AnimalVisual AnimalVisual => _animalVisual;
        public AnimalRoleProvider AnimalRoleProvider => _animalRoleProvider;
        public MovementBehaviour MovementBehaviour => _movementBehaviour;

        public void Validate()
        {
            if (_animalVisual == null)
            {
                throw new Exception($"Animal visual prefab reference was null on AnimalConfig {name}." +
                    $" Please fill in the reference");
            }

            if (_animalRoleProvider == null)
            {
                throw new Exception($"Animal role provider was null on AnimalConfig {name}." +
                    $" Please select the role provider");
            }

            if (_movementBehaviour == null)
            {
                throw new Exception($"Movement behaviour was null on AnimalConfig {name}." +
                    $" Please select movement behaviour");
            }

            _animalRoleProvider.Validate();

            _movementBehaviour.Validate();
        }
    } 
}
