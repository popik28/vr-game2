using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMenu : MonoBehaviour
{

    private IEnumerator countDown() 
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
