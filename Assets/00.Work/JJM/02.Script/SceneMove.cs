using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class SceneMove : MonoBehaviour
{
    [SerializeField] private UnityEvent _un;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(A());
    }

    private IEnumerator A()
    {
        _un.Invoke();

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);

    }
}
