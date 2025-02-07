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
    public Vector3 lastNotePos;
    public RectTransform rectTransform;
    public int count;

    public int spawnInterval = 1;

    private IGameFactory _gameFactory;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IGameFactory gameFactory, IStaticDataService staticDataService)
    {
        _gameFactory = gameFactory;
        _staticDataService = staticDataService;
        SetUpRectTransform();
    }

    private void Start()
    {
        SpawnNote();
    }

    public async void SpawnNote()
    {
        Vector3[] v = DisplayWorldCorners();
        Vector3 spawnPos;
        var difficulty = _staticDataService.ForDifficulty(1);
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(v[0].x, v[1].x), Random.Range(v[0].y, v[1].y));

            while (lastNotePos != null && Vector3.Distance(spawnPos, lastNotePos) < prefab.GetComponent<SpriteRenderer>().bounds.size.x)
            {
                spawnPos = new Vector3(Random.Range(v[0].x, v[1].x), Random.Range(v[0].y, v[1].y));
            }
            lastNotePos = spawnPos;
            Debug.Log(lastNotePos);
            GameObject noteObject = await _gameFactory.CreateNote(AssetAdress.NotePath, lastNotePos);
            await Task.Delay((int)difficulty.noteSpawnSpeed);
        }

    }

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

