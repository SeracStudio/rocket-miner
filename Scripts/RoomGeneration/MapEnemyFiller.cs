using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemyFiller : MonoBehaviour
{
    public List<EnemySpawnStats> enemyPool;
    public List<EnemySpawnStats> bossPool;
    public EnemySpawnStats specificEnemy;

    private List<EnemySpawnStats>[] floorsPool;

    private void Awake()
    {
        floorsPool = new List<EnemySpawnStats>[5];

        for (int i = 0; i < 5; i++)
        {
            floorsPool[i] = new List<EnemySpawnStats>();

            foreach (EnemySpawnStats enemy in enemyPool)
            {
                if (enemy.floors.x <= (i + 1) && enemy.floors.y >= (i + 1))
                    floorsPool[i].Add(enemy);
            }
        }
    }

    public void FillMapWithEnemies(Dictionary<Vector3, MapRoom> map, int floor)
    {
        foreach (MapRoom room in map.Values)
        {
            if (room.type == RoomType.NORMAL)
                //room.enemies = SpecificEnemyPool(specificEnemy, 1);
                room.enemies = RandomEnemyPool((floor + 1) * 3, floor);

            if (room.type == RoomType.BOSS)
                room.enemies.Add(bossPool[floor]);
        }
    }

    public List<EnemySpawnStats> RandomEnemyPool(int totalDanger, int floor)
    {
        List<EnemySpawnStats> randomEnemies = new List<EnemySpawnStats>();
        while (totalDanger > 0)
        {
            EnemySpawnStats enemy = floorsPool[floor][Random.Range(0, floorsPool[floor].Count)];
            if (totalDanger - enemy.danger < 0) continue;
            totalDanger -= enemy.danger;
            randomEnemies.Add(enemy);
        }
        return randomEnemies;
    }

    public List<EnemySpawnStats> SpecificEnemyPool(EnemySpawnStats enemy, int quantity)
    {
        List<EnemySpawnStats> specificEnemy = new List<EnemySpawnStats>(quantity);

        for (int i = 0; i < quantity; i++)
        {
            specificEnemy.Add(enemy);
        }

        return specificEnemy;
    }
}
