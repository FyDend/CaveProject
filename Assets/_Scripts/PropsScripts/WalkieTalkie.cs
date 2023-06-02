using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    private Transform enemy;
    public AudioSource radioSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        CalculateDistance();
    }

    void CalculateDistance()
    {    
        if (enemy == null) return;
        else
        {
            if (Vector3.Distance(this.transform.position, enemy.position) < 15)
            {
                radioSound.enabled = true;
                radioSound.volume = 1;
            }
            else if (Vector3.Distance(this.transform.position, enemy.position) >= 15
                && Vector3.Distance(this.transform.position, enemy.position) <= 30)
            {
                radioSound.enabled = true;
                radioSound.volume = 0.5f;
            }
            else radioSound.enabled = false;
        }
        
    }
}
