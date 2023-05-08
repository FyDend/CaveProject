using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriesScriptInteractable : Interactable
{
    [SerializeField]
    Booleans booleans;
    public GameObject colliderEntrance;
    public AudioSource batteriesAudioSource;
    public override string GetDescription()
    {
        if (!booleans.pickWalkieTalkie)
            return "";
        else return "Press [E] to pick the batteries";
    }
    public override void Interact()
    {
        if (!booleans.pickWalkieTalkie)
            return;
        batteriesAudioSource.Play();
        var nextTask = "Search signal in the entrance of the cave";
        booleans.NextTask(nextTask);
        booleans.pickBatteries=true;
        colliderEntrance.SetActive(true);
        Destroy(gameObject);
    }

}
