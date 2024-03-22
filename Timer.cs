using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] List<GameObject> itemToSpawn;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject gameOverPanel;
    protected float elapsedTime;
    AudioManager audioManager;
    public bool gameOverBool;
    private int points;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        gameOverBool = false;
        // Start invoking the method to spawn items every 5 seconds
        InvokeRepeating(nameof(SpawnItem), 0f, 3f);
        // Start invoking the method to spawn enemies every 15 seconds
        InvokeRepeating(nameof(SpawnEnemy), 0f, 15f);
        // Start invoking the method to increase enemies's speed every 60 seconds
        InvokeRepeating(nameof(IncreaseEnemySpeed), 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverBool)
        {
            return;
        }
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (elapsedTime >= 300){
            Debug.Log("Game over");
            StartCoroutine(DelayedGameOvering());
            return;
        }
        
    }
    public void SpawnItem()
    {
        Debug.Log("Generate item");
        int index = Random.Range(0, itemToSpawn.Count);
        GameObject item = itemToSpawn[index];
        ItemGenerate.instance.generateItemMethod(item, 1);
    }

    public void SpawnEnemy()
    {
        Debug.Log("Generate Enemy");
        EnemyGenerate.instance.generateEnemyMethod(enemyToSpawn, 1);
    }

    public void IncreaseEnemySpeed()
    {
        Debug.Log("Increase enemy's speed.");
        EnemyMovement.instance.IncreaseSpeed(10);
    }

    IEnumerator DelayedGameOvering()
    {
        gameOverBool = true;
        yield return new WaitForSeconds(0.1f);
        points = testPoints.instance.GetCurrentPoint();
        TotalPoint.instance.IncreaseTotalPoints(points);
        gameOverPanel.SetActive(true);
        audioManager.PlaySFX(audioManager.gameOver);
        Time.timeScale = 0;
    }
}
