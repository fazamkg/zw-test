using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public static class Helper
    {
        public static void Bump<T>(this Dictionary<T, int> dictionary, T key)
        {
            dictionary.TryAdd(key, 0);
            dictionary[key]++;
        }

        public static T GetValueOrCreate<T, T2>(this Dictionary<T2, T> dictionary, T2 key, Func<T> creator)
        {
            if (dictionary.ContainsKey(key) == false)
            {
                dictionary[key] = creator();
            }

            return dictionary[key];
        }

        public static T GetValueOrDefault<T, T2>(this Dictionary<T2, T> dictionary, T2 key, T defaultValue)
        {
            var exist = dictionary.TryGetValue(key, out var value);
            return exist ? value : defaultValue;
        }

        public static Vector3 GetRandomDirectionHorizontal()
        {
            Vector3 direction = Random.onUnitCircle;
            direction.z = direction.y;
            direction.y = 0f;
            return direction;
        }

        public static Vector3 SampleRandomNonOccupiedPositionOnRectGroundNonAlloc(MeshRenderer spawnArea,
            Collider collider,
            float spacing,
            List<Vector3> candidates)
        {
            candidates.Clear();

            var bounds = spawnArea.bounds;

            var min = bounds.min;
            var max = bounds.max;

            var colliderBounds = collider.bounds;
            var colliderExtents = colliderBounds.extents;

            var fromX = min.x + colliderExtents.x;
            var fromY = max.y + colliderExtents.y + Consts.SAMPLE_GROUND_OFFSET;
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
