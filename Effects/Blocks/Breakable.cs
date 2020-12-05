using Sirenix.OdinInspector;
using System;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Breakable : MonoBehaviour, IBreakTrigger
{
    public event Action OnBreak;

#pragma warning disable 649
    [SerializeField] [Required] private AudioClip breakSound;
    [SerializeField] [Required] private Sprite[] breakLevels;
#pragma warning restore 649

    private int timesHit = 0;
    private SpriteRenderer spriteRenderer;


    public void Break() => OnBreak?.Invoke();

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        OnBreak += TriggerBreakVFX;
        OnBreak += DestroyBlock;

        foreach (BreakEffect effect in GetComponents<BreakEffect>()) OnBreak += effect.Break;
    }

    private void OnCollisionEnter2D(Collision2D other) => ProcessHit();

    private void ProcessHit()
    {
        timesHit++;
        if (breakLevels.Length <= timesHit)
            Break();
        else
            IncreaseBreakLevel();
    }

    private void IncreaseBreakLevel() => spriteRenderer.sprite = breakLevels[timesHit];

    private void TriggerBreakVFX() => AudioSource.PlayClipAtPoint(breakSound, transform.position, 0.3f);

    private void DestroyBlock() => Destroy(gameObject);

    private void OnDisable() => OnBreak = null;
}