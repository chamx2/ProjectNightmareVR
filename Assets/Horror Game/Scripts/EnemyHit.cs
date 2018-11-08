using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float health = 100;
    public GameObject enemy;
    public Animation death_anim;

    IEnumerator enemydeath;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "GROUND")
        {
            //Debug.Log(" STANDBY " + this.gameObject.name);

        }

        if(collision.gameObject.tag == "Bullet")
        {
            //Debug.Log("RECEIVED BY COLLISION");
            this.health -= 50; 
            //Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            //Debug.Log("RECEIVED BY TRIGGER");
            //Debug.Log(other.name);
            this.health -= 50;
        }
    }
    // Use this for initialization
    void Start ()
    {
        enemy = this.gameObject;
        enemydeath = deathEnemy();
        death_anim = enemy.GetComponent<Animation>();

        //StartCoroutine(enemydeath);
	}

    void FixedUpdate()
    {

        if (this.health <= 0)
        {

            StartCoroutine(enemydeath);
        }
    }

    IEnumerator deathEnemy()
    {

       if(this.health <=0)
        {
            death_anim.Play("dead");
            yield return new WaitForEndOfFrame();

        }

    }
}
