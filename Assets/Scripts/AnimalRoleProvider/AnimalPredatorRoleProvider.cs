using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class AnimalPredatorRoleProvider : AnimalRoleProvider
    {
        [SerializeReference, SubclassSelector]
        private PredatorPredatorResolveBehaviour _predatorPredatorResolveBehaviour;
    } 
}
