using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float smoothing = 0.5f;
    public float shakeDiration = 1.0f;
    public float magnitude = 1.0f;
    private bool shaking;

    private Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position;
        shaking = false;
    }
	/*
    void FixedUpdate() {
        Vector3 targetCamPos = player.transform.position + offset;

        float targetX = targetCamPos.x;
        float targetY = targetCamPos.y;
        float targetZ = targetCamPos.z;

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetX, smoothing), 
        Mathf.Lerp(transform.position.y, targetY, 0.5f), targetZ);
    }
    */
    private void LateUpdate() {
        if (!shaking) {
            transform.position = player.transform.position + offset;
        }        
    }

    public void Shake() {
        StartCoroutine(ShakeIE());
    }

    public IEnumerator ShakeIE() {
        shaking = true;

        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.position;

        while (elapsed < shakeDiration) {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / shakeDiration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }

        transform.position = originalCamPos;
    }
}
