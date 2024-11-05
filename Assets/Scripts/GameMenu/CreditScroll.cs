using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Jobs;

public class CreditScroll : MonoBehaviour
{

    public float scrollSpeed = 50f;
    public float startDelay = 5f;
    public float stopPositionY = 20f;
    public float timeScrolling = 4f;
    public GameObject CreditText;
    public GameObject CreditSection;
    public GameObject MainSection;
    public Vector2 startPosition;

    private RectTransform rectTransform;
    private bool isScrolling = false;
    private bool hasSwitchedObjects = false;

    // Start is called before the first frame update
    void Start()
    {
        // Recupere le RectTransform de l'objet texte
        rectTransform = GetComponent<RectTransform>();
        // Enregistre la position de départ des credits
        startPosition = rectTransform.anchoredPosition;
        // Lance la coroutine pour attendre avant de commencer le defilement
        StartCoroutine(StartScrollingAfterDelay());
    }

    // Coroutine pour attendre avant de commencer le défilement
    IEnumerator StartScrollingAfterDelay()
    {
        yield return new WaitForSeconds(startDelay); // Attends le délai spécifié
        isScrolling = true; // Active le défilement
        StartCoroutine(SwitchObjectsAfterDelay()); // Commence la routine pour changer les objets apres 5 secondes
    }

    // Coroutine pour désactiver un GameObject et en activer un autre après 5 secondes de défilement
    IEnumerator SwitchObjectsAfterDelay()
    {
        yield return new WaitForSeconds(timeScrolling); // Attends 5 secondes après le début du défilement
        if (!hasSwitchedObjects)
        {
            rectTransform.anchoredPosition = startPosition;
            CreditSection.SetActive(false); // Désactive l'objet
            MainSection.SetActive(true);    // Active l'autre objet
            hasSwitchedObjects = true;           // Empêche de répéter cette action
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si le défilement est activé, fait défiler le texte
        if (isScrolling)
        {
            // Fait défiler le texte vers le haut
            rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            // Vérifie si le texte a dépassé la position stopPositionY
            if (rectTransform.anchoredPosition.y >= stopPositionY)
            {
                StopScrolling(); // Arrête le défilement et désactive le panneau des crédits
            }
        }
    }

    // Methode pour arreter le defilement et desactiver le GameObject
    void StopScrolling()
    {
        isScrolling = false; // Arrete le defilement
    }
}
