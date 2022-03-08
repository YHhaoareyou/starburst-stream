using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonSpawner : MonoBehaviour
{
    public List<GameObject> dragons = new List<GameObject>(3);
    public GameObject goal;
    public Text levelText;
    public Text scoreText;

    public static float level;
    public static int score;

    private float levelUpInterval;
    private float levelUpIntervalConst;
    private float spawnInterval;
    private float spawnIntervalOffset;
    private int lastScore;
    private static bool isPlaying;

    GameObject startButton, startHardButton, restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;

        startButton = GameObject.FindGameObjectsWithTag("StartButton")[0];
        startHardButton = GameObject.FindGameObjectsWithTag("StartHardButton")[0];
        restartButton = GameObject.FindGameObjectsWithTag("RestartButton")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (lastScore != score)
            {
                scoreText.text = score.ToString();
                lastScore = score;
            }

            spawnInterval -= Time.deltaTime;
            if (spawnInterval < 0)
            {
                SpawnDragon();
                spawnInterval = spawnIntervalOffset - level / 2;
                Debug.Log(spawnInterval);
            }

            if (level < 5) levelUpInterval -= Time.deltaTime;
            if (levelUpInterval < 0)
            {
                level++;
                levelUpInterval = levelUpIntervalConst;
                Debug.Log("Level Up: " + level);
                if (level < 5) {
                    levelText.text = ((int)level + 1).ToString();
                } else {
                    levelText.text = "∞";
                }
            }
        }
    }

    void SpawnDragon()
    {
        int dragonIdx = Random.Range(0, 3);
        Vector3 spawnNormVector = UpperFrontSpherePos();
        Vector3 spawnPosition = goal.transform.position + spawnNormVector * 30;
        // Debug.Log("===========");
        // Debug.Log("goal: " + goal.transform.position);
        // Debug.Log("spawnNormVector: " + spawnNormVector);
        // Debug.Log("spawnPosition: " + spawnPosition);
        // Debug.Log("===========");
        Instantiate(dragons[dragonIdx], spawnPosition, Quaternion.LookRotation(goal.transform.position - spawnPosition));
    }

    public void Initialize()
    {
        Debug.Log("Start!");
        isPlaying = true;
        levelUpInterval = 30;
        levelUpIntervalConst = 30;
        spawnInterval = 5;
        level = 0;
        score = 0;
        lastScore = 0;
        spawnIntervalOffset = 3;

        // Hide start/restart button
        startButton.SetActive(false);
        startHardButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void InitializeHard()
    {
        Debug.Log("Challenge!");
        isPlaying = true;
        levelUpInterval = 10;
        levelUpIntervalConst = 10;
        spawnInterval = 5;
        level = 0;
        score = 0;
        lastScore = 0;
        spawnIntervalOffset = 3;

        // Hide start/restart button
        startButton.SetActive(false);
        startHardButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void Stop()
    {
        isPlaying = false;
        restartButton.SetActive(true);
    }

    private Vector3 UpperFrontSpherePos()
    {
        Vector3 pos = new Vector3(0, 0, 0) + Random.onUnitSphere;
        pos.y = Mathf.Abs(pos.y);
        pos.z = Mathf.Abs(pos.z);
        if (pos.y > pos.z) {
            float tmp = pos.y;
            pos.y = pos.z;
            pos.z = tmp;
        }
        if (pos.x > 0.5f) {
            pos.x -= 0.5f;
        } else if (pos.x < -0.5f) {
            pos.x += 0.5f;
        }
        return pos;
    }
}
