using System;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine;

namespace Helper
{
    internal class EventPump : MonoBehaviour
    {
        private static readonly object s_Lock = new object();
        private readonly Queue<Action> m_Queue = new Queue<Action>();

        public static EventPump Instance { get; private set; }

        public static void EnsureInitialized()
        {
            try
            {
                if (Instance == null)
                    lock (s_Lock)
                    {
                        if (Instance == null)
                        {
                            var parent = new GameObject("Kinect Desktop Event Pump");
                            Instance = parent.AddComponent<EventPump>();
                            DontDestroyOnLoad(parent);
                        }
                    }
            }
            catch
            {
                Debug.LogError("Events must be registered on the main thread.");
            }
        }

        private void Update()
        {
            lock (m_Queue)
            {
                while (m_Queue.Count > 0)
                {
                    var action = m_Queue.Dequeue();
                    try
                    {
                        action.Invoke();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void OnApplicationQuit()
        {
            var sensor = KinectSensor.GetDefault();
            if (sensor != null && sensor.IsOpen) sensor.Close();

            NativeObjectCache.Flush();
        }

        public void Enqueue(Action action)
        {
            lock (m_Queue)
            {
                m_Queue.Enqueue(action);
            }
        }
    }
}