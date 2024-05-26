using System.Collections;
using UnityEngine;

public class BallSprite : BallController
{
    [SerializeField] private GameObject visualModel;
    [SerializeField] private Sprite spriteImage;

    private float spriteScale = 0.08f;
    private float displayTime = 2.0f;
    private float spriteDirect = 0.507f;

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();

        if (segment != null && segment.Type != SegmentType.Empty)
        {
            Vector3 contactPoint = visualModel.transform.position;

            GameObject spriteObject = new GameObject("CollisionSprite" + 1);
            spriteObject.transform.position = new Vector3(contactPoint.x, segment.transform.position.y + spriteDirect, contactPoint.z);
            spriteObject.transform.localScale = Vector3.one * spriteScale;

            spriteObject.transform.parent = segment.transform;

            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = spriteImage;
            spriteRenderer.color = visualModel.GetComponent<Renderer>().material.color;

            spriteObject.transform.rotation = Quaternion.Euler(90f, Random.Range(0f, 360f), 0f);

            StartCoroutine(FadeSprite(spriteObject, displayTime));
        }
    }

    private IEnumerator FadeSprite(GameObject spriteObject, float fadeTime)
    {
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        Destroy(spriteObject);
    }
}

