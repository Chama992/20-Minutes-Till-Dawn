using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawser : MonoBehaviour
{
    public GameObject enemyToSpawn;
    [SerializeField] private Transform minSpawn, maxSpawn;
    [SerializeField] public float EnemyTimeToGenerate;
    [SerializeField] private Transform player;
    private List<GameObject> enemys = new List<GameObject>();
    
    private float enemyGenerateTimeCounter;

    private float despawnDistance;
    [SerializeField] private int enemyCheckCountPerFrame;
    private int enemyCheckIdxPerFrame;
    public List<WaveInfo> waves;
    private int currentWaveIdx;
    private float WaveTimeCounter;
    [SerializeField] private int treeGenerateCount;
    [SerializeField] private GameObject treeEnemy;
    [SerializeField] private Transform minMap, maxMap;
    [SerializeField] private float treeGenerateDistance;
    [SerializeField] private LayerMask treeLayerMask;
    void Start()
    {
        //enemyGenerateTimeCounter = EnemyTimeToGenerate;
        //begin first wave
        currentWaveIdx = -1;
        GoToNextWave();
        //despawn the enemy in time 
        despawnDistance = Vector2.Distance(transform.position, maxSpawn.position ) + 0.4f;
        GenerateTree();
    }

    void Update()
    {
        //enemyGenerateTimeCounter -= Time.deltaTime;
        //if (enemyGenerateTimeCounter < 0)
        //{
        //    GameObject enemy = Instantiate(enemyToSpawn, PositionToGenerate(), transform.rotation);
        //    enemy.GetComponent<Enemy>().SetTarget(player);
        //    enemyGenerateTimeCounter = EnemyTimeToGenerate;
        //    enemys.Add(enemy);
        //}
        transform.position = player.transform.position;
        if (player.gameObject.activeSelf)
        {
            WaveTimeCounter -= Time.deltaTime;
            if (WaveTimeCounter <= 0)
            {
                GoToNextWave();
            }
            else
            {
                enemyGenerateTimeCounter -= Time.deltaTime;
                if (enemyGenerateTimeCounter <= 0)
                {
                    enemyGenerateTimeCounter = waves[currentWaveIdx].timeBetweenSpawns;
                    foreach (var enemysToSpawn in waves[currentWaveIdx].enemysToSpawn)
                    {
                        GameObject enemy = Instantiate(enemysToSpawn, PositionToGenerate(), Quaternion.identity);
                        enemy.GetComponent<Enemy>().SetTarget(player);
                        enemys.Add(enemy);
                    }
                }
            }
        }
        else
        {
            DestroyEnemys();
        }
        DeleteFarEnemy();
    }

    private void DeleteFarEnemy()
    {
        int checkTarget = enemyCheckCountPerFrame + enemyCheckIdxPerFrame;
        while (enemyCheckIdxPerFrame < checkTarget)
        {
            if (enemyCheckIdxPerFrame < enemys.Count)
            {
                if (enemys[enemyCheckIdxPerFrame] != null)
                {
                    if (Vector2.Distance(transform.position, enemys[enemyCheckIdxPerFrame].transform.position) > despawnDistance)
                    {
                        Destroy(enemys[enemyCheckIdxPerFrame]);
                        enemys.RemoveAt(enemyCheckIdxPerFrame);
                        checkTarget--;
                    }
                    else
                    {
                        enemyCheckIdxPerFrame++;
                    }
                }
                else
                {
                    enemys.RemoveAt(enemyCheckIdxPerFrame);
                    checkTarget--;
                }
            }
            else
            {
                enemyCheckIdxPerFrame = 0;
                break;
            }
        }
    }
    private Vector2 PositionToGenerate()
    {
        Vector2 position = transform.position;
        //generate in random
        if (Random.Range(0f, 1f) > 0.5f)
        {
            position.y = Random.Range(minSpawn.transform.position.y, maxSpawn.transform.position.y);
            if (Random.Range(0f, 1f) < 0.5f)
                position.x = minSpawn.transform.position.x;
            else
                position.x = maxSpawn.transform.position.x;
        }
        else
        {
            position.x = Random.Range(minSpawn.transform.position.x, maxSpawn.transform.position.x);
            if (Random.Range(0f, 1f) < 0.5f)
                position.y = minSpawn.transform.position.y;
            else
                position.y = maxSpawn.transform.position.y;
        }
        return position;
    }
    private void GoToNextWave()
    {
        currentWaveIdx++;
        if (currentWaveIdx >= waves.Count)
            currentWaveIdx = 0;
        WaveTimeCounter = waves[currentWaveIdx].waveLength;
        enemyGenerateTimeCounter = waves[currentWaveIdx].timeBetweenSpawns;
    }
    private void DestroyEnemys()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            Destroy(enemys[i]);
            enemys.RemoveAt(i);
        }
    }
    private void GenerateTree()
    {
        for (int i = 0; i < treeGenerateCount; i++)
        {
            int tryCount = 10;
            while (tryCount > 0)
            {
                Vector2 position = MapRandomPoint(minMap, maxMap);
                Collider2D[] collision2D = Physics2D.OverlapCircleAll(position, treeGenerateDistance, treeLayerMask.value);
                if (collision2D != null)
                {
                    Instantiate(treeEnemy, position, Quaternion.identity);
                    break;
                }
                else
                {
                    tryCount--;
                }     
            }
        }
    }

    private Vector2 MapRandomPoint(Transform _min, Transform _max)
    {
        Vector2 position;
        position.x = Random.Range(_min.transform.position.x, _max.transform.position.x);
        position.y = Random.Range(_min.transform.position.y, _max.transform.position.y);
        return position;
    }
    
}

[System.Serializable]
public class WaveInfo 
{
    public List<GameObject> enemysToSpawn;
    public float waveLength = 10f;
    public float timeBetweenSpawns = 1f;
}
