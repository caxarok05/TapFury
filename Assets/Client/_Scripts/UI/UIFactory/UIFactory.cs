using Scripts.Infrastructure.AssetManagement;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.States
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly DiContainer _container;

        private Transform _uiMenuRoot;

        public UIFactory(IAssetProvider assets, DiContainer container)
        {
            _assets = assets;
            _container = container;
        }

        public async Task CreateUIMenuRoot()
        {
            GameObject rootObject = await _assets.Load<GameObject>(AssetAdress.UIMenuRootPath);
            _container.InstantiatePrefab(rootObject);
            _uiMenuRoot = rootObject.transform;
        }
    }
}