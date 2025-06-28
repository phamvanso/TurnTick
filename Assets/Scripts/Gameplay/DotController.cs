using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;

namespace ChienNT
{
    public class DotController : MonoBehaviour
    {
        [SerializeField] private Transform hand;
        [SerializeField] private float rotateSpeed = 90f;

        [HideInInspector]
        public Tween rotateTween;


        public void StartRotating()
        {
            if (rotateTween != null && rotateTween.IsActive())
            {
                rotateTween.Kill();
                rotateTween = null;
            }
            float currentZ = transform.eulerAngles.z;
            rotateTween = transform
                .DORotate(new Vector3(0, 0, currentZ + 360f), 360f / rotateSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }

        public void StopRotationOnCollision(GameObject collidedDot)
        {
            if (rotateTween != null && rotateTween.IsActive())
            {
                rotateTween.Kill();
                rotateTween = null;
                Debug.Log($"Hand va chạm với {collidedDot.name}");
            }

            hand.SetParent(collidedDot.transform);
            hand.gameObject.GetComponent<HandCollisionDetector>().parentDotController = collidedDot.GetComponent<DotController>();
        }

        void OnMouseDown()
        {
            hand.SetParent(gameObject.transform);
            hand.gameObject.GetComponent<HandCollisionDetector>().parentDotController = gameObject.GetComponent<DotController>();
            Debug.Log("CLICKED DOT: " + gameObject.name);
            StartRotating();
        }
    }
} 