using Scripts.Infrastructure.Factory;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class NoteSpawner : MonoBehaviour
{
    public GameObject prefab;
    public RectTransform rectTransform;

    private Vector3 _lastNotePos;
    private bool _canSpawn = true;


    private IGameFactory _gameFactory;
    private IStaticDataService _staticDataService;
    private IBossHpHandler _bossHpHandler;

    [Inject]
    public void Construct(IGameFactory gameFactory, IStaticDataService staticDataService, IBossHpHandler bossHpHandler)
    {
        _gameFactory = gameFactory;
        _staticDataService = staticDataService;
        _bossHpHandler = bossHpHandler;
        SetUpRectTransform();
    }

    private void Start()
    {
        SpawnNotes();
        _bossHpHandler.OnBossDefeated += StopSpawning;
    }

    public async void SpawnNotes()
    {
        Vector3[] v = DisplayWorldCorners();
        Vector3 spawnPos;

        var difficulty = _staticDataService.CurrentDifficulty;

        while(_canSpawn)
        {
            spawnPos = new Vector3(Random.Range(v[0].x, v[1].x), Random.Range(v[0].y, v[1].y));

            while (_lastNotePos != null && Vector3.Distance(spawnPos, _lastNotePos) < prefab.GetComponent<SpriteRenderer>().bounds.size.x)
            {
                spawnPos = new Vector3(Random.Range(v[0].x, v[1].x), Random.Range(v[0].y, v[1].y));
            }
            _lastNotePos = spawnPos;
            Debug.Log(_lastNotePos);
            GameObject noteObject = await _gameFactory.CreateNote(AssetAdress.NotePath, _lastNotePos);
            await Task.Delay((int)difficulty.noteSpawnInterval);
        }

    }

    private void StopSpawning() => _canSpawn = false;

    private Vector3[] DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rectTransform.GetWorldCorners(v);
        return new Vector3[2] { v[0], v[2] };
        
    }

    private void SetUpRectTransform()
    {
        RectTransform[] rects = _gameFactory.Camera.GetComponentsInChildren<RectTransform>();
        foreach (RectTransform rect in rects)
        {
            if (rect.gameObject.CompareTag("Field"))
                rectTransform = rect;
        }
    }
}

public class NoteType
{
    public GameObject prefab;
}
