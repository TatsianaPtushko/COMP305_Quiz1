using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject levelChanger;
    private void Start()
    {
        anim = levelChanger.GetComponent<Animator>();

     }

    

    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("Win");
           anim.SetTrigger("Fade");
        }
    }
    
}
