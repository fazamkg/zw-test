# Zoo World

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
