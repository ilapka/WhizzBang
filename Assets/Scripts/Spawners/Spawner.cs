using System;
using System.Collections;
using UnityEngine;
using WhizzBang.Data;
using Random = UnityEngine.Random;

namespace WhizzBang.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnerData spawnerData;

        private float _totalSpawnWeight;

        void Start()
        {
            foreach (var spawnableStruct in spawnerData.objectsToSpawn)
            {
                _totalSpawnWeight += spawnableStruct.chanceWeightToSpawn;
            }
            SpawnObject(false);
        }

        private void SpawnObject(bool useDelay)
        {
            StartCoroutine(SpawnCoroutine(useDelay));
        }

        private IEnumerator SpawnCoroutine(bool useDelay)
        {
            if (useDelay)
            {
                var delayTime = Random.Range(spawnerData.spawnDelayTimeRange.x, spawnerData.spawnDelayTimeRange.y);
                yield return new WaitForSeconds(delayTime);
            }
            var spawnedObject = Instantiate(GetRandomSpawnableObject(), transform);
            spawnedObject.OnDestroyEvent.AddListener(() =>
            {
                SpawnObject(true);
            });
        }

        private SpawnableObject GetRandomSpawnableObject()
        {
            var randomSpawnWeight = Random.Range(0f, _totalSpawnWeight);
            var currentSpawnWeight = 0f;
            foreach (var spawnableStruct in spawnerData.objectsToSpawn)
            {
                currentSpawnWeight += spawnableStruct.chanceWeightToSpawn;
                if (randomSpawnWeight <= currentSpawnWeight)
                {
                    return spawnableStruct.prefab;
                }
            }
            
            throw new Exception("Random spawnable object not found");
        }
    }
}
