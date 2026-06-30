using UnityEngine;
using TMPro;

public class LetterJump : MonoBehaviour
{
    public float alturaSalto = 10f;
    public float velocidad = 3f;
    public float esperaEntreLetras = 0.15f;

    private TMP_Text texto;

    void Awake()
    {
        texto = GetComponent<TMP_Text>();
    }

    void Update()
    {
        texto.ForceMeshUpdate();

        TMP_TextInfo textInfo = texto.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            float offsetY = Mathf.Sin(Time.time * velocidad + i * esperaEntreLetras)
                            * alturaSalto;

            Vector3 offset = new Vector3(0, offsetY, 0);

            vertices[vertexIndex + 0] += offset;
            vertices[vertexIndex + 1] += offset;
            vertices[vertexIndex + 2] += offset;
            vertices[vertexIndex + 3] += offset;
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            texto.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}