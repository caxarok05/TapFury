using Scripts.Infrastructure.AssetManagement;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        public GameObject Hud { get; set; }
        public GameObject Camera { get; set; }

        private IAssetProvider _assets;
        private readonly DiContainer _container;

        
        public GameFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assets = assetProvider;
            _container = container;
        }

        public async Task WarmUpAsync()
        {
            await _assets.Load<GameObject>(AssetAdress.NotePath);

        }


        public async Task<GameObject> CreateNote(string path, Vector2 at)
        {
            GameObject prefab = await _assets.Load<GameObject>(path);
            GameObject note = _container.InstantiatePrefab(prefab,at, Quaternion.identity, null);
            return note;
        }
        public async Task CreateNoteSpawner()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAdress.SpawnerPath);
            GameObject spawner = _container.InstantiatePrefab(prefab);
        }

        public async Task CreateHud()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAdress.HudPath);
            GameObject hud = _container.InstantiatePrefab(prefab);
            Hud = hud;
        }

        public async Task CreateCamera()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAdress.CameraPath);
            GameObject camera = _container.InstantiatePrefab(prefab);
            Camera = camera;
        }

    }
}
