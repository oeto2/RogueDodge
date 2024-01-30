using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    MeshRenderer ImageMeshRenderer;

    [SerializeField] [Range(0.01f, 0.1f)] float moveSpeed = 0.01f;
    private float offSet;

    private void Awake()
    {
        ImageMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        offSet += Time.deltaTime * moveSpeed;
        ImageMeshRenderer.material.mainTextureOffset = new Vector2(offSet, 0);
    }
}
