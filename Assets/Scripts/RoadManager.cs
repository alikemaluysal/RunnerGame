using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject player;
    public int tileLength = 30;
    public int tilesOnScreen = 120;
    private float spawnZ = 0f;
    private float safeZone = 15f;
    private List<GameObject> activeTiles = new();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        float playerZ = player.transform.position.z;

        if (playerZ - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
    {
        GameObject go = Instantiate(roadPrefab, new Vector3(0f, 0f, spawnZ), Quaternion.identity);
        activeTiles.Add(go);
        spawnZ += tileLength;


        var coinSpawner = go.GetComponent<CoinSpawner>();
        if (coinSpawner != null)
        {
            coinSpawner.SpawnCoins();
        }
    }


    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
