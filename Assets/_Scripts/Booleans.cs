using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Booleans : MonoBehaviour
{
    public bool pickWalkieTalkie = false;
    public bool pickBatteries = false;
    public bool entranceWalkieTalkie = false;
    public bool pickExplosives = false;
    public bool canDestroyRock = false;

    public int explosives;

    public TMPro.TextMeshProUGUI _taskText;
    public ObjectIndicatorScript objectIndicator;
    public AudioSource taskSFX;

    string firstTask="Pick the walkie talkie";

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
    public void ResetGame()
    {
        StartCoroutine(ReloadScene());
    }
    public void NextTask(string nextTask)
    {
        objectIndicator.NextPosition();
        StopAllCoroutines();
        StartCoroutine(Task(nextTask));
    }
    IEnumerator Task(string taskText)
    { 
        yield return new WaitForSeconds(1.5f);
        taskSFX.Play();
        _taskText.text = taskText;
        yield return new WaitForSeconds(3);
        _taskText.text = "";
    }
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Cuevas");
    }
}
