using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class RotateCubeButAsync : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private bool _isSpinning;
    CancellationTokenSource _cts;

    public async void SpinCube()
    {
        _isSpinning = true;
        await UniTask.Delay(5000, cancellationToken: _cts.Token).SuppressCancellationThrow();
        _isSpinning = false;
    }

    public void Update()
    {
        if (_isSpinning)
        {
            _cube.transform.Rotate(10, 50, 180);
        }
    }

    public void StartSpin()
    {
        _cts = new CancellationTokenSource();
        SpinCube();
    }

    public void StopSpin()
    {
        _cts.Cancel();
    }
}
