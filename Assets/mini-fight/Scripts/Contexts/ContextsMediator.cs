using MiniFight.Interfaces;
using System;

namespace MiniFight.Contexts
{
    public class ContextsMediator : IDisposable
    {
        private UISceneContext _uiContext;
        private FightSceneContext _fightContext;

        public ContextsMediator(UISceneContext uiContext, FightSceneContext fightContext)
        {
            _uiContext = uiContext;
            _fightContext = fightContext;
        }

        public void Match()
        {
            _uiContext.Play += OnPlay;
            _uiContext.Exit += OnExit;
            _uiContext.Restart += OnRestart;
            _fightContext.Finish += OnFinish;
        }

        public void Run()
        {
            _uiContext.StartContext();
        }

        private void OnRestart()
        {
            _fightContext.Restart();
        }

        private void OnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }

        private void OnFinish(IFightResult result)
        {
            _uiContext.ShowResult(result);
        }

        private void OnPlay()
        {
            _fightContext.StartContext();
        }

        public void Dispose()
        {
            _uiContext.Play -= OnPlay;
            _uiContext.Exit -= OnExit;
            _uiContext.Restart -= OnRestart;
            _fightContext.Finish -= OnFinish;
        }
    }
}