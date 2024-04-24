using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed;
    [SerializeField] private Rigidbody enemyRBD;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        enemyRBD.velocity = new Vector3(0, 0, -speed*1);
    }
    
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
