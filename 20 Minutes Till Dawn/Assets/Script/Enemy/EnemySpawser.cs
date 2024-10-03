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
    
    void Start()
    {
        enemyGenerateTimeCounter = EnemyTimeToGenerate;
        //despawn the enemy in time 
        despawnDistance = Vector2.Distance(transform.position, maxSpawn.position ) + 0.4f;
    }

    void Update()
    {
        enemyGenerateTimeCounter -= Time.deltaTime;
        transform.position = player.transform.position;
        if (enemyGenerateTimeCounter < 0)
        {
            GameObject enemy = Instantiate(enemyToSpawn, PositionToGenerate(), transform.rotation);
            enemy.GetComponent<Enemy>().SetTarget(player);
            enemyGenerateTimeCounter = EnemyTimeToGenerate;
            enemys.Add(enemy);
        }
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
}
