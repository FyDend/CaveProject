using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booleans : MonoBehaviour
{
    public bool pickWalkieTalkie = false;
    public bool pickBatteries = false;
    public bool entranceWalkieTalkie = false;
    public bool pickExplosives = false;
    public bool canDestroyRock = false;

    public int explosives;

    public TMPro.TextMeshProUGUI _taskText;

    string firstTask="Find the walkie talkie";

    private void Start()
    {
        _taskText.text = "";
        StartCoroutine(Task(firstTask));
    }
    private void Update()
    {
        if (pickExplosives)
            canDestroyRock = true;
        else canDestroyRock= false;
    }
    public void NextTask(string nextTask)
    {
        StopAllCoroutines();
        StartCoroutine(Task(nextTask));
    }
    IEnumerator Task(string taskText)
    {
        yield return new WaitForSeconds(1.5f);
        _taskText.text = taskText;
        yield return new WaitForSeconds(3);
        _taskText.text = "";
    }
}
