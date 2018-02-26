using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;

    List<GameObject> enemyList = new List<GameObject>();

    private void OnEnable()
    {
        GameManager.OnStartGame += StartWave;
        GameManager.OnGameOver += StopWave;
    }

    private void OnDisable()
    {
        GameManager.OnStartGame -= StartWave;
        GameManager.OnGameOver -= StopWave;
    }

    private void Start()
    {
    }

    void StartWave()
    {
        ClearWave();
        StartCoroutine(WaveRoutine());
    }

    void StopWave()
    {
       StopAllCoroutines();
    }

    public IEnumerator WaveRoutine()
    {
        while(true)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(3);
        }
    }

    void ClearWave()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            Destroy(enemyList[i]);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {

        float newXPos = UnityEngine.Random.Range(-3, 3);
        float newZPos = UnityEngine.Random.Range(3, 7);
        transform.position = new Vector3(newXPos, 0, newZPos);

        GameObject tmp = Instantiate(enemy, new Vector3(newXPos, 0, newZPos), Quaternion.identity);
        enemyList.Add(tmp);
    }
}
