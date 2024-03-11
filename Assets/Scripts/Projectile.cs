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
        if (target == null)
        {
            Destroy(gameObject); // Vernietig dit projectiel als er geen doelwit is
            return;
        }

        // Draai het projectiel naar het doel
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = lookRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Vernietig dit projectiel als het doelwit niet meer bestaat
            return;
        }

        // Beweeg het projectiel naar het doel
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Controleer of het projectiel het doel heeft bereikt
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 0.2f)
        {
            // Voer schade toe aan het doel (bijvoorbeeld via een Health-component)
            // Hier kunnen verdere acties worden toegevoegd, zoals het afspelen van een impactgeluid of effect.

            // Vernietig dit projectiel
            Destroy(gameObject);
        }
    }
}
