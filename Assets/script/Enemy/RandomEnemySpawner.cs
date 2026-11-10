using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [Header("敵人")]
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [Header("生成設定")]
    [SerializeField, Min(0f)]
    private float firstSpawnDelay = 1f;

    [SerializeField, Min(0.1f)]
    private float spawnInterval = 2f;

    [Header("生成範圍")]
    [SerializeField]
    private float minX = -3f;

    [SerializeField]
    private float maxX = 3f;

    void OnEnable()
    {
        InvokeRepeating(nameof(SpawnRandomEnemy), firstSpawnDelay, spawnInterval);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("RandomEnemySpawner 沒有設定敵人 Prefab。");
            CancelInvoke();
            return;
        }

        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject selectedPrefab = enemyPrefabs[randomIndex];

        if (selectedPrefab == null)
        {
            Debug.LogWarning($"Enemy Prefabs 的索引 {randomIndex} 尚未設定。"); return;
        }

        float spawnX = Random.Range(Mathf.Min(minX, maxX), Mathf.Max(minX, maxX));

        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0f);

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}