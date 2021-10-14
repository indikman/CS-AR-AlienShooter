using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Renderer alienMesh;
    public Material[] colours;
    public float speed = 100;

    private Transform player;

    private void Start()
    {
        //Changing the colour of the Alien randomly
        alienMesh.material = colours[Random.Range(0, colours.Length)];
    }

    public void SetPlayer(Transform _player)
    {
        //Setting the target for the alien
        player = _player;
    }

    
    void Update()
    {
        // Check if the player is available, if, moves the alien towards the player
        if(player != null)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
