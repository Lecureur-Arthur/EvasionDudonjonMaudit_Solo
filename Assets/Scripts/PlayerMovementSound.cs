using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementSound : MonoBehaviour
{

    private Vector3 previousPosition;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        // On stocke la position initiale du joueur
        previousPosition = transform.position;

        // On récupère le composant AudioSource
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null) {
            Debug.LogError("AudioSource component is missing");
        }
    }

    // Update is called once per frame
    void Update() {
        // Verifie si la position du joueur a change (le joueur a bouge)
        if (Vector3.Distance(transform.position, previousPosition) > 0.01f) {
            // Si le joueur bouge et que le son n'est pas en train de jouer, on le joue
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            // Si le joueur ne bouge pas, on arrete le son
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        }

        // Met a jour la position precedente
        previousPosition = transform.position;
    }
}
