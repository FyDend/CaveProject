using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkieInteractableScript : Interactable
{
    public GameObject walkieTalkie;
    public AudioSource walkieTalkieAudioSource;
    [SerializeField]
    Booleans booleans;
    public override string GetDescription()
    {
        return "Press [E] to pick";
    }
    public override void Interact()
    {
        var nextTask = "Find the batteries";
        booleans.NextTask(nextTask);
        walkieTalkie.SetActive(true);
        booleans.pickWalkieTalkie = true;
        walkieTalkieAudioSource.Play();
        Destroy(gameObject);
    }
}
