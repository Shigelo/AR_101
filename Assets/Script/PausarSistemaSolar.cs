using UnityEngine;
using UnityEngine.InputSystem;

public class PausarSistemaSolar : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject planeFinder;

    private Rotation[] rotaciones;
    private bool detenido;
    private bool colocado;
    private float aceptarToqueDesde;

    private void Awake()
    {
        // Busca todos los scripts Rotation dentro del sistema solar.
        rotaciones = GetComponentsInChildren<Rotation>(true);

        if (arCamera == null)
            arCamera = Camera.main;
    }

    // Se llamará cuando Vuforia coloque el sistema solar.
    public void ActivarInteraccion(GameObject contenidoColocado)
    {
        colocado = true;

        // Evita que el mismo toque que colocó el sistema lo detenga.
        aceptarToqueDesde = Time.unscaledTime + 0.3f;

        // Impide que los siguientes toques cambien su posición.
        if (planeFinder != null)
            planeFinder.SetActive(false);
    }

    private void Update()
    {
        if (!colocado || Time.unscaledTime < aceptarToqueDesde)
            return;

        if (!LeerPulsacion(out Vector2 posicion))
            return;

        Ray rayo = arCamera.ScreenPointToRay(posicion);

        if (!Physics.Raycast(rayo, out RaycastHit golpe))
            return;

        // Comprueba que se tocó el sistema o alguno de sus hijos.
        bool tocoSistema =
            golpe.transform == transform ||
            golpe.transform.IsChildOf(transform);

        if (!tocoSistema)
            return;

        detenido = !detenido;

        foreach (Rotation rotacion in rotaciones)
        {
            rotacion.enabled = !detenido;
        }

        Debug.Log(detenido
            ? "Sistema solar detenido"
            : "Sistema solar en movimiento");
    }

    private bool LeerPulsacion(out Vector2 posicion)
    {
        // Toque en Android.
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            posicion =
                Touchscreen.current.primaryTouch.position.ReadValue();

            return true;
        }

        // Clic en el editor.
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            posicion = Mouse.current.position.ReadValue();
            return true;
        }

        posicion = Vector2.zero;
        return false;
    }
}