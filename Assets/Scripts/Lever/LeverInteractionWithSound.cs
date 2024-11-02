using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractionWithSound : MonoBehaviour
{
    public AudioClip successClip; // Son de reussite
    public AudioSource audioSource; // Source audio

    public GameObject closeDoorChest;
    public GameObject openDoorChest;
    public GameObject closeDoorKey;
    public GameObject openDoorKey;
    public GameObject[] triggerToDisable;
    public GameObject triggerToEnable;

    private float activationAngle = 45f;
    private bool isActivated = false;

    void Update()
    {
        // Calculer l'angle du levier
        float leverAngle = transform.localEulerAngles.x;

        // Vérifier si l'angle du levier a dépassé l'angle d'activation
        if (leverAngle >= activationAngle && !isActivated)
        {
            OpenDoorAndPlaySound();
            isActivated = true; // Marque le levier comme activé pour éviter les déclenchements répétés
        }
    }

    void OpenDoorAndPlaySound()
    {
        closeDoorChest.SetActive(false);
        closeDoorKey.SetActive(false);
        openDoorChest.SetActive(true);
        openDoorKey.SetActive(true);
        for (int i = 0; i < triggerToDisable.Length; i++)
        {
            triggerToDisable[i].SetActive(false);
        }
        triggerToEnable.SetActive(true);
        audioSource.PlayOneShot(successClip);
    }
}
