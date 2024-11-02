using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSubtitle : MonoBehaviour
{
  
    public GameObject backgroundSubtitle;
    public GameObject subtitle1;
    public int time;
    private bool isSubtitleActive = false;

    public IEnumerator ShowSubtitles()
    {
        if (isSubtitleActive) yield break; // Empêche la boucle involontaire
        isSubtitleActive = true;

        // Active les sous-titres un par un avec un délai de 5 secondes
        backgroundSubtitle.SetActive(true);
        subtitle1.SetActive(true);
        yield return new WaitForSeconds(time);

        subtitle1.SetActive(false);
        backgroundSubtitle.SetActive(false);

        isSubtitleActive = false; // Reset du flag à la fin
    }

    public void StopSubtitles()
    {
        StopAllCoroutines(); // Arrête toutes les coroutines en cours
        backgroundSubtitle.SetActive(false); // Cache le fond
        subtitle1.SetActive(false);
        isSubtitleActive = false; // Reset du flag
    }

}
