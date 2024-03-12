using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Debug.LogWarning("No target assigned to projectile.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Vernietig dit projectiel als het doelwit niet meer bestaat
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
