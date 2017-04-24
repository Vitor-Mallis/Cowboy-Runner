using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] obstacles;

    List<GameObject> spawnableObstacles;

    void Awake() {
        InitializeObstacles();
    }

    void InitializeObstacles() {
        spawnableObstacles = new List<GameObject>();
        int index = 0;

        for (int i = 0; i < obstacles.Length * 3; i++) {
            GameObject temp = Instantiate(obstacles[index], new Vector3(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
            spawnableObstacles.Add(temp);
            spawnableObstacles[i].SetActive(false);

            index++;
            if (index == obstacles.Length)
                index = 0;
        }

        Shuffle();
    }

    void Shuffle() {
        for (int i = 0; i < spawnableObstacles.Count; i++) {
            GameObject temp = spawnableObstacles[i];
            int random = Random.Range(0, spawnableObstacles.Count);
            spawnableObstacles[i] = spawnableObstacles[random];
            spawnableObstacles[random] = temp;
        }

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles() {
        yield return new WaitForSeconds(Random.Range(2.0f, 4.5f));

        int random = Random.Range(0, spawnableObstacles.Count);
        
        if(!spawnableObstacles[random].activeInHierarchy) {
            spawnableObstacles[random].SetActive(true);
            spawnableObstacles[random].transform.position = new Vector3(transform.position.x, transform.position.y);
        }

        StartCoroutine(SpawnObstacles());
    }
}
