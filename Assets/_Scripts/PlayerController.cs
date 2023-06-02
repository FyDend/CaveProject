
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask interactable;
    [SerializeField] private Camera cam;


    public float interactDistance;
    public TMPro.TextMeshProUGUI interactionText;
    public GameObject footSteps, footStepsSprint, playerObj;
    public AudioSource jumpScareSFX;
    public bool isDead = false;
    public Booleans booleans;

    FirstPersonController fpsController;

    private void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        bool successfulHit = false;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, interactDistance, interactable))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }
        if (!successfulHit)
        {
            interactionText.text = "";
        }
        void HandleInteraction(Interactable interactable)
        {
            if (Input.GetButtonDown("InteractButton"))
            {
                interactable.Interact();
            }
        }
        if (fpsController.isWalking && !fpsController.isSprinting)
            FootSteps();

        else StopFootSteps();
        if (fpsController.isSprinting)
            FootStepsSprint();

        else StopFootStepsSprint();
    }

    public void StopFootSteps()
    {
        footSteps.SetActive(false);
    }

    private void FootSteps()
    {
        footSteps.SetActive(true);
    }
    public void StopFootStepsSprint()
    {
        footStepsSprint.SetActive(false);
    }

    private void FootStepsSprint()
    {
        footStepsSprint.SetActive(true);
    }
    public void Death()
    {
        isDead = true;
        fpsController.enabled = false;
        cam.enabled = false;
        jumpScareSFX.Play();
        StopFootStepsSprint();
        StopFootSteps();
        booleans.ResetGame();
        playerObj.SetActive(false);
    }
}
