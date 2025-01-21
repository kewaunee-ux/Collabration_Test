using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color[] colors;
    public Material material;
    public void ColorChanger(int value)
    {
        material.color = colors[value];
    }
}
