using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class Helper
    {
        public static Vector3 GetRandomDirectionHorizontal()
        {
            Vector3 direction = Random.onUnitCircle;
            direction.z = direction.y;
            direction.y = 0f;
            return direction;
        }

        public static Vector3 SampleRandomNonOccupiedPositionOnRectGroundNonAlloc(MeshRenderer ground,
            Collider collider,
            float spacing,
            List<Vector3> candidates)
        {
            candidates.Clear();

            var bounds = ground.bounds;

            var min = bounds.min;
            var max = bounds.max;

            var colliderBounds = collider.bounds;
            var colliderExtents = colliderBounds.extents;

            var fromX = min.x + colliderExtents.x;
            var fromY = max.y + colliderExtents.y;
            var fromZ = min.z + colliderExtents.z;

            var toX = max.x - colliderExtents.x;
            var toZ = max.z - colliderExtents.z;

            for (var currentX = fromX; currentX < toX; currentX += spacing)
            {
                for (var currentZ = fromZ; currentZ < toZ; currentZ += spacing)
                {
                    var currentPosition = new Vector3(currentX, fromY, currentZ);

                    var isOccupied = Physics.CheckBox(currentPosition, colliderExtents);

                    if (!isOccupied)
                    {
                        candidates.Add(currentPosition);
                    }
                }
            }

            if (candidates.Count == 0)
            {
                Debug.LogError("No empty cells found!");
                return Vector3.zero;
            }

            var randomIndex = Random.Range(0, candidates.Count);
            return candidates[randomIndex];
        }

        public static T GetRandom<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    } 
}
