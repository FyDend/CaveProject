using UnityEngine;

public class RockDoorScriptInteractable : Interactable
{
    [SerializeField]
    Booleans booleans;

    public ExplosionCoroutine explosionCoroutine;
    public override string GetDescription()
    {
        if (booleans.canDestroyRock == false)
            return "You can not destroy this";
        else return "Press [E] to destroy rock";
    }
    public override void Interact()
    {
        if (booleans.canDestroyRock == true)
        {
            booleans.pickExplosives = false;
            booleans.explosives--;
            explosionCoroutine.CallExplosion();
        }
    }
}