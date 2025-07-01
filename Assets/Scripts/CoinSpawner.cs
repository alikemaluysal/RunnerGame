using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 1;
    public float horizontalRange = 50f;
    public float minZ = 5f;
    public float maxZ = 25f;
    public int minCoins = 0;             
    public int maxCoins = 1;            


    private bool spawned = false;

    public void SpawnCoins()
    {
        if (spawned || coinPrefab == null)
            return;


        int coinCount = Random.Range(minCoins, maxCoins + 1);

        for (int i = 0; i < coinCount; i++)
        {
            float z = Random.Range(minZ, maxZ);
            float x = Random.Range(-horizontalRange, horizontalRange);
            Vector3 coinPos = transform.position + new Vector3(x, 2.5f, z);

            GameObject coin = Instantiate(
                coinPrefab,
                coinPos,
                Quaternion.Euler(0f, 90f, 90f)
            );
            coin.transform.SetParent(transform, true);
        }

        spawned = true;
    }


}
