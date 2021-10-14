using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxCollider spawnBoundBox;
    public GameObject alienPrefab;
    public Transform shootPoint;
    public GameObject hitParticle;
    public Transform player;

    public GameObject laser;

    private int Score;
    private int Health;
    private bool isRunning;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        laser.SetActive(false);
        Score = 0;
        Health = 10;
        isRunning = true;
        StartCoroutine(spawnEnemy());
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
            alien.GetComponent<Alien>().SetPlayer(player);

            // Wait for some time before spawning again
            yield return new WaitForSeconds(2.0f);
        }
    }

   
    public void ShootLasers()
    {
        //Play the shoot sound

        //Show the laser and hide it quickly
        laser.SetActive(true);
        Invoke("HideLaser", 0.1f);


        if(Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            if (hit.collider.CompareTag("alien"))
            {
                Score++;

                //Update score UI

                //Destroy the alien
                Destroy(hit.collider.gameObject);

                //Create an explosion particle
                Instantiate(hitParticle, hit.transform.position, Quaternion.identity);

                //Play the sound boom!

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
        if (Health <= 0)
        {
            //Game Over
            isRunning = false;

            //Show the gameover UI;
        }
    }


    
}
