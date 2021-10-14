using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private enum LadderPart { complete, bottom, top};
    [SerializeField] LadderPart part = LadderPart.complete;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (part == LadderPart.complete)
            {
                player.isClimb = true;
                player.ladder = this;
            }
            else if (part == LadderPart.bottom)
            {
                player.bottomLadder = true;
            }
            else if (part == LadderPart.top)
            {
                player.topLadder = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (part == LadderPart.complete)
            {
                player.isClimb = false;
            }
            else if (part == LadderPart.bottom)
            {
                player.bottomLadder = false;
            }
            else if (part == LadderPart.top)
            {
                player.topLadder = false;
            }
        }
    }
}
