using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay elements")]
    public BoxCollider spawnBoundBox;
    public GameObject alienPrefab;
    public Transform shootPoint;
    public GameObject hitParticle;
    public Transform player;
    public GameObject laser;

    [Header("UI")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject GameOverUI;
    public GameObject GameplayUI;

    [Header("Audio")]
    public AudioSource gunAudio;
    public AudioSource explosionAudio;

    public AudioClip gun, explosion;

    private int Score;
    private int Health;
    private bool isRunning;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    public void StartGame()
    {
        GameplayUI.SetActive(true);

        laser.SetActive(false);
        Score = 0;
        Health = 10;
        isRunning = true;
        StartCoroutine(spawnEnemy());


        healthText.text = "HEALTH\n" + Health;
    }

    IEnumerator spawnEnemy()
    {
        while (isRunning)
        {
            // Get a random position using the bounds of the box collider
            var randomPosition = new Vector3(Random.Range(spawnBoundBox.bounds.min.x, spawnBoundBox.bounds.max.x),
                Random.Range(spawnBoundBox.bounds.min.y, spawnBoundBox.bounds.max.y),
                Random.Range(spawnBoundBox.bounds.min.z, spawnBoundBox.bounds.max.z));

            // Spawn a new enemy
            GameObject alien = Instantiate(alienPrefab, randomPosition, Quaternion.identity);
            alien.GetComponent<Alien>().SetPlayer(player, this);

            // Wait for some time before spawning again
            yield return new WaitForSeconds(2.0f);
        }
    }

   
    public void ShootLasers()
    {
        //Play the shoot sound
        gunAudio.PlayOneShot(gun);

        //Show the laser and hide it quickly
        laser.SetActive(true);
        Invoke("HideLaser", 0.1f);


        if(Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            if (hit.collider.CompareTag("alien"))
            {
                Score++;

                //Update score UI
                scoreText.text = "SCORE\n" + Score;

                //Destroy the alien
                Destroy(hit.collider.gameObject);

                //Create an explosion particle
                Instantiate(hitParticle, hit.transform.position, Quaternion.identity);

                //Play the sound boom!
                explosionAudio.PlayOneShot(explosion);
            }
        }
    }

    void HideLaser()
    {
        laser.SetActive(false);
    }

    public void GetDamage()
    {
        Health--;
        //Update health UI
        healthText.text = "HEALTH\n" + Health;

        if (Health <= 0)
        {
            //Game Over
            isRunning = false;
            StopAllCoroutines();

            //Show the gameover UI;
            GameplayUI.SetActive(false);
            GameOverUI.SetActive(true);
            finalScoreText.text = "SCORE\n" + Score;
        }
    }


    
}
