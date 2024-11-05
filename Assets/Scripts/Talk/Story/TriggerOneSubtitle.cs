using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOneSubtitle : MonoBehaviour
{
    public GameObject character;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject[] triggerToDisable;
    public GameObject triggerToEnableTalk;
    public GameObject triggerToEnableFireDoor;
    public OneSubtitle subtitleScript;
    public string animationStart; 
    public string animationStop; 

    private Animator animator;
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

                // Déclenche l'affichage des sous-titres à partir de NineSubtitle
                if (subtitleScript != null)
                {
                    // Appelle la méthode coroutine de OneSubtitle
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
        animator.Play(animationStop);
        // Force l'arret des sous-titre
        subtitleScript.StopSubtitles();
        isPlaying = false;
        for (int i = 0; i < triggerToDisable.Length; i++)
        {
            triggerToDisable[i].SetActive(false);
        }
        triggerToEnableTalk.SetActive(true);
        triggerToEnableFireDoor.SetActive(true);
    }
}
