using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsPlayer;

    //Stats
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;
    public int explosionDamage;
    public float explosionRange;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physic_mat;

    private void Setup()
    {
        //Create a new physics material
        physic_mat = new PhysicMaterial();
        physic_mat.bounciness = bounciness;
        physic_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physic_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physic_mat;
        //Set gravity
        rb.useGravity = useGravity;
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies
        Collider [] player = Physics.OverlapSphere(transform.position, explosionRange, whatIsPlayer);

        if (player.Length > 0)
            player[0].GetComponent<PlayerHealth>().Damage(explosionDamage);

        Invoke("Delay", 0.05f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionDamage);
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();   
    }

    // Update is called once per frame
    void Update()
    {
        //When to explode projectile
        if (collisions > maxCollisions) Explode();

        //Count down lifetime
        if (maxLifetime <= 0) Explode() ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;

        if (collision.collider.CompareTag("Player") && explodeOnTouch) Explode();
    }
}
