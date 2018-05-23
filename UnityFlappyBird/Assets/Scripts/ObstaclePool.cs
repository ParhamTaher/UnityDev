using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public int obstaclePoolSize = 5;
    public GameObject columnPrefab;
    public GameObject ringPrefab;

    private GameObject[] columns;
    private GameObject[] rings;
    private Vector2 colPoolPosition = new Vector2(-15f, -25f);
    private Vector2 ringPoolPosition = new Vector2(-25f, -25f);
    private float startTime = 0;
    private float distanceTravelled = 0;
    private int currentObstacle = 0;
    private bool hasLoopedOnce = false;
    private float ringOffsetY = 0f;

	// Use this for initialization
	void Start () {

        columns = new GameObject[obstaclePoolSize];
        rings = new GameObject[obstaclePoolSize];

        for (int i = 0; i < obstaclePoolSize; i++)
        {

            columns[i] = (GameObject)Instantiate(columnPrefab, colPoolPosition, Quaternion.identity);
            rings[i] = (GameObject)Instantiate(ringPrefab, ringPoolPosition, Quaternion.identity);

        }

    }
	
    // Update is called once per frame
	void Update () {

        startTime += Time.deltaTime;
        distanceTravelled = (GameControl.instance.scrollSpeed * startTime);


        if (GameControl.instance.gameOver == false && distanceTravelled <= -7f) {

            startTime = 0f;
            distanceTravelled = 0f;

            float spawnYPosition = Random.Range(GameControl.instance.obstacleMinY, GameControl.instance.obstacleMaxY);

            columns[currentObstacle].transform.position = new Vector2(GameControl.instance.obstacleSpawnX, spawnYPosition);

            if (spawnYPosition >= -1f)
            {
                ringOffsetY = Random.Range(-1f, 2.0f);
            } else if (spawnYPosition < -1f)
            {
                ringOffsetY = Random.Range(0f, -2.0f);
            } else
            {
                ringOffsetY = Random.Range(2.0f, -2.0f);
            }

            rings[currentObstacle].transform.position = new Vector2(GameControl.instance.obstacleSpawnX + 3.5f, spawnYPosition + 2.0f + ringOffsetY);


            currentObstacle++;

            if (currentObstacle >= obstaclePoolSize)
            {
                currentObstacle = 0;
            }


        }
		
	}
}
