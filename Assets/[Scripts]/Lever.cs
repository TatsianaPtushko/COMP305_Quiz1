using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Tooltip("Image of inactive lever")]
    [SerializeField] Sprite inactive;
    [Tooltip("Image of active lever")]
    [SerializeField] Sprite active;
    [Tooltip("The GameObject to be destroyed once lever is activated")]
    [SerializeField] GameObject destructableObj;
    [SerializeField]  private GameObject leverSound;
    [SerializeField] private GameObject shieldSound;

    SpriteRenderer activeImg;

    // Start is called before the first frame update
    void Start()
    {
        activeImg = GetComponent<SpriteRenderer>();
        activeImg.sprite = inactive;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {

            
            //Set to active state
            activeImg.sprite = active;
           
            //remove shield
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            Instantiate(leverSound,transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(shieldSound, transform.position, Quaternion.identity);
            destructableObj.GetComponent<Animator>().SetTrigger("Move");
            yield return new WaitForSeconds(3);
            Destroy(destructableObj);
        }
    }
}