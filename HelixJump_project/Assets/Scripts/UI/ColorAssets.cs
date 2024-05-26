using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorAssets : MonoBehaviour
{
    [HideInInspector] private float brightnessFactor = 1.6f;
    private MeshRenderer meshRenderer;
    private Image image;

    [SerializeField] private List<Material> setMaterial;
    private int currentIndex;

    private void Start()
    {
        RandomMaterials();

        Material randomMaterial = GetNextMaterial();
        meshRenderer = GetComponent<MeshRenderer>();
        image = GetComponent<Image>();

        if (meshRenderer != null)
        {
            Material material = meshRenderer.material;

            if (meshRenderer.material != null)
            {
                meshRenderer.material = randomMaterial;
            }
        }

        if (image != null)
        {
            Color color = image.color;
            color = randomMaterial.color;
            image.color = color * brightnessFactor;
        }
    }

    private void RandomMaterials()
    {
        for (int i = 0; i < setMaterial.Count; i++)
        {
            Material temp = setMaterial[i];
            int randomIndex = Random.Range(i, setMaterial.Count);
            setMaterial[i] = setMaterial[randomIndex];
            setMaterial[randomIndex] = temp;
        }
    }

    private Material GetNextMaterial()
    {
        if (currentIndex < setMaterial.Count)
        {
            Material nextMaterial = setMaterial[currentIndex];
            currentIndex++;
            return nextMaterial;
        }
        else
        {
            return null;
        }


    }
}
