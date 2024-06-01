using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject MapBackground;
    public float Speed = 20.0f;

    private float min = 0.0f;
    private float max = 0.0f;

    void Start()
    {
        if (MapBackground == null)
        {
            throw new Exception("GameObject 'MapBackground' not set.");
        }

        if (!TryGetComponent<Camera>(out var cam))
        {
            throw new Exception("Camera component not found.");
        }

        if (!MapBackground.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            throw new Exception("'SpriteRenderer' not found.");
        }

        var halfFrustumWidth = cam.orthographicSize * cam.aspect;
        var backgroundHalfSizeX = spriteRenderer.bounds.size.x / 2.0f;
        var backgroundPositionX = MapBackground.transform.position.x;

        min = backgroundPositionX - backgroundHalfSizeX + halfFrustumWidth;
        max = backgroundPositionX + backgroundHalfSizeX - halfFrustumWidth;
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var delta = Speed * Time.deltaTime * x;

        var position = transform.position + new Vector3(delta, 0.0f, 0.0f);

        position.x = Mathf.Clamp(position.x, min, max);
        transform.position = position;
    }
}
