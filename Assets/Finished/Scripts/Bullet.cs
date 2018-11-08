using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int Speed = 5;
	public int Damage = 50;
	public GameObject DestroyPrefab; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate ()
    {

		transform.Translate(Vector3.forward * Time.deltaTime * Speed);

		if (gameObject.name == "Bullet New(Clone)")
		{
			Destroy(this.gameObject, 2);
		}

	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Debug.Log("HIT with trigger " + other.gameObject);
            other.gameObject.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            Instantiate(DestroyPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        //if (other.tag == "GROUND")
        //{
        //    Debug.Log(" DONT HIT THE FLOOR");
        //}
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("HIT with Collision " + collision.gameObject);
            collision.gameObject.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            Instantiate(DestroyPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Enemy")
    //    {

    //        Debug.Log("HIT");
    //        collision.gameObject.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
    //        Instantiate(DestroyPrefab, transform.position, transform.rotation);
    //        Destroy(this.gameObject);
    //    }

    //    if (collision.gameObject.tag == "GROUND")
    //    {
    //        Debug.Log(" DONT HIT THE FLOOR");
    //    }
    //}


}
