using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivesScriptInteractable : Interactable
{
    [SerializeField]
    Booleans booleans;
    public AudioSource audioSource;

    public override string GetDescription()
    {
        if (!booleans.entranceWalkieTalkie || booleans.pickExplosives)
            return "";
        else return "Press [E] to pick explosives";
    }
    public override void Interact()
    {
        if (!booleans.entranceWalkieTalkie || booleans.pickExplosives)
            return;
        else if(booleans.entranceWalkieTalkie && booleans.explosives == 0)
        {
            var nextTask = "Find the way to get out";
            booleans.NextTask(nextTask);
            booleans.pickExplosives = true;
            booleans.explosives++;
            audioSource.Play();
            Destroy(gameObject);
        }
        else if (booleans.explosives == 1)
        {
            booleans.pickExplosives = true;
            booleans.explosives++;
            Destroy(gameObject);
        }
    }
}
