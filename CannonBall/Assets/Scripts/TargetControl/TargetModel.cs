using DG.Tweening;
using UnityEngine;

namespace TargetControl
{
    public class TargetModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _hitMaterial;
        
        private Sequence _sequence;
        private Material _defaultMaterial;
        private Vector3 _defaultScale;
        
        public void AnimateHit()
        {
            _sequence?.Kill();
            
            _renderer.transform.localScale = _defaultScale;
            _sequence = DOTween.Sequence();
            _sequence.AppendCallback(() => _renderer.material = _hitMaterial);
            _sequence.Join(_renderer.transform.DOPunchScale(_defaultScale * 1.2f, 0.5f));
            _sequence.AppendInterval(0.2f);
            _sequence.AppendCallback(() => _renderer.material = _defaultMaterial);  
        }
        
        private void Start()
        {
            _defaultMaterial = _renderer.material;
            _defaultScale = _renderer.transform.localScale;
        }
        
        private void OnValidate()
        {
            if (_renderer == null)
            {
                var component = GetComponent<MeshRenderer>();

                if (component == null)
                {
                    Debug.LogError($"Component MeshRenderer is not found on {gameObject.name}", this);
                }
                else
                {
                    _renderer = component;
                }
            }
        }
    }
}