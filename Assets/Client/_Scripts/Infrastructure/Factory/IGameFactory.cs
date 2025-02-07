using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject Hud { get; set; }
        GameObject Camera { get; set; }

        Task CreateCamera();
        Task CreateHud();
        Task<GameObject> CreateNote(string path, Vector2 at);
        Task CreateNoteSpawner();
        Task WarmUpAsync();
    }
}
