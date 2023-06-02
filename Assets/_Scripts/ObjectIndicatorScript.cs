using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIndicatorScript : MonoBehaviour
{
    public List<Transform> missionProps;
    public GameObject player;
    public float offset;
    public float amplitude = 1f; // Amplitud del movimiento oscilante
    public float frequency = 1f; // Frecuencia del movimiento oscilante

    Vector3 yOffset;

    private int currentIndexPosition=0;

    void Start()
    {

    }

    void Update()
    {
        offset = 0.4f + Mathf.Sin(Time.time * frequency) * amplitude;
        yOffset = new Vector3(0, 0 + offset);
        
        transform.position = missionProps[currentIndexPosition].transform.position + yOffset;
        transform.LookAt(player.transform);   
    }

    public void NextPosition()
    {
        currentIndexPosition++;
    }
}
