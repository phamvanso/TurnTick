using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    private Tween rotateTween;
    public bool IsRotating => rotateTween != null && rotateTween.IsActive();

    public void StartRotation(float angle = 360f, float duration = 3f)
    {
        StopRotation();

        rotateTween = transform.DORotate(
                transform.eulerAngles + new Vector3(0, 0, angle),
                duration,
                RotateMode.FastBeyond360
            )
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }

    public void StopRotation()
    {
        if (rotateTween != null && rotateTween.IsActive())
        {
            rotateTween.Kill();
            rotateTween = null;
        }
    }
}