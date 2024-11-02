using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSubtitle : MonoBehaviour
{
    public GameObject backgroundSubtitle;
    public GameObject subtitle1;
    public GameObject subtitle2;
    public int time1;
    public int time2;

    private bool isSubtitleActive = false;

    public IEnumerator ShowSubtitles()
    {
        if (isSubtitleActive) yield break; // Empêche la boucle involontaire
        isSubtitleActive = true;

        // Active les sous-titres un par un avec un délai de 5 secondes
        backgroundSubtitle.SetActive(true);
        subtitle1.SetActive(true);
        yield return new WaitForSeconds(time1);

        subtitle1.SetActive(false);
        subtitle2.SetActive(true);
        yield return new WaitForSeconds(time2);

        subtitle2.SetActive(false);
        backgroundSubtitle.SetActive(false);

        isSubtitleActive = false; // Reset du flag à la fin
    }

    public void StopSubtitles()
    {
        StopAllCoroutines(); // Arrête toutes les coroutines en cours
        backgroundSubtitle.SetActive(false); // Cache le fond
        subtitle1.SetActive(false);
        subtitle2.SetActive(false);
        isSubtitleActive = false; // Reset du flag
    }

}
