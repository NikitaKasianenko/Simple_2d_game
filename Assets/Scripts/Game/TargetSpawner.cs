using UnityEngine;
using System.Collections;
using System;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    private RectTransform playableArea;
    private GameObject currentTarget;
    private Coroutine spawnRoutine;
    private Action<BoosterType> onTargetClicked;
    private BoosterChance[] chances;
    

    [Serializable]
private struct BoosterChance
{
    public BoosterType Type;
    public float Chance;

    public BoosterChance(BoosterType type, float chance)
    {
        Type = type;
        Chance = chance;
    }
}


    private void Awake()
    {
        playableArea = GetComponent<RectTransform>();
    }

    public void Init(bool useSeed)
    {
        var options = GameConfigProvider.Instance.Economy;

        if (useSeed)
        {
            UnityEngine.Random.InitState(options.seed);
        }

        chances = new[]
        {
                new BoosterChance(BoosterType.Freezer, options.freezzerSpawnRate),
                new BoosterChance(BoosterType.Doublepoint, options.doublePointSpawnRate),
                new BoosterChance(BoosterType.None, options.defaultSpawnRate),
        };
    }


    public void StartSpawning(Action<BoosterType> onTarget)
    {

        this.onTargetClicked = (type) =>
        {
            onTarget?.Invoke(type);
            //HandleClicked();
        };


        Init(GameConfigProvider.Instance.Economy.useCustomSeed);

        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    public void StopSpawning()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        checkTarget();
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnTarget();
            yield return new WaitForSeconds(GameConfigProvider.Instance.Economy.targetLifetime);
        }
    }

    private void SpawnTarget()
    {
        checkTarget();

        var sprites = GameConfigProvider.Instance.Design.targetSprites;
        var sprite = sprites[UnityEngine.Random.Range(0,sprites.Length)];

        Rect rect = playableArea.rect;
        
        float x = UnityEngine.Random.Range(rect.xMin, rect.xMax);
        float y = UnityEngine.Random.Range(rect.yMin, rect.yMax);
        Vector3 localPos = new Vector3(x, y, 0);

        currentTarget = Instantiate(targetPrefab, playableArea);
        currentTarget.transform.localPosition = localPos;
        currentTarget.GetComponent<UnityEngine.UI.Image>().sprite = sprite;

        var target = currentTarget.GetComponent<Target>();
        BoosterType type = GetWeightedRandomBoosterType();
        target.Init(onTargetClicked, type);

    }

    private void checkTarget()
    {
        if (currentTarget != null)
        {
            currentTarget.GetComponent<Target>().OnHit();
            //currentTarget.SetActive(false);
            //Destroy(currentTarget, 1f);
        }
    }

    public void HandleClicked()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnLoop());
    }


    private BoosterType GetWeightedRandomBoosterType()
    {
        float total = 0f;
        foreach (var chance in chances)
        {
            total += chance.Chance;
        }

        float rand = UnityEngine.Random.Range(0f, total);
        float cumulative = 0f;

        foreach (var chance in chances)
        {
            cumulative += chance.Chance;
            if (rand < cumulative)
                return chance.Type;
        }

        return BoosterType.None;
    }

}
