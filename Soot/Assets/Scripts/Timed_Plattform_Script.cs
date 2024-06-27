using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed_Plattform_Script : MonoBehaviour
{
    [Tooltip("Zeit in Sekunden, die die Plattform sichtbar bleibt, bevor sie verschwindet.")]
    public float visibleDuration = 1f;

    [Tooltip("Zeit in Sekunden, die die Plattform benötigt, um wieder zu erscheinen.")]
    public float respawnDuration = 4f;

    [Tooltip("Zeit in Sekunden, bevor die Plattform verschwindet, in der die Farbe wechselt.")]
    public float colorChangeDuration = 0.5f;

    private Renderer platformRenderer;
    private Collider platformCollider;
    private Color originalColor = Color.gray;
    private Color disappearColor = Color.red;
    private Coroutine platformCoroutine;
    private bool playerOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();
        platformRenderer.material.color = originalColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            if (platformCoroutine == null)
            {
                platformCoroutine = StartCoroutine(PlatformCycle());
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            if (platformCoroutine != null)
            {
                StopCoroutine(platformCoroutine);
                platformCoroutine = null;
                ResetPlatform();
            }
        }
    }

    private IEnumerator PlatformCycle()
    {
        float elapsedTime = 0f;

        while (elapsedTime < visibleDuration - colorChangeDuration)
        {
            if (!playerOnPlatform)
                yield break;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < colorChangeDuration)
        {
            if (!playerOnPlatform)
                yield break;

            float t = elapsedTime / colorChangeDuration;
            platformRenderer.material.color = Color.Lerp(originalColor, disappearColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (playerOnPlatform)
        {
            HidePlatform();
            yield return new WaitForSeconds(respawnDuration);
            ShowPlatform();
        }

        platformCoroutine = null;
    }

    private void HidePlatform()
    {
        platformRenderer.enabled = false;
        platformCollider.enabled = false;
    }

    private void ShowPlatform()
    {
        platformRenderer.enabled = true;
        platformCollider.enabled = true;
        platformRenderer.material.color = originalColor;
    }

    private void ResetPlatform()
    {
        platformRenderer.material.color = originalColor;
    }
}
