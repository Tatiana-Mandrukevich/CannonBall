using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallControl
{
    public class BallPool : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 4f;
        [SerializeField] private Ball _prefab;
        
        private Queue<Ball> _pool = new();
        private WaitForSeconds _waitForSeconds;

        void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_lifeTime);
        }

        public Ball Get()
        {
            if (_pool.TryDequeue(out var ball))
            {
                ball.gameObject.SetActive(true);
            }
            else
            {
                ball = Instantiate(_prefab);
            }
            
            StartCoroutine(Deactivate(ball));
            return ball;
        }
        
        private IEnumerator Deactivate(Ball ball)
        {
            yield return _waitForSeconds;    
            _pool.Enqueue(ball);
            ball.gameObject.SetActive(false);
        }
    }
}