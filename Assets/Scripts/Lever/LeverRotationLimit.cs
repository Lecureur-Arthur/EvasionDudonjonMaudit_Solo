using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotationLimit : MonoBehaviour
{
    private float minAngle = -45f; // Angle minimal
    private float maxAngle = 45f;  // Angle maximal

    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        // Ajuste l'angle pour qu'il reste dans la plage -180 à 180 degrés
        if (currentRotation.x > 180) currentRotation.x -= 360;

        // Limite l'angle entre minAngle et maxAngle
        currentRotation.x = Mathf.Clamp(currentRotation.x, minAngle, maxAngle);

        // Applique la rotation limitée
        transform.localEulerAngles = currentRotation;
    }
}
