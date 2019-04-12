using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform target = null;
    [Tooltip ("Enemy spawnrate, in seconds")]
    public float spawnRate = 2.0f;
    public List<GameObject> enemyTypes;

    public float spawnRateDecrease = 0.1f;
    public float spawnRateDecreaseRate = 5.0f;
    [Range (0.1f, 5.0f)]
    public float spawnRateCap = 0.1f;
    public int spawnRadius = 75.0f;

    private List<Enemy> instantiatedEnemies = new List<Enemy>();
    private float spawnTimer = 0;
    private float initialSpawnRate;

	// Use this for initialization
	void Start ()
    {
        if (target == null)
            target = transform;

        initialSpawnRate = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnRate)
        {
            spawnTimer -= spawnRate;

            GameObject inst = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], transform.position, Quaternion.identity);
            Enemy newEnemy = inst.GetComponent<Enemy>();

            Vector2 spawnDir = Random.insideUnitCircle.normalized;
            inst.transform.position = new Vector3(spawnDir.x, spawnDir.y, 0) * spawnRadius + transform.position;

            newEnemy.InitiateEnemy(this);
            instantiatedEnemies.Add(newEnemy);
        }

        if (instantiatedEnemies.Count != 0)
            foreach (Enemy e in instantiatedEnemies)
            {
                e.UpdateEnemy(target);
            }

        spawnRate = initialSpawnRate - (int)(Time.time / spawnRateDecreaseRate) * spawnRateDecrease;
        if (spawnRate < spawnRateCap)
            spawnRate = spawnRateCap;
	}

    public void DestroyEnemy(Enemy e)
    {
        instantiatedEnemies.Remove(e);
        Destroy(e.gameObject);
    }

    public void DestroyAllEnemies()
    {
        for (int i = instantiatedEnemies.Count - 1; i >= 0; --i)
        {
            DestroyEnemy(instantiatedEnemies[i]);
        }

    }
}
