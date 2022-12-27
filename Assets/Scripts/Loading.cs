using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go(1));        
    }

    private void Update()
    {
        
    }

    private IEnumerator Go(int Scene)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(Scene);
    }
}
