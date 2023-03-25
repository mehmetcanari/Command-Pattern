using UnityEngine;
using DG.Tweening;

namespace MehmetCanAri.Commands
{
    public class Move : ICommand
    {
        private Vector3 _targetPosition;
        private Vector3 _lastPosition;
    
        private Transform _currentObject;
        private float _moveTime;

        private Tween _executeTween;
        private Tween _undoTween;

        public Move(Transform targetPosition, Transform currentObject, float moveTime)
        {
            _targetPosition = targetPosition.position;
            _currentObject = currentObject;
            _moveTime = moveTime;
        }
    
        public void MoveObject()
        {
            _lastPosition = _currentObject.position;
            _undoTween.Kill();
            _executeTween = _currentObject.DOMove(_targetPosition, _moveTime).SetEase(Ease.Linear);
        }
    
        public void UndoObject()
        {
            if (_lastPosition == Vector3.zero) return;
            _executeTween.Kill();
            _undoTween = _currentObject.DOMove(_lastPosition, _moveTime).SetEase(Ease.Linear);
        }

        public void Execute()
        {
            MoveObject();
        }

        public void Undo()
        {
            UndoObject();
        }
    }
}

