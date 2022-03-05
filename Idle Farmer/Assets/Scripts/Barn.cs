using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barn : MonoBehaviour
{
    [SerializeField] private Transform _harvestsPosition;

    [SerializeField] private Transform _coinPosition;

    [SerializeField] private float _sellHarvestAnimationTime = .1f;

    private List<Harvest> _harvests;

    public void SellHarvest(Character character)
    {
        if (_harvests != null) return;

        _harvests = new List<Harvest>(character.CurrentStackValue);

        Sequence sequence = DOTween.Sequence();

        foreach (var harvest in _harvests)
        {
            sequence.AppendCallback(() => harvest.SellAnimation(_harvestsPosition, _coinPosition));

            sequence.AppendInterval(_sellHarvestAnimationTime);

            sequence.AppendCallback(() => character.RemoveHarvestInStack(harvest));
        }

        _harvests = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<Character>();

        if (character != null)
        {
            SellHarvest(character);
        }
    }
}
