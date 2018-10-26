/**
 * MIT License
 * 
 * Copyright (c) 2018 Merlin
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BlitComponent : MonoBehaviour
{
    public RenderTexture sourceTexture = null;
    public RenderTexture targetTexture = null;

    private Material blitMaterial = null;
    private MeshRenderer meshRenderer = null;

    private int toWorldMatrixParam = -1;
    private int fromWorldMatrixParam = -1;
    private int worldPositionParam = -1;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        toWorldMatrixParam = Shader.PropertyToID("_BlitToWorldMatrix");
        fromWorldMatrixParam = Shader.PropertyToID("_BlitFromWorldMatrix");
        worldPositionParam = Shader.PropertyToID("_BlitWorldPosition");
    }

    public void RunBlit()
    {
        if (meshRenderer != null) // Check for null just in case, though this should never be null under normal circumstances
        {
            // Allow people to animate the material reference
            blitMaterial = meshRenderer.sharedMaterial;

            if (targetTexture != null && blitMaterial != null)
            {
                Transform componentTransform = transform;

                blitMaterial.SetMatrix(toWorldMatrixParam, componentTransform.localToWorldMatrix);
                blitMaterial.SetMatrix(fromWorldMatrixParam, componentTransform.worldToLocalMatrix);
                blitMaterial.SetVector(worldPositionParam, componentTransform.position);

                Graphics.Blit(sourceTexture, targetTexture, blitMaterial);
            }
        }
    }
}