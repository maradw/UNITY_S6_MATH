using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion3D : MonoBehaviour
{
    [SerializeField] private float angulo;
    [SerializeField] private Quaternion q = Quaternion.identity; //<0,,0,0,1>
    private float anguloSen;
    private float anguloCos;

    private void Start() 
    {
        Debug.Log(Mathf.Sin(90));
    }

    private void FixedUpdate() {
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulo * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulo * 0.5f);

        q.Set(anguloSen, 0,0 , anguloCos);

        transform.rotation = q;
    }
}
