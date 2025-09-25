using UnityEngine;
using TMPro; //Para ocupar la interfaz

public class ControllerCharacter : MonoBehaviour
{

    [SerializeField] private float velocidad = 5.0f;
    [SerializeField] private GameObject bala;
    [SerializeField] private TMP_Text txtEnemy;
    [SerializeField] Rigidbody rb;
     public int numEnemy = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        txtEnemy.text = "Enemy:" + numEnemy;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        txtEnemy.text = "Enemy:" + numEnemy;
        
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movX, 0, movZ) * velocidad;

        rb.linearVelocity = new Vector3(movimiento.x, rb.linearVelocity.y, movimiento.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, transform.position, transform.rotation);
        }
    }
}
