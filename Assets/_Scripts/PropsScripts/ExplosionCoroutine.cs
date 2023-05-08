using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCoroutine : MonoBehaviour
{
    public GameObject explosive, explosiveParticles, rockDoor;
    public AudioSource audioSource;
    public void CallExplosion()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        explosive.SetActive(true);
        audioSource.Play();
        yield return new WaitForSeconds(5);
        explosiveParticles.SetActive(true);
        Destroy(explosive);
        Destroy(rockDoor);
        yield return new WaitForSeconds(1.5f);
        explosiveParticles.SetActive(false);
    }
}
