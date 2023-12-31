using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject Boss;
    public SpawnManager spawnManager;
    public GameManager gameManager;
    public ParticleSystem Explosion;
    GameObject[] obstacles;

    public float horizontalInput;
    private float verticalInput;
    private float speed = 15.0f;
    private int Coins = 0;
    private int maxCoins = 8;
    private int Once = 0;
    private int Health = 100;
    private int Dead = 0;
    private bool Movement = false;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI bossAliveText;
    public TextMeshProUGUI coinsNeedText;
    public Image healthBar;
    public GameObject healthBarBackground;

    public AudioClip coinSound;
    public AudioClip explosionSound;



    // Start is called before the first frame update
    public void StartGame()
    {
        healthText.gameObject.SetActive(true);
        healthText.text = "Health: " + Health;
        Movement = true;

        healthBar.gameObject.SetActive(true);
        healthBarBackground.gameObject.SetActive(true);
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement)
        {
            // Get Inputs to be able to manually control the vehicle
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // Allows you to move the vehicle forward with speed
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Health = Health - 10;

            UpdateHealth();
            Death();

        }
        else if (other.CompareTag("Boss"))
        {
            Health = Health - 50;

            UpdateHealth();
            Death();
        }

        if (other.CompareTag("Trigger"))
        {
            foreach (GameObject obstacle in obstacles)
            {
                Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
                if (obstacleScript != null && Once == 0)
                {
                    obstacleScript.playanim();
                }
            }
            Once = Once + 1;
            spawnManager.ClearedWavesTextVisibility();
        }

        if (other.CompareTag("Speed Boost"))
        {
            speed = 25.0f;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }

        if (other.CompareTag("Portal"))
        {
            if(Coins >= maxCoins && Boss == null)
            {
                gameManager.Victory();
            }
            else if(Boss != null)
            {
                bossAliveText.gameObject.SetActive(true);
            }
            else
            {
                coinsNeedText.gameObject.SetActive(true);
            }
        }

        if (other.CompareTag("Trigger Portal"))
        {
            bossAliveText.gameObject.SetActive(false);
            coinsNeedText.gameObject.SetActive(false);
        }
    }

    public void CollideObstacle()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound, 1.0f);
        Explosion.Play();
        Health = Health - 50;

        UpdateHealth();
        Death();
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        speed = 15.0f;
        spawnManager.SpawnBooster();
    }

    private void Death()
    {
        if(Health == Dead)
        {
            gameManager.GameOver();
        }
    }

    private void UpdateHealth()
    {
        float normalizedHealth = (float)Health / 100f;  // Normalize health to a value between 0 and 1
        healthBar.fillAmount = normalizedHealth;  // Set the fill amount of the Image based on health

        if (Health < 0)
        {
            Health = 0;
            normalizedHealth = 0f;
        }

        healthText.text = "Health: " + Health;
    }

    public void ActivateCoin()
    {
        GetComponent<AudioSource>().PlayOneShot(coinSound, 1.0f);
        gameManager.UpdateCoins();
        Coins = Coins + 1;
    }

}

