using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTorchTrigger : MonoBehaviour
{
    // Références aux murs
    public GameObject wallToDisable;
    public GameObject wallToEnable;
    public GameObject animationFire;
    public AudioClip successClip;
    public AudioSource audioSource;
    public GameObject[] triggerToDisable;
    public GameObject triggerToEnable;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet qui entre a le tag "Torch" et si l'événement n'a pas déjà été déclenché
        if (other.gameObject.tag == "Torch" && !hasTriggered)
        {
            audioSource.PlayOneShot(successClip);
            
            // Démarrer la coroutine pour l'animation du feu et les changements de mur
            StartCoroutine(HandleFireAnimationAndWalls());

            // Marquer l'événement comme déclenché
            hasTriggered = true;
        }
    }

    private IEnumerator HandleFireAnimationAndWalls()
    {
        // Activer l'animation du feu
        animationFire.SetActive(true);

        // Attendre 3 secondes
        yield return new WaitForSeconds(3f);

        // Désactiver l'animation du feu
        animationFire.SetActive(false);

        // Désactiver un mur et activer l'autre
        wallToDisable.SetActive(false);
        wallToEnable.SetActive(true);
        for (int i = 0; i < triggerToDisable.Length; i++)
        {
            triggerToDisable[i].SetActive(false);
        }
        triggerToEnable.SetActive(true);
    }
}
