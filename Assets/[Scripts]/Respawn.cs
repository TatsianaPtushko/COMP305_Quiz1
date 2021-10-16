using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
    
{
      
    [SerializeField]  private GameObject sound;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            StartCoroutine(Delay());

        }

        IEnumerator Delay()
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
            Instantiate(sound, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Level1");
            
        }
        
    }
}
