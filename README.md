# Zoo World

Please boot the game from Init scene

## Requirements

### Description
3D game where you can see different animals

### Camera
Top-down

### Graphics
Simple graphics

### Gameplay
Every 1-2 seconds 1 animal appear and starts moving randomly. Animal can collide with other animals. There are walls to contain animals within area (seems like a more consistent solution than relying on out-of-screen rule from initial requirements).

### Collision matrix
|     | Prey | Predator |
|-----|------|----------|
| Prey | Fly apart by physics (in my implementation they just reflect directions) | Prey die and disappear from screen. Predator eats the prey |
| Predator | Prey die and disappear from screen. Predator eats the prey | One predator survives and other dies. (Can be actually configured) |

### Animals
| Name | Role | Movement |
|------|------|----------|
| Frog | Prey | moves by jumps every X seconds |
| Snake | Predator | moves by translation linearly |

### UI
Top right corner has counters displaying how many prey and predators are dead this session

## How to add new animal type

1. Right Click in Project window -> Create -> Game -> Animal Config
2. This creates a scriptable object for new animal type
3. Rename it to something like "Dog"
4. Set the name inside of it to "Dog" aswell (currently has no effect to anything)
5. Drag `AnimalVisual` prefab to `Animal Visual` field. This selects how animal will look like
6. Select `Animal Role Provider`. This influences how Role of Animal can change. If you want just select one role for animal, select `Animal Static Role Provider`
7. Select `Animal Role` (for example `Animal Prey Role`)
8. Select `Movement Behaviour`. Selected behaviour will have additional settings.
9. Done! You have new animal type
10. If you want new animal type to appear in game, select `Assets/ScriptableObjects/Game Config.asset`
11. And add your new animal type to `Animal Pool` field

## Architecture

We have a MonoBehaviour for an animal called `Animal`. This class works as a shell for any possible animal out there.   

The definition of the animal type is carried by `AnimalConfig` ScriptableObject class. This is the data-only class and does not have runtime state.   

The role of animal and role's rules are defined in classes inherited from abstract class `AnimalRole`. These classes follow Visitor pattern - I assume there aren't going to many roles but all possible interactions must be filled out so it should fit.   

Possible movement types are defined by classes inherited from `MovementBehaviour`. This is strategy pattern. Pretty easy to scale if new movement types are needed -> just add new class and inherit it from `MovementBehaviour`.   

I use a package called SerializeReference from MackySoft, which allows those strategies on `AnimalConfig` to be serialized and selected in inspector for designer-friendly solution.

Here is graph of architecture. Arrows show source code dependency.   
Orange = MonoBehaviour   
Blue = Interface or Abstract class   
Red = ScriptableObject   
<img width="4227" height="5018" alt="my-cool-graph" src="https://github.com/user-attachments/assets/3a120864-7568-424f-a7ac-dcadc7068569" />

