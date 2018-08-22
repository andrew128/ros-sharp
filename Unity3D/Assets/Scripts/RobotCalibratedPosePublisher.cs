using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient {

    public class RobotCalibratedPosePublisher : PoseStampedPublisher {

        private Messages.Geometry.PoseStamped message;
        public Transform robot;
        bool InDebounce = true;

        private void FixedUpdate() {
            return;
        }

        new void UpdateMessage() {
            if (InDebounce) {
                return;
            }
            message.header.Update();

            message.pose.position = GetGeometryPoint(robot.InverseTransformPoint(PublishedTransform.position).Unity2Ros());
            message.pose.orientation = GetGeometryQuaternion((Quaternion.Inverse(robot.rotation) * PublishedTransform.rotation).Unity2Ros());

            Publish(message);
            InDebounce = true;
            Debounce();
        }

        IEnumerator Debounce() {
            yield return new WaitForSeconds(.5f);
            InDebounce = false;
            
        }
    }
}