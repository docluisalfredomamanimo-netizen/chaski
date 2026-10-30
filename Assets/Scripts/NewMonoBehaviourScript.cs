using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //1 Variable pública que verás en el Inspector para ajustar la velocidad
    public float velocidad = 5f; 

    //1 Variable privada para almacenar la referencia al componente de físicas 2D
    private Rigidbody2D rb2D;
    
    // 2
    public float fuerzaSalto = 10f;
    // 2
    private bool estaEnSuelo = true;

    //1 El método Start SÍ debe tener código ahora para conectar el componente automáticamente
    void Start()
    {
        // Busca y guarda el componente Rigidbody2D asignado a este círculo
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //1 Detecta la entrada del teclado (A/D o flechas)
        float movimientoH = Input.GetAxis("Horizontal");

        //1 Aplica la velocidad directamente al vector de velocidad física del Rigidbody2D
        //1 Mantiene la velocidad actual en el eje Y (para que caiga por gravedad si es necesario)
        rb2D.linearVelocity = new Vector2(movimientoH * velocidad, rb2D.linearVelocity.y);

        // 2
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            Saltar();
        }
    }

    // 2
    void Saltar()
    {
        // Aplica una fuerza de impulso hacia arriba
        rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        estaEnSuelo = false; // Evita saltar de nuevo en el aire hasta tocar el suelo
    }

    // 2 Detecta cuando el objeto toca el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            estaEnSuelo = true;
        }
    }
}
