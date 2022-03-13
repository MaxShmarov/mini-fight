using UnityEngine;

namespace MiniFight.Configs
{
    [CreateAssetMenu(fileName = "Field config", menuName = "Configs/New field config")]
    public class GameFieldConfig : ScriptableObject
    {
        [SerializeField, Tooltip("Size by X")] private int _width;
        [SerializeField, Tooltip("Size by Z")] private int _height;

        public int Width => _width;
        public int Height => _height;
    }
}