using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocity = 2f;
 

    public static event Action OnEnemyCollision;


    [SerializeField] private Vector3 angulo;
    [SerializeField] private Quaternion dz = Quaternion.identity; 
    [SerializeField] private Quaternion dx = Quaternion.identity; 
    [SerializeField] private Quaternion dy = Quaternion.identity; 

    [SerializeField] private Quaternion result = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;

    }
    public void FixedUpdate()
    {

        anguloSen = SenAngle(angulo.z);
        anguloCos = SenAngle(angulo.z);
        dz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = SenAngle(angulo.x);
        anguloCos = SenAngle(angulo.x);
        dx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = SenAngle(angulo.y);
        anguloCos = SenAngle(angulo.y);
        dy.Set(0, anguloSen, 0, anguloCos);

        result = dy * dx * dz;

        transform.rotation = result;

        myRBD.velocity = new Vector2(_horizontal * velocity, _vertical * velocity);
  
        //myRBD.rotation = new Quaternion();
        //myRBD.rotation = result;
    }
    public static float SenAngle(float angle)
    {
        float angleSen = Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f);
        return angleSen;
    }
    public static float CosAngle(float angle)
    {
        float angleCos = Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f);
        return angleCos;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = q;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, -35, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(35, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(-35, 0, 0);
        }*/

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            OnEnemyCollision?.Invoke();
        }
    }
}
