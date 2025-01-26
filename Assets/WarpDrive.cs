using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpDrive : MonoBehaviour
{

    public Vector3 targetPosition;

    public void Engage()
    {
        StartCoroutine(WarpToPosition(targetPosition));
    }

    private IEnumerator WarpToPosition(Vector3 targetPosition)
    {
        float duration = 0.1f; // Total time for movement
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition; // Snap to the exact target
    }
}
