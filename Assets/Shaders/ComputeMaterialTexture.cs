using UnityEngine;

public class ComputeMaterialTexture : MonoBehaviour
{
    public int[] textureDimensions = {256, 256};

    public ComputeShader computeShader;
    public RenderTexture shaderTexture;
    public Material outputMat;

    private void Start()
    {
        shaderTexture = CreateScreenTexture(textureDimensions[0], textureDimensions[1]);

        computeShader.SetTexture(0, "OutputTexture", shaderTexture);
        computeShader.Dispatch(0, shaderTexture.width / 8, shaderTexture.height / 8, 1);

        outputMat.mainTexture = shaderTexture;

    }

    RenderTexture CreateScreenTexture(int textureWidth, int textureHeight)
    {
        RenderTexture screenTexture = new RenderTexture(textureWidth, textureHeight, 24);
        screenTexture.enableRandomWrite = true;
        screenTexture.Create();
        return screenTexture;

    }
    RenderTexture CreateScreenTexture()
    {
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 24);
        screenTexture.enableRandomWrite = true;
        screenTexture.Create();
        return screenTexture;

    }

}