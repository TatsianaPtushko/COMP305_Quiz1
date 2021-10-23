using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
    
{[SerializeField] Transform spawnPoint;
      GameObject player;    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position;
        }

    }
}
