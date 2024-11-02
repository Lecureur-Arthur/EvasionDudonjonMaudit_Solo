using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleKinematicOnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Start()
    {
        // Récupérer le composant XRGrabInteractable et Rigidbody
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Activer la gravité par défaut
        rb.useGravity = false;

        // Assigner les événements de grab et release
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    // Quand l'objet est attrapé
    void OnGrab(SelectEnterEventArgs args)
    {
        rb.isKinematic = false; // Désactiver Kinematic pour permettre les mouvements manuels
        rb.useGravity = false;  // Désactiver la gravité pendant que l'objet est tenu
    }

    // Quand l'objet est relâché
    void OnRelease(SelectExitEventArgs args)
    {
        rb.isKinematic = false; // Assurer que Kinematic reste désactivé pour permettre la chute
        rb.useGravity = true;   // Activer la gravité pour que l'objet chute
    }

    void OnDestroy()
    {
        // Ne pas oublier de détacher les événements pour éviter des erreurs
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
