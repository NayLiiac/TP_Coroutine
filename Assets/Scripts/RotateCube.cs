using System.Collections;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private Coroutine _spinning;

    public void RotateTheCube() 
    {
        _spinning = StartCoroutine(RotateCoroutine());
    }

    public void StopTheCube() 
    {
        StopCoroutine(_spinning);
    }



    public IEnumerator RotateCoroutine() 
    {
        float time = 0f;
        while (time <= 5f) {
            _cube.transform.Rotate(10, 50, 180);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
