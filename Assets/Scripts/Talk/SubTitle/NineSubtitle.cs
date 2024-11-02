using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NineSubtitle : MonoBehaviour
{
    public GameObject backgroundSubtitle;
    public GameObject subtitle1;
    public GameObject subtitle2;
    public GameObject subtitle3;
    public GameObject subtitle4;
    public GameObject subtitle5;
    public GameObject subtitle6;
    public GameObject subtitle7;
    public GameObject subtitle8;
    public GameObject subtitle9;

    public int time1;
    public int time2;
    public int time3;
    public int time4;
    public int time5;
    public int time6;
    public int time7;
    public int time8;
    public int time9;


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
        subtitle3.SetActive(true);
        yield return new WaitForSeconds(time3);

        subtitle3.SetActive(false);
        subtitle4.SetActive(true);
        yield return new WaitForSeconds(time4);

        subtitle4.SetActive(false);
        subtitle5.SetActive(true);
        yield return new WaitForSeconds(time5);

        subtitle5.SetActive(false);
        subtitle6.SetActive(true);
        yield return new WaitForSeconds(time6);

        subtitle6.SetActive(false);
        subtitle7.SetActive(true);
        yield return new WaitForSeconds(time7);

        subtitle7.SetActive(false);
        subtitle8.SetActive(true);
        yield return new WaitForSeconds(time8);

        subtitle8.SetActive(false);
        subtitle9.SetActive(true);
        yield return new WaitForSeconds(time9);

        subtitle9.SetActive(false);
        backgroundSubtitle.SetActive(false);

        isSubtitleActive = false; // Reset du flag à la fin
    }

    public void StopSubtitles()
    {
        StopAllCoroutines(); // Arrête toutes les coroutines en cours
        backgroundSubtitle.SetActive(false); // Cache le fond
        subtitle1.SetActive(false);
        subtitle2.SetActive(false);
        subtitle3.SetActive(false);
        subtitle4.SetActive(false);
        subtitle5.SetActive(false);
        subtitle6.SetActive(false);
        subtitle7.SetActive(false);
        subtitle8.SetActive(false);
        subtitle9.SetActive(false);
        isSubtitleActive = false; // Reset du flag
    }


}