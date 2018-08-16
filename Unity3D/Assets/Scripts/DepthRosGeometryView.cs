using UnityEngine;
using System.Collections;
using System;

public class DepthRosGeometryView : MonoBehaviour {

    //private WebsocketClient wsc;
    //string depthTopic;
    //string colorTopic;
    //int framerate = 100;
    //public string compression = "none"; //"png" is the other option, haven't tried it yet though
    //string depthMessage;
    //string colorMessage;

    public Material Material;
    public Texture2D depthTexture;
    public Texture2D colorTexture;

    int width = 512;
    int height = 424;


    Matrix4x4 m;

    // Use this for initialization
    void Start() {
        // Create a texture for the depth image and color image
        depthTexture = new Texture2D(width, height, TextureFormat.R16, false);
        colorTexture = new Texture2D(2, 2);
    }


    void OnRenderObject() {

        Material.SetTexture("_MainTex", depthTexture);
        Material.SetTexture("_ColorTex", colorTexture);
        Material.SetPass(0);

        m = Matrix4x4.TRS(this.transform.position, this.transform.rotation, this.transform.localScale);
        Material.SetMatrix("transformationMatrix", m);

        Graphics.DrawProcedural(MeshTopology.Points, width * height, 1);
    }
}