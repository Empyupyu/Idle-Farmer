using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _rectTransform;
    
    void Awake()
    {
        Scalling();
    }

    private void Scalling()
    {
        _rectTransform = GetComponent<RectTransform>();

        Rect safeArea = Screen.safeArea;

        Vector2 minimumAnchor = safeArea.position;

        Vector2 maximumAnchor = minimumAnchor + safeArea.size;

        minimumAnchor.x /= Screen.width;

        minimumAnchor.y /= Screen.height;

        maximumAnchor.x /= Screen.width;

        maximumAnchor.y /= Screen.height;

        _rectTransform.anchorMin = minimumAnchor;

        _rectTransform.anchorMax = maximumAnchor;
    }
}
