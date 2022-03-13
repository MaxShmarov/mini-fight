using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _yPosition;

        public void SetStartingPosition(IGameField gameField)
        {
            var size = gameField.GetSize();

            _camera.transform.position = new Vector3(CalculateX(size.x), _yPosition, CalculateZ(size.y));
        }

        private float CalculateX(int width)
        {
            return (width - 1f) * 0.5f;
        }

        private float CalculateZ(int height)
        {
            return (-height - 1f) * 0.5f;
        }
    }
}