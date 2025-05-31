using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public float spawnInterval = 2f;
    public float spawnZ = 20f;
    public float moveSpeed = 5f;

    private float[] lanes = new float[] { -2f, 0f, 2f };
    private int[] laneStreaks = new int[3];

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnRandomObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomObstacle()
    {
        if (obstaclePrefabs.Count == 0) return;

        int laneIndex = GetSafeLaneIndex();
        int prefabIndex = Random.Range(0, obstaclePrefabs.Count);

        Vector3 spawnPos = new Vector3(lanes[laneIndex], 0.5f, spawnZ);
        GameObject obstacle = Instantiate(obstaclePrefabs[prefabIndex], spawnPos, Quaternion.identity);

        Rigidbody rb = obstacle.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = obstacle.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }

        UpdateLaneStreaks(laneIndex);

        StartCoroutine(MoveObstacle(obstacle));
    }

    int GetSafeLaneIndex()
    {
        List<int> avaliableLanes = new List<int>();

        for(int i = 0; i < laneStreaks.Length; i++)
        {
            if (laneStreaks[i] == 2)
                avaliableLanes.Add(i);
        }
        if(avaliableLanes.Count == 0)
        {
            for(int i = 0; i < laneStreaks.Length; i++)
                laneStreaks[i] = 0;
            return Random.Range(0, lanes.Length);
        }
        return avaliableLanes[Random.Range(0, avaliableLanes.Count)];
    }

    void UpdateLaneStreaks(int selectedLane)
    {
        for (int i = 0; i < laneStreaks.Length; i++)
        {
            if (i == selectedLane)
                laneStreaks[i]++;
            else
                laneStreaks[i] = 0;
        }
    }
    IEnumerator MoveObstacle(GameObject obstacle)
    {
        while (obstacle.transform.position.z > -5f)
        {
            obstacle.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(obstacle);
    }
}
