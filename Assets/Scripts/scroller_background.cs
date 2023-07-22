using UnityEngine;

public class scroller_background : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat;


    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        var tr = GetComponent<Renderer>();
        tr.sortingLayerName = "Scrolling";
    }


    void Update()
    {

        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
