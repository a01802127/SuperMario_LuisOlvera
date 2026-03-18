using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float suavizado = 0.125f;
    [SerializeField] private Vector3 desfase = new Vector3(0, 0, -10);
    [SerializeField] private float limiteIzquierdo = 0f;
    [SerializeField] private float limiteDerecho = 18f;

    void LateUpdate()
    {
        if (objetivo != null && objetivo.gameObject.activeSelf)
        {
            float xLimitada = Mathf.Clamp(objetivo.position.x, limiteIzquierdo, limiteDerecho);
            Vector3 posicionDeseada = new Vector3(xLimitada, transform.position.y, desfase.z);
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
        }
    }
}