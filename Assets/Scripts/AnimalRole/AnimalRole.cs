using System;

namespace Game
{
    // I use Visitor pattern here. This does not scale well if we are going to
    // add many roles since every new role will require changing all existing roles.
    // BUT this solution makes it harder to miss a new interaction between roles unlike
    // other approaches like switch or dictionary.
    //
    // I think it makes sense because
    // game designers probably won't go for 1000 roles since it will explode in
    // too many possible interactions. So safety (to make sure atleast all existing interaction are covered)
    // generally matters more here than scalability.

    [Serializable]
    public abstract class AnimalRole
    {
        public abstract void OnCollision(AnimalRole roleA, AnimalCollisionContext context);

        public abstract void CollideWithPrey(AnimalPreyRole roleB, AnimalCollisionContext context);

        public abstract void CollideWithPredator(AnimalPredatorRole roleB, AnimalCollisionContext context);
    } 
}
