using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private int numberOfPlatforms = 20;
    [SerializeField] private float levelWidth = 3f;
    [SerializeField] private float minY = 0.5f;
    [SerializeField] private float maxY = 1.5f;

    private List<GameObject> platforms = new List<GameObject>();
    private float highestPoint;

    void Start()
    {
        if (platformPrefab == null)
        {
            Debug.LogError("Error: Platform Prefab is not assigned in Level Generator! Please drag the Platform prefab into the slot.");
            return;
        }

        Vector3 spawnPosition = new Vector3();

        // 🟢 Add a starting platform under the player so they don't fall immediately
        GameObject hitPlatform = Instantiate(platformPrefab, new Vector3(0, -2f, 0), Quaternion.identity);
        platforms.Add(hitPlatform);

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
        highestPoint = spawnPosition.y;
    }

    void Update()
    {
        if (Camera.main == null) return;

        float cameraY = Camera.main.transform.position.y;
        // Recycle platforms that are well below the camera view
        float deleteThreshold = cameraY - 10f; 

        foreach (GameObject platform in platforms)
        {
             if (platform.transform.position.y < deleteThreshold)
             {
                 RecyclePlatform(platform);
             }
        }
    }
    
    void RecyclePlatform(GameObject platform)
    {
        highestPoint += Random.Range(minY, maxY);
        Vector3 newPos = new Vector3(Random.Range(-levelWidth, levelWidth), highestPoint, 0);
        platform.transform.position = newPos;
    }
}
