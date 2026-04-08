using System;
using UnityEngine;

namespace CannonControl
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private InputSystem _input;
        [SerializeField] private Transform _spawnPoint;

        private void OnEnable()
        {
            _input.FirePressed += OnFirePressed;
        }

        private void OnDisable()
        {
            _input.FirePressed -= OnFirePressed;
        }

        private void OnFirePressed()
        {
            Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}