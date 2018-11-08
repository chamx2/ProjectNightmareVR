using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    //public GameObject enemyPrefab;
	public int Health = 100;
	public AudioClip GunSound;
	public GameObject DestroyPrefab;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT !" + other.gameObject.name);
    }

    // Use this for initialization
    void ApplyDamage (int Damage) 
	{

		Health -= Damage;

		if (Health <= 0)

		{

			Dead();
		}

	}
	
	void Dead () 
	{
		Destroy(this.gameObject);
		Instantiate (DestroyPrefab, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(GunSound, transform.position);
	}
}
