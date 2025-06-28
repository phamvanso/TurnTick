using UnityEngine;
using DG.Tweening;

namespace ChienNT
{
    public class DotController : MonoBehaviour
    {
        [SerializeField] private Transform hand;
        [SerializeField] float rotateDuration = 1f;
        [SerializeField] float targetAngle;

        [HideInInspector]
        public Tween rotateTween;

        public void RotateToAngle(float angle)
        {
            if (rotateTween != null && rotateTween.IsActive()) rotateTween.Kill();

            rotateTween = transform
                .DORotate(new Vector3(0, 0, angle), rotateDuration)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    Debug.Log("Done");
                    rotateTween = null;
                });
        }

        public void StopRotationOnCollision(GameObject collidedDot)
        {
            if (rotateTween != null && rotateTween.IsActive())
            {
                rotateTween.Kill();
                rotateTween = null;
                Debug.Log($"Hand va chạm với {collidedDot.name}, đã dừng Tween.");
            }

            hand.SetParent(collidedDot.transform);
            hand.gameObject.GetComponent<HandCollisionDetector>().parentDotController = collidedDot.GetComponent<DotController>();
            collidedDot.GetComponent<CircleCollider2D>().radius = 0.5f;
        }

        void OnMouseDown()
        {
            RotateToAngle(targetAngle);
        }
    }
}
