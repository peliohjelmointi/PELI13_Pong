using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [Range(0.1f, 2.0f)]
    [SerializeField] float scrollSpeed;

    Renderer rend;
    float offset;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset = Time.time * scrollSpeed; //kulunut aika* nopeus
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
    }
}
