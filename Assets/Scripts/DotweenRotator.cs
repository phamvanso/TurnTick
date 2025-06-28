using UnityEngine;
using DG.Tweening;

public class DotweenRotator : MonoBehaviour
{
    private Tween rotationTween; // Biến lưu trữ tween
    private static DotweenRotator instance; // Instance Singleton
    private bool isRotating = false; // Trạng thái quay

    public static DotweenRotator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<DotweenRotator>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("DotweenRotator");
                    instance = obj.AddComponent<DotweenRotator>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartRotation()
    {
        if (rotationTween == null || !rotationTween.IsPlaying())
        {
            rotationTween = transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            isRotating = true;
        }
    }

    public void StopRotation()
    {
        if (rotationTween != null && rotationTween.IsPlaying())
        {
            rotationTween.Kill();
            isRotating = false;
        }
    }
}