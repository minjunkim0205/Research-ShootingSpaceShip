using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial;
    public float scrollSpeed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        bgMaterial.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
