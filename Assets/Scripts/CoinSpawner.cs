using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 5;
    public float horizontalRange = 2f;
    public float minZ = 5f;
    public float maxZ = 25f;

    private bool spawned = false;

    public void SpawnCoins()
    {
        if (spawned || coinPrefab == null)
            return;

        for (int i = 0; i < coinCount; i++)
        {
            float z = Random.Range(minZ, maxZ);
            float x = Random.Range(-horizontalRange, horizontalRange);
            Vector3 coinPos = transform.position + new Vector3(x, 0.3f, z);

            GameObject coin = Instantiate(coinPrefab, coinPos, Quaternion.identity);
            coin.transform.SetParent(transform); 
        }

        spawned = true;
    }
}
