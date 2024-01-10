using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class shoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float damage = 10f;
    public float maxRange = 100f;
    public AudioClip ShootSound;
    public GameObject muzzleFlash;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(OnActivated);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        Shoot();
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(ShootSound, bulletSpawnPoint.position);
        GameObject instantiatedMuzzleFlash = Instantiate(muzzleFlash, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Destroy(instantiatedMuzzleFlash, 0.5f);

        // Perform raycast to check for hits
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit, maxRange))
        {
            // Deal damage to the hit object (if it has health)
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

}
