using System;
using System.Collections.Generic;
using UnityEngine;
using WhizzBang.Spawners;

namespace WhizzBang.Data
{
    [Serializable]
    public struct SpawnableStruct
    {
        public SpawnableObject prefab;
        [Range(0f, 10f)]
        public float chanceWeightToSpawn;
    }

    [CreateAssetMenu(fileName = "SpawnerData", menuName = "WhizzBang/SpawnerData", order = 0)]
    public class SpawnerData : ScriptableObject
    {
        public Vector2 spawnDelayTimeRange;
        public List<SpawnableStruct> objectsToSpawn;
    }
}