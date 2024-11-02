using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class HandcuffUnlockWithKey : MonoBehaviour
{

    public GameObject handcuffLock;
    public GameObject handcuffUnlock;
    public string targerTag;
    public AudioClip successClip;
    public AudioSource audioSource;
    public GameObject[] triggerToDisable;
    public GameObject triggerToEnable;

    private bool hasTriggered;
    private bool hasMoved;
    private GameObject keyObject;
    private Vector3 lastKeyPosition;
    private float movementThreshold = 0.5f;

    private void Start()
    {
        // Trouve l'objet avec le tag specifie
        keyObject = GameObject.FindGameObjectWithTag("KeyFirstHandcuff");
        if (keyObject != null)
        {
            lastKeyPosition = keyObject.transform.position;
        }
    }

    private void Update()
    {
        if (keyObject != null && !hasMoved)
        {
            // Calcul de la distance sur les axes X et Y entre la position actuelle et la précédente
            float deltaX = Mathf.Abs(keyObject.transform.position.x - lastKeyPosition.x);
            float deltaY = Mathf.Abs(keyObject.transform.position.y - lastKeyPosition.y);

            // Vérifie si le déplacement sur X ou Y dépasse le seuil
            if (deltaX > movementThreshold || deltaY > movementThreshold)
            {
                // Si le mouvement est significatif, désactive le GameObject spécifié
                for (int i = 0; i < triggerToDisable.Length; i++)
                {
                    triggerToDisable[i].SetActive(false);
                }
                Debug.Log("Le GameObject a été désactivé car la clé a bougé de manière significative sur X ou Y.");

                // Met à jour la position de référence
                lastKeyPosition = keyObject.transform.position;

                hasMoved = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée");

        // Utilisation de la variable 'targerTag' pour le tag de collision
        if (other.gameObject.tag == targerTag)
        {
            if (!hasTriggered)
            {
                for (int i = 0; i < triggerToDisable.Length; i++)
                {
                    triggerToDisable[i].SetActive(false);
                }
                triggerToEnable.SetActive(true);
                audioSource.PlayOneShot(successClip);
                handcuffLock.SetActive(false);
                handcuffUnlock.SetActive(true);
            }
        }
    }
}
