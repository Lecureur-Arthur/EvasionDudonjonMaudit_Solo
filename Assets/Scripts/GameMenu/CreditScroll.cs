using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Jobs;

public class CreditScroll : MonoBehaviour
{

    public float scrollSpeed = 50f; // Vitesse de defilement
    public float startDelay = 5f; // Delai avant le debut du defilement
    public float stopPositionY = 20f; // Position Y ou arreter le defilement
    public float timeScrolling = 4f; // Temps de defilement des credits
    public GameObject CreditText; // Le GameObject a desactiver (par exemple, le panneau des credits)
    public GameObject CreditSection; // Le GameObject a desactiver apres 5 secondes
    public GameObject MainSection; // Le GameObject a activer apres 5 secondes
    public Vector2 startPosition; // Position initiale du texte


    private RectTransform rectTransform;
    private bool isScrolling = false; // Indique si le defilement est active
    private bool hasSwitchedObjects = false; // Pour s'assurer que l'activation/desactivation n'arrive qu'une fois

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
