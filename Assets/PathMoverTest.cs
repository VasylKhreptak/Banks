using System.Collections;
using DG.Tweening;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEditor;
using UnityEngine;

public class PathMoverTest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _endPoint;

    [Header("Preferences")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minRange;
    [SerializeField] private float _maxRange;
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _spawnInterval = 0.2f;

    #region MonoBehaviour

    private IEnumerator Start()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    #endregion

    private void Spawn()
    {
        Vector3 targetPoint = _endPoint.position;
        Vector3 startPoint = transform.position;
        Vector3 intermediatePoint = startPoint + Random.insideUnitSphere.normalized * Random.Range(_minRange, _maxRange);

        GameObject instance = Instantiate(_prefab, startPoint, Quaternion.identity);

        Vector3[] waypoints = new Vector3[3];
        waypoints[0] = startPoint;
        waypoints[1] = intermediatePoint;
        waypoints[2] = targetPoint;

        Path path = new Path(PathType.CatmullRom, waypoints, 10, Color.blue);
        
        instance.transform
            .DOPath(path, _duration)
            .OnComplete(() => Destroy(instance))
            .Play();
    }
}
