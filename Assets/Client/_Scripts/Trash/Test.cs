using UnityEngine;

public class Test : MonoBehaviour
{
    public RectTransform rectTransform;

    void Start()
    {
        DisplayWorldCorners();
    }

    void DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rectTransform.GetWorldCorners(v);

        Debug.Log("World Corners");
        for (var i = 0; i < 4; i++)
        {
            Debug.Log("World Corner " + i + " : " + v[i]);
        }
    }
}
