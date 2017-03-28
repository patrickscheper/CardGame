using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public MovieTexture textureMovie;

    void Start()
    {
        textureMovie.loop = true;
        textureMovie.Play();
    }
}
