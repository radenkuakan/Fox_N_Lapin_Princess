using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public BoxCollider2D mapBounds; // Kotak pembatas (CameraBounds)

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float camHeight;
    private float camWidth;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Menghitung setengah tinggi & lebar kamera
        // Agar kamera berhenti tepat di pinggir, bukan di tengahnya
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Posisi target
        Vector3 desiredPosition = target.position + offset;

        // 2. Logika Pembatas dengan Collider (Otomatis)
        if (mapBounds != null)
        {
            // Ambil batas minimal dan maksimal dari kotak collider
            // Ditambah/Dikurang ukuran kamera supaya pas tidak keluar garis
            float minX = mapBounds.bounds.min.x + camWidth;
            float maxX = mapBounds.bounds.max.x - camWidth;
            float minY = mapBounds.bounds.min.y + camHeight;
            float maxY = mapBounds.bounds.max.y - camHeight;

            // Kunci posisi kamera di dalam angka-angka tadi
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        // 3. Gerakkan Kamera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = transform.position.z; // Jaga Z tetap stabil

        transform.position = smoothedPosition;
    }
}