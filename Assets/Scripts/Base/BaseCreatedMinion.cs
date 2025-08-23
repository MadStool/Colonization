using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCreatedMinion : MonoBehaviour
{
    [SerializeField] private Bot _botPrefab;

    public Bot Create()
    {
        Bot minion = Instantiate(_botPrefab, transform.position, Quaternion.identity);
        minion.transform.parent = transform;
        minion.SetTargetPositionBase();

        return minion;
    }
}