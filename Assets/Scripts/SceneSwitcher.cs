using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoSingUp()
    {
        StartCoroutine(Go(1));
    }
    public void GoSingIn()
    {
        StartCoroutine(Go(2));
    }

    private IEnumerator Go(int Scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(Scene);
    }

}
