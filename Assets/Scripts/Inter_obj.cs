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

    // Appel� lors du lancer de l'objet
    public void Throw(Vector3 velocity, Vector3 angularVelocity)
    {
        rb.velocity = velocity;
        rb.angularVelocity = angularVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        // V�rifie si la collision a eu lieu avec un objet ennemi
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Infliger des d�g�ts � l'ennemi 
            enemy.TakeDamage(damage);
            Vector3 collisionPoint = collision.contacts[0].point;
            AudioSource.PlayClipAtPoint(DestroySound, collisionPoint);
            GameObject instantiatedExploseFlash = Instantiate(ExploseFlash, collisionPoint, Quaternion.identity);
            Destroy(instantiatedExploseFlash, 0.5f);
            // D�truire la bouteille apr�s avoir touch� un ennemi
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


