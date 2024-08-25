using System.Collections;
using UnityEngine;

public class DialogueFade : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }
}
