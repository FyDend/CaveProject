using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceCollider : MonoBehaviour
{
    [SerializeField]
    Booleans booleans;
    [SerializeField]
    GameObject ghoul;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!booleans.pickBatteries)
                return;
            booleans.entranceWalkieTalkie = true;
            var nextTask = "Search something to explode the rocks";
            booleans.NextTask(nextTask);
            ghoul.SetActive(true);
            Destroy(gameObject);
        }
    }
}
