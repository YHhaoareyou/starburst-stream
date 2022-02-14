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
    public static string mode;
    public static int score;

    private float levelUpInterval;
    private float spawnInterval;
    private float spawnIntervalOffset;
    private int lastScore;
    private static bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
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

            }

            if (level < 9) levelUpInterval -= Time.deltaTime;
            if (levelUpInterval < 0)
            {
                level++;
                levelUpInterval = 30;
                Debug.Log("Level Up: " + level);
                levelText.text = ((int)level).ToString();
            }
        }
    }

    void SpawnDragon()
    {
        int dragonIdx = Random.Range(0, 3);
        Vector3 spawnPosition = (goal.transform.position + UpperFrontSpherePos()) * 30;
        Instantiate(dragons[dragonIdx], spawnPosition, Quaternion.LookRotation(goal.transform.position - spawnPosition));
    }

    public void Initialize()
    {
        isPlaying = true;
        levelUpInterval = 40;
        spawnInterval = 5;
        level = 0;
        score = 0;
        lastScore = 0;
        mode = "hard";
        spawnIntervalOffset = (mode == "hard") ? 5.5f : 7;

        // Display start/restart button
        GameObject startButton = GameObject.FindGameObjectsWithTag("StartButton")[0];
        startButton.SetActive(false);
        GameObject restartButton = GameObject.FindGameObjectsWithTag("RestartButton")[0];
        restartButton.SetActive(false);
    }

    static public void Stop()
    {
        isPlaying = false;
    }

    private Vector3 UpperFrontSpherePos()
    {
        Vector3 pos = Random.onUnitSphere;
        pos.y = Mathf.Abs(pos.y);
        pos.z = Mathf.Abs(pos.z);
        return pos;
    }
}
