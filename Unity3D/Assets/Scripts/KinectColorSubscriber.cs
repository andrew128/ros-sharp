using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class KinectColorSubscriber : Subscriber<Messages.Sensor.CompressedImage>
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

        protected override void ReceiveMessage(Messages.Sensor.CompressedImage compressedImage)
        {
            imageData = compressedImage.data;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {

            pointCloudViewer.colorTexture.LoadImage(imageData);
            pointCloudViewer.colorTexture.Apply();
            isMessageReceived = false;
        }
    }
}
