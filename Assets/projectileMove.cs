using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour {

    public float speed;
    public float fireRate;

    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

	// Use this for initialization
	void Start () {
		if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            var psmuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psmuzzle != null){
                Destroy(muzzleVFX, psmuzzle.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (speed!= 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);

        }
        else
        {
            Debug.Log("No Speed");
        }
	}
     void OnCollisionEnter(Collision col)
    {
        speed = 0;
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (hitPrefab != null){
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            var psHit = hitVFX.GetComponent<ParticleSystem>();
            if (psHit != null)
            {
                Destroy(hitVFX, psHit.main.duration);
            }
            else
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, psChild.main.duration);
            }
        }

        Destroy(gameObject);
    }
}
