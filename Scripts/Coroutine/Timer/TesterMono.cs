using UnityEngine;
using System.Collections;

public class TesterMono : MonoBehaviour
{
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _coroutine = StartCoroutine(LifeRoutine());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator LifeRoutine()
    {
        var timer = 0;

        while (true)
        {
            Debug.Log($"LifeRoutine: {timer}");
            yield return new WaitForSeconds(1f);
            timer++;
        }
    }
}