using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Rotator pivot;

    // Danh sách các Dot đang chạm vào kim (đầu, đuôi)
    private readonly List<Transform> dotsColliding = new List<Transform>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("chạm");
        if (other.CompareTag("Dot") && !dotsColliding.Contains(other.transform))
            dotsColliding.Add(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("thoát");
        if (other.CompareTag("Dot"))
            dotsColliding.Remove(other.transform);
    }

    // Chỉ cho phép click khi kim đang chạm đúng 2 Dot
    public bool CanClickAnyDot()
    {
        return dotsColliding.Count == 2;
    }

    // Kiểm tra kim có đang đè lên Dot này không
    public bool IsOnDot(Transform dot)
    {
        return dotsColliding.Contains(dot);
    }

    // Hàm xử lý khi bấm Dot (gọi từ Dot.cs)
    public void OnDotClicked(Transform dot)
    {
        if (!CanClickAnyDot() || !IsOnDot(dot)) return;

        // 1. Dừng quay nếu đang quay
        pivot.StopRotation();

        // 2. Tách pivot ra khỏi cha cũ (nếu có)
        pivot.transform.SetParent(null);

        // 3. Đặt pivot đúng vị trí dot vừa bấm
        pivot.transform.position = dot.position;

        // 4. Gắn kim vào pivot
        transform.SetParent(pivot.transform, true);

        // 5. Quay quanh dot vừa bấm
        pivot.StartRotation();
    }

    // Hàm này nên được gọi khi kim chạm dot thứ 2 mới để dừng tween (có thể trong chính OnTriggerEnter2D)
    public void TryStopOnNewDot()
    {
        // Nếu đang quay và bây giờ dotsColliding lại có 2 dot, 
        // và 1 trong 2 dot KHÁC dot pivot hiện tại (đang quay quanh dot nào)
        // thì dừng quay
        if (pivot.IsRotating && dotsColliding.Count == 2)
        {
            // (nếu muốn chỉ dừng khi chạm dot mới, kiểm tra dot mới không trùng pivot)
            pivot.StopRotation();
        }
    }
}