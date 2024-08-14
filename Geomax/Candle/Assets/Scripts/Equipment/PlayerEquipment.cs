using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private GameObject[] _equipments;

    private IEquipment[] _equips;
    private IEquipment _currentEquip;

    public IEquipment CurrentEquipment => _currentEquip;

    private void OnValidate()
    {
        try
        {
            List<GameObject> valid = new List<GameObject>();

            for (int i = 0; i < _equipments.Length; i++)
            {
                if (_equipments[i].GetComponent<IEquipment>() == null)
                {
                    Debug.LogError($"Critical error -> gameObject: {_equipments[i]} are not contains any script realises {nameof(IEquipment)} interface");
                }
                else
                {
                    valid.Add(_equipments[i]);
                }
            }

            _equipments = valid.ToArray();
        }
        catch { }
    }

    private void Awake()
    {
        _equips = new IEquipment[_equipments.Length];

        for (int i = 0; i < _equips.Length; i++)
        {
            _equips[i] = _equipments[i].GetComponent<IEquipment>();
        }

        SetEquipment(0);
    }

    public void SetEquipment(int id)
    {
        if (id < 0 || id >= _equips.Length)
        {
            Debug.LogError($"Critical error -> invalid equipment id: {id}; BOUNDS: (0, {_equips.Length - 1})");
            return;
        }

        DisableAllEquipments();

        _currentEquip = _equips[id];
        _equipments[id].SetActive(true);
    }

    private void DisableAllEquipments()
    {
        foreach (GameObject equipment in _equipments)
        {
            equipment.SetActive(false);
        }
    }
}