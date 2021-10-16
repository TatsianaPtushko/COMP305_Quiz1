using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;

    public MyVirtualCameraController vCamController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            vCamController.TransitionTo(cameraToActivate);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        vCamController.TransitionTo(cameraOut);

    }


    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    vCamController.TransitionTo(cameraOut);
    //}
}
