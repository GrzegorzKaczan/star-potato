using UnityEngine;
using System;
using System.Timers;
using System.Collections;

public class MoveController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Action onComplete;
    
    [SerializeField]
    private Boolean isMoving = false;

    public void Update() {
        if (isMoving) {
            StartCoroutine(MoveFromTo(transform.position, targetPosition, 3f));

            if (transform.position == targetPosition) {
                isMoving = false;
                onComplete();
            }
        }
    }
    private IEnumerator MoveFromTo(Vector3 a, Vector3 b, float speed) {
         float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
         float t = 0;
         while (t <= 1.0f) {
             t += step; // Goes from 0 to 1, incrementing by step each time
             transform.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
             yield return null;         // Leave the routine and return here in the next frame
         }
         transform.position = b;
    }

    public void SetTarget(Vector3 newTargetPosition, Action done) {
        targetPosition = newTargetPosition;
        onComplete = done;
        isMoving = true;
    }
}
