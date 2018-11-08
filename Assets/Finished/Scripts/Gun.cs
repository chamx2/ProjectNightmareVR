using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject gun;

    Animation gun_Animator;
    public string shootAnimationName;

	public GameObject Bullet;
	public Transform BulletSpawn;
	public AudioClip GunSound;
	public float NextFire;
	public float FireRate;

    IEnumerator waitForClip;
	// Use this for initialization
	void Start ()
    {
        gun_Animator = gun.GetComponent<Animation>();
        shootAnimationName = gun_Animator.GetClip("Shoot").name;
        waitForClip = waitAnimation();
        StartCoroutine(waitForClip);
    }

	// Update is called once per frame
	void FixedUpdate()
    {

        if (Input.GetMouseButton(0) & Time.time > NextFire)
        {
            //gun_Animator.enabled = true;
            //gun_Animator.Play(shootAnimationName);
            gun_Animator.Play();
            Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            AudioSource.PlayClipAtPoint(GunSound, transform.position);
            NextFire = Time.time + FireRate;
            //StartCoroutine(waitForClip);
            
        }

    }

    IEnumerator waitAnimation()
    {
      
        yield return new WaitForSeconds(0.5f);
        
        //Debug.Log("STOP");
    }
}
