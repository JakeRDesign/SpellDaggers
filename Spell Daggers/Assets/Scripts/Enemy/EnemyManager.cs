using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform target = null;
    [Tooltip ("Enemy spawnrate, in seconds")]
    public float spawnRate = 2.0f;
    public List<GameObject> enemyTypes;

    private List<Enemy> instantiatedEnemies = new List<Enemy>();
    private float spawnTimer = 0;

	// Use this for initialization
	void Start ()
    {
        if (target == null)
            target = transform;
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

            newEnemy.InitiateEnemy(this);
            instantiatedEnemies.Add(newEnemy);
        }

        if (instantiatedEnemies.Count != 0)
            foreach (Enemy e in instantiatedEnemies)
            {
                e.UpdateEnemy(target);
            }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            DestroyAllEnemies();
        }
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
