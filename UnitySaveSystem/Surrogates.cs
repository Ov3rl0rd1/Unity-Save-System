using UnityEngine;
using System.Runtime.Serialization;

namespace SaveSystem
{
    #region Vector3Serializer
    class Vector3Serializer : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector3 target = (Vector3)obj;
            info.AddValue("x", target.x);
            info.AddValue("y", target.y);
            info.AddValue("z", target.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector3 target = (Vector3)obj;
            target.x = (float)info.GetValue("x", typeof(float));
            target.y = (float)info.GetValue("y", typeof(float));
            target.z = (float)info.GetValue("z", typeof(float));
            return target;
        }
    }
    #endregion

    #region Vector2Serializer
    class Vector2Serializer : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector2 target = (Vector2)obj;
            info.AddValue("x", target.x);
            info.AddValue("y", target.y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector2 target = (Vector2)obj;
            target.x = (float)info.GetValue("x", typeof(float));
            target.y = (float)info.GetValue("y", typeof(float));
            return target;
        }
    }
    #endregion

    #region QuaternionSerializer
    class QuaternionSerializer : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Quaternion target = (Quaternion)obj;
            info.AddValue("x", target.x);
            info.AddValue("y", target.y);
            info.AddValue("z", target.z);
            info.AddValue("w", target.w);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Quaternion target = (Quaternion)obj;
            target.x = (float)info.GetValue("x", typeof(float));
            target.y = (float)info.GetValue("y", typeof(float));
            target.z = (float)info.GetValue("z", typeof(float));
            target.w = (float)info.GetValue("w", typeof(float));
            return target;
        }
    }
    #endregion
}
