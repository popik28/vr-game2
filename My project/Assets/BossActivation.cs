using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Boss").GetComponent<Boss>().healthBarUI.SetActive(true);
        GameObject.Find("Boss").GetComponent<Boss>().enabled = true;
        Destroy(gameObject);

    }
}
