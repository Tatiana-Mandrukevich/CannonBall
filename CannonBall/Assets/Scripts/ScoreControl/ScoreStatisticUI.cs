using System;
using TMPro;
using UnityEngine;

namespace ScoreControl
{
    public class ScoreStatisticUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private ScoreCollector _scoreCollector;

        private void OnEnable()
        {
            _scoreCollector.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _scoreCollector.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int value)
        {
            _score.text = value.ToString();
        }
    }
}