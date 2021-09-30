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
        [Header("Rotation")]
        [Range(0f, 360f)]
        [SerializeField] private float yRotation;
        [SerializeField] private bool randomYRotation;

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
            if(gameObject.activeInHierarchy == false) return;
            
            StartCoroutine(SpawnCoroutine(useDelay));
        }

        private IEnumerator SpawnCoroutine(bool useDelay)
        {
            if (useDelay)
            {
                var delayTime = Random.Range(spawnerData.spawnDelayTimeRange.x, spawnerData.spawnDelayTimeRange.y);
                yield return new WaitForSeconds(delayTime);
            }
            var prefab = GetRandomSpawnableObject();
            var prefabRotation = prefab.transform.rotation;
            var rotation = Quaternion.Euler(prefabRotation.x, randomYRotation ? Random.Range(0f, 360f) : yRotation, prefabRotation.z);
            var spawnedObject = Instantiate(prefab, transform.position, rotation, transform);
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
