using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Move : MonoBehaviour
{
    private MeshRenderer MeshRenderer;
    public float Speed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(Speed * Time.deltaTime, 0);
    }
}
