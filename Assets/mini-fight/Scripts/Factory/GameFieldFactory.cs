using MiniFight.Core;
using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Field factory", menuName = "Factories/New field factory")]
    public class GameFieldFactory : ScriptableObject, IGameFieldFactory
    {
        [SerializeField, Tooltip("Size by X")] private int _width;
        [SerializeField, Tooltip("Size by Z")] private int _height;
        [SerializeField] private GameTileViewFactory _viewFactory;

        public IGameField Create()
        {
            var field = new GameField(_width, _height);

            field.Initialize(_viewFactory);

            return field;
        }
    }
}