using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : Interactable
{
    public AudioSource barricadeSound;
    public override string GetDescription()
    {
        return "Press [E] to destroy";
    }
    public override void Interact()
    {
        barricadeSound.Play();
        Destroy(gameObject);
    }
}
