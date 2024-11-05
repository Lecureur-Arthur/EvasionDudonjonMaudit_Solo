using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSixSubtitle : MonoBehaviour
{
    public GameObject character;              // Référence à l'objet qui a l'Animator
    public AudioSource audioSource;       // Le composant AudioSource pour la voix
    public AudioClip audioClip;                // Le clip audio unique à jouer
    public SixSubtitle subtitleScript;  // Référence au script NineSubtitle
    public GameObject[] triggerToDisable;
    public string animationStart; 
    public string animationStop; 
    public GameObject targetObjectWithBoxCollider;


    private Animator animator;        // Pour stocker la référence à l'Animator
    private bool isPlaying = false;

    void Start()
    {
        // Récupère le composant Animator de l'objet spécifié
        animator = character.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui entre dans la zone
        if (other.CompareTag("Player") && !isPlaying)
        {
            // Joue le clip audio
            if (audioClip != null)
            {
                Debug.Log("Play animation and song");
                animator.Play(animationStart);
                audioSource.PlayOneShot(audioClip);
                isPlaying = true;

                // Déclenche l'affichage des sous-titres à partir de SixSubtitle
                if (subtitleScript != null)
                {
                    // Appelle la méthode coroutine de SixSubtitle
                    StartCoroutine(subtitleScript.ShowSubtitles());
                }

                // Appelle une fonction pour arrêter l'animation lorsque le son est terminé
                StartCoroutine(StopAnimationWhenAudioEnds(audioClip.length));
            }
            else
            {
                Debug.LogWarning("Le clip audio spécifié n'est pas assigné.");
            }
        }
    }

    IEnumerator StopAnimationWhenAudioEnds(float clipLength)
    {
        // Attend la durée du clip
        yield return new WaitForSeconds(clipLength);
        
        // Arrête l'animation
        animator.Play(animationStop); // Remplace "NoAnimation" par une animation neutre si besoin
        subtitleScript.StopSubtitles();
        isPlaying = false;
        for (int i = 0; i < triggerToDisable.Length; i++)
        {
            triggerToDisable[i].SetActive(false);
        }

        // Active le BoxCollider sur l'objet cible
        if (targetObjectWithBoxCollider != null)
        {
            BoxCollider boxCollider = targetObjectWithBoxCollider.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = true;
            }
        }
    }
}
