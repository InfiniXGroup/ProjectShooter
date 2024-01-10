using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Inter_obj : MonoBehaviour
{
    private Rigidbody rb;
    public AudioClip DestroySound;
    public GameObject ExploseFlash;
    public float damage = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Appelé lors du lancer de l'objet
    public void Throw(Vector3 velocity, Vector3 angularVelocity)
    {
        rb.velocity = velocity;
        rb.angularVelocity = angularVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision a eu lieu avec un objet ennemi
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Infliger des dégâts à l'ennemi 
            enemy.TakeDamage(damage);
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(DestroySound, collisionPoint);
            GameObject instantiatedExploseFlash = Instantiate(ExploseFlash, collisionPoint, Quaternion.identity);
            Destroy(instantiatedExploseFlash, 0.5f);
            // Détruire la bouteille après avoir touché un ennemi
            Destroy(gameObject);
        }
    }

    public void OnSelected(SelectEnterEventArgs args) 
    {
        if(args.interactorObject.transform.gameObject.GetComponent<GloveHandler>())
        {
            args.interactorObject.transform.gameObject.GetComponent<GloveHandler>().ShowGlove(false);
        }
    }
    public void OnDeselected(SelectExitEventArgs args) 
    {
        if (args.interactorObject.transform.gameObject.GetComponent<GloveHandler>())
        {
            args.interactorObject.transform.gameObject.GetComponent<GloveHandler>().ShowGlove(true);
        }
    }
}


