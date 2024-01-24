using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBAll : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] float forwardForce = 5f;

    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference move;
    


    Rigidbody rb;
    [SerializeField] Vector3 forward;
    [SerializeField] Vector3 right;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] LayerMask layerMask = Physics.DefaultRaycastLayers;//sigue siendo integer pero unity detecta como un campo desplegable que nos deja decidir que mascara
    [SerializeField] float groundCheckDistance = 0.03f;

    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //Options.performed += ActiveOptionsMenu; 
    }

    private void OnEnable()
    {
        jump.action.Enable();
        move.action.Enable();

    }

    private void OnDisable()
    {
        jump.action.Disable();
        move.action.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        forward = Camera.main.transform.forward;
        forward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized; //te devuelve el vector normalizado a 1(basicamente apunta en diagonal, al normalizarlo apuntará recto)

        right = Camera.main.transform.right;
        right = Vector3.ProjectOnPlane(right, Vector3.up).normalized;

        Vector2 direction = move.action.ReadValue<Vector2>(); //Vecor2 es una imput action de 2 direcciones //Con read value obtenemos el valor que queremos leer
        Vector3 movement = (direction.y * forward) + (direction.x * right);


        rb.AddForce(movement * forwardForce);

        bool performJump = jump.action.ReadValue<float>() > 0f;//esto ultimo porque un boleano tiene decimales  
        if (performJump)
        {
            if (Physics.SphereCast(transform.position+(Vector3.up*groundCheckDistance/2f) /**/, transform.localScale.x * 0.5f, Vector3.down, out RaycastHit hit, 0.03f, layerMask))
            //Si esfera toca esto devuelve true //0.01 es distancia maxima y layermask es contra que capas puede tocal
            {
                rb.AddForce(Vector3.up * jumpForce);
            }

        }
    }
    private void ActiveoptionsMenu()
    {
        Debug.Log("hsdhsd");
    }
}