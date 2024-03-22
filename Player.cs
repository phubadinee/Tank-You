using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : CharacterSelection
{

    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject gameWinPanel;
    public int maxHealth;
    public int currentHealth;
    private int points;
    public HealthBar healthBar;
    public ResourceBarTracker srcValue;

    private bool gameOver;
    private bool gameWin, winning;
    public static Player instance;

    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        instance = this;
    }

    new void Start()
    {
        gameWin = false;
        winning = false;
        // base.Start();
        if (returnCharacter != null) {
            currentHealth = returnCharacter.getHpBase();  
        } else {
            currentHealth = maxHealth;
        }
        gameOver = false;
        Debug.Log("Player Health = " + currentHealth);
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(winning)
        {
            return;
        }
        if(gameOver)
        {
            return;
        }
        if(gameWin)
        {
            Debug.Log("Game Win");
            audioManager.Stop();
            StartCoroutine(DelayedGameWin());
            return;
        }
        if(currentHealth <= 0)
        {
            Debug.Log("Game Over");
            audioManager.Stop();
            currentHealth = 0;
            StartCoroutine(DelayedGameOver());
            return;
        }
        gameWin = testPoints.instance.WinGame();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
    public void TakeHeal(int heal)
    {
        audioManager.PlaySFX(audioManager.collectHeal);
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    
    
    IEnumerator DelayedGameOver()
    {
        gameOver = true;
        yield return new WaitForSeconds(0.1f);
        points = testPoints.instance.GetCurrentPoint();
        TotalPoint.instance.IncreaseTotalPoints(points);
        gameOverPanel.SetActive(true);
        audioManager.PlaySFX(audioManager.gameOver);
        Time.timeScale = 0;
    }

    IEnumerator DelayedGameWin()
    {
        winning = true;
        yield return new WaitForSeconds(0.1f);
        points = testPoints.instance.GetCurrentPoint();
        TotalPoint.instance.IncreaseTotalPoints(points);
        gameWinPanel.SetActive(true);
        audioManager.PlaySFX(audioManager.gameOver);
        Time.timeScale = 0;
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        //Destroy item when player hit heal object 
        if (target.gameObject.CompareTag("Heal"))
        {
            Debug.Log("Healed");
            Destroy(target.gameObject);
            TakeHeal(50);
        }

        //Destroy item when player hit Ammo object 
        if (target.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("Get Ammo");
            Destroy(target.gameObject);
            audioManager.PlaySFX(audioManager.collectBullet);
            BulletsCount.instance.IncreaseBullet(5);
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Take Damge");
            TakeDamage(2);
        }
    }
}
