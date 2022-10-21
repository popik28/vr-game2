using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] GameObject projectile, shootFromHere;
    [SerializeField] float timeBetweenAttacks;
    private bool alreadyAttacked;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        alreadyAttacked=false;
        //timeBetweenAttacks = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {

        if (!alreadyAttacked)
        {
            AttackPlayer();

        }

    }

    private void AttackPlayer()
    {

        Vector3 targetPosition = new Vector3(Random.Range(-78f, -50f), 9f, Random.Range(20f, 35f));
        //Randomize a position in the fighting area of the castle

        transform.LookAt(targetPosition);

        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.transform.position = shootFromHere.transform.position;
        rb.AddForce(transform.forward * 3.5f, ForceMode.Impulse);
        rb.AddForce(transform.up * -1f, ForceMode.Impulse);

        alreadyAttacked = true;
        StartCoroutine(DelayAttack());
    }

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
    }

    private void ResetAttack()
    {
        Debug.Log("invok func");
        alreadyAttacked = false;
    }
}
