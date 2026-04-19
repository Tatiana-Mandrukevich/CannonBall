using System;
using TargetControl;
using UnityEngine;

namespace ScoreControl
{
    public class ScoreCollector : MonoBehaviour
    {
        [SerializeField] private TargetGroup _targetGroup;
        
        private int _score;
        
        public event Action<int> ScoreChanged;
        
        private int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreChanged?.Invoke(value);
            }
        }
        
        private void Start()
        {
            Score = 0;
        }

        private void OnEnable()
        {
            _targetGroup.Hit += OnTargetGroupHit;
        }

        private void OnDisable()
        {
            _targetGroup.Hit -= OnTargetGroupHit;
        }

        private void OnTargetGroupHit()
        {
            Score++;
        }
    }
}