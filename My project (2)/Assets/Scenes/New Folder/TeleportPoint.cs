using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public Transform targetTp;
    public FadeController fadeController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(fadeController.FadeToWhiteAndTeleport(other.transform, targetTp));
        }
    }
}