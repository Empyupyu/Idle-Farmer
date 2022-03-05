using UnityEngine;
using DG.Tweening;

public class Wheat : MonoBehaviour
{
    [SerializeField] private float _maximumGrown = 1f;

    [SerializeField] private float _timeToGrown = 10f;

    [SerializeField] private Harvest _harvest;

    [SerializeField] private float _spawnForce;

    [SerializeField] private float _spawnRadius;

    [SerializeField] private GameObject _cutWheat;

    private float _originalGrown;

    private bool _canHarvesting;

    private void Awake()
    {
        _originalGrown = transform.localScale.y;

        Initialize();
    }

    public void Initialize()
    {
        transform.localScale = new Vector3(transform.localScale.x, _maximumGrown, transform.localScale.z);

        CanHarvesting();
    }

    public void Growning()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScaleY(_maximumGrown, _timeToGrown));

        sequence.AppendCallback(() =>
            {
                CanHarvesting();
            });
    }

    public void Harvesting()
    {
        if (!_canHarvesting) return;

        CanHarvesting();

        var harvest =  Instantiate(_harvest, transform.position, Quaternion.identity);

        harvest.GetComponent<Rigidbody>().AddExplosionForce(_spawnForce, harvest.transform.position, _spawnRadius);

        transform.localScale = new Vector3(transform.localScale.x, _originalGrown, transform.localScale.z);

        var cutWheat = Instantiate(_cutWheat, transform.position, _cutWheat.transform.rotation);

        cutWheat.GetComponent<Rigidbody>().AddExplosionForce(_spawnForce, harvest.transform.position, _spawnRadius);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(cutWheat.transform.DOScale(0, 1f));

        sequence.AppendCallback(() => Destroy(cutWheat));

        Growning();
    }

    private void CanHarvesting()
    {
        _canHarvesting = !_canHarvesting;
    }
}
