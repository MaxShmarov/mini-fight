using MiniFight.Configs;
using MiniFight.Core;
using MiniFight.Interfaces;
using UnityEngine;

namespace MiniFight.Factory
{
    [CreateAssetMenu(fileName = "Field factory", menuName = "Configs/New field factory")]
    public class GameFieldFactory : ScriptableObject, IGameFieldFactory
    {
        [SerializeField] private GameFieldConfig _fieldConfig;
        [SerializeField] private GameTileViewFactory _viewFactory;

        public IGameField Create()
        {
            var field = new GameField(_fieldConfig.Width, _fieldConfig.Height);

            field.Initialize(_viewFactory);

            return field;
        }
    }
}