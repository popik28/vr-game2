using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
        [SerializeField] GameObject projectile, shootFromHere;
    [SerializeField] float timeBetweenAttacks;
    private bool alreadyAttacked;

    // Start is called before the first frame update
    void Start()
    {
        alreadyAttacked=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!alreadyAttacked)
        {

        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.transform.position = shootFromHere.transform.position;
        rb.AddForce(transform.forward * 3.5f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
                Debug.Log("update");

        }
    }
      private void ResetAttack()
    {
        Debug.Log("invok func");
        alreadyAttacked = false;
    }
}
