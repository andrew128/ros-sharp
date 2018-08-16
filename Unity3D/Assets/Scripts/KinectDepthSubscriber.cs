using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class KinectDepthSubscriber : Subscriber<Messages.Sensor.Image>
    {

        private byte[] imageData;
        private bool isMessageReceived;

        public DepthRosGeometryView pointCloudViewer;

        protected override void Start()
        {
            base.Start();
        }
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(Messages.Sensor.Image image)
        {
            imageData = image.data;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {

            pointCloudViewer.depthTexture.LoadRawTextureData(imageData);
            pointCloudViewer.depthTexture.Apply();
            isMessageReceived = false;
        }
    }
}