using Scripts.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Client._Scripts.Infrastructure.Installers
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public GameObject coroutineRunner;
        public override void InstallBindings()
        {
            InstantiateCoroutineRunner();
            Container.Bind<SceneLoader>().AsSingle();
        }
        private void InstantiateCoroutineRunner()
        {
            CoroutineRunner bootstraper = Container.InstantiatePrefabForComponent<CoroutineRunner>(coroutineRunner);
            Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(bootstraper).AsSingle();
        }
    }
}
