using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Transform heart;

    public float moveDistance = 1f;
    public float moveDuration = 0.5f;
    public float pauseDuration = 0.5f;

    private Vector3 heartStartPosition;
    private bool animationRunning;

    private void Start()
    {
        heartStartPosition = heart.transform.localPosition;
    }

    private void OnMouseDown()
    {
        if (animationRunning) return;
        StartCoroutine(MoveHeart());
    }


    private IEnumerator MoveHeart()
    {
        animationRunning = true;
        heart.gameObject.SetActive(true);
        // Move upwards
        Vector3 targetPosition = heartStartPosition + Vector3.down * moveDistance;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            heart.transform.localPosition = Vector3.Lerp(heartStartPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        heart.transform.localPosition = targetPosition;

        // Pause
        yield return new WaitForSeconds(pauseDuration);

        // Deactivate or destroy the heart
        heart.gameObject.SetActive(false); 
        animationRunning = false;
    }
}
