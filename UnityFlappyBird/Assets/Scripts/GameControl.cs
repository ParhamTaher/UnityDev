using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -3f;
    public float obstacleSpawnX = 8f;
    public float obstacleSpawnRate = 3f;
    public float obstacleMinY = -3.5f;
    public float obstacleMaxY = 1.0f;
    public float ringOffsetX = 2f;

    private int score = 0;

	// Use this for initialization (Singleton pattern)
	void Awake () {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver && Input.GetMouseButtonDown(0)) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
		
	}

    public float getSpawnYPosition() {
        return Random.Range(GameControl.instance.obstacleMinY, GameControl.instance.obstacleMaxY);
    }

    public void BirdScored() {

        if (gameOver) {
            
            return;
        
        } else {

            score++;
            scoreText.text = "Score: " + score.ToString();

        }
        
    }

    public void BirdDied() {
        
        gameOverText.SetActive(true);
        gameOver = true;
        
    }

    public void SetScrollSpeed(float speed) {
        scrollSpeed = speed;
    }

    public void SetColSpawnXPosition(float pos)
    {
        obstacleSpawnX = pos;
    }

    public void SetColSpawnRate(float rate)
    {
        obstacleSpawnRate = rate;
    }

    public void setRingOffsetX(float offset)
    {
        ringOffsetX = offset;
    }

}
