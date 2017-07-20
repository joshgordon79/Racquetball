using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float resetDelay = 1f;
    public GameObject spikes;
    public GameObject racquet;
    public GameObject ball;
    public GameObject deathParticles;
    public GameObject frontWall;
    public GameObject backWall;
    private int bounceCount;

    public static GameManager instance = null;

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        frontWall = GameObject.Find("FrontWall");
        backWall = GameObject.Find("BackWall");
        racquet = GameObject.Find("Racquet");
        ball = GameObject.Find("Ball");
        spikes = GameObject.Find("Spikes");

        deathParticles = GameObject.Find("DeathParticles");

        bounceCount = 0;

        Setup();

	}
	
    public void Setup()
    {
        spikes.SetActive(false);
    }

    private void Update()
    {
        if (bounceCount > 5)
        {
            spikes.SetActive(true);
        }
    }

    public void AddCount()
    {
        bounceCount++;
    }

    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void DeadBall()
    {
        Destroy(racquet);
        Instantiate(Resources.Load("DeathParticles"), ball.transform.position, Quaternion.identity);
        Invoke("Reset", resetDelay);
    }

}
