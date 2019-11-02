using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.Body
    //
    public sealed partial class Body : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal Body(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_Body_AddRefObject(ref _pNative);
        }

        public Dictionary<Activity, DetectionResult>
            Activities
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var outCollectionSize = Windows_Kinect_Body_get_Activities_Length(_pNative);
                var outKeys = new Activity[outCollectionSize];
                var outValues = new DetectionResult[outCollectionSize];
                var managedDictionary =
                    new Dictionary<Activity,
                        DetectionResult>();

                outCollectionSize = Windows_Kinect_Body_get_Activities(_pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++) managedDictionary.Add(outKeys[i], outValues[i]);

                return managedDictionary;
            }
        }

        public Dictionary<Appearance, DetectionResult>
            Appearance
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var outCollectionSize = Windows_Kinect_Body_get_Appearance_Length(_pNative);
                var outKeys = new Appearance[outCollectionSize];
                var outValues = new DetectionResult[outCollectionSize];
                var managedDictionary =
                    new Dictionary<Appearance,
                        DetectionResult>();

                outCollectionSize = Windows_Kinect_Body_get_Appearance(_pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++) managedDictionary.Add(outKeys[i], outValues[i]);

                return managedDictionary;
            }
        }

        public FrameEdges ClippedEdges
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_ClippedEdges(_pNative);
            }
        }

        public DetectionResult Engaged
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_Engaged(_pNative);
            }
        }

        public Dictionary<Expression, DetectionResult>
            Expressions
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var outCollectionSize = Windows_Kinect_Body_get_Expressions_Length(_pNative);
                var outKeys = new Expression[outCollectionSize];
                var outValues = new DetectionResult[outCollectionSize];
                var managedDictionary =
                    new Dictionary<Expression,
                        DetectionResult>();

                outCollectionSize =
                    Windows_Kinect_Body_get_Expressions(_pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++) managedDictionary.Add(outKeys[i], outValues[i]);

                return managedDictionary;
            }
        }

        public TrackingConfidence HandLeftConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_HandLeftConfidence(_pNative);
            }
        }

        public HandState HandLeftState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_HandLeftState(_pNative);
            }
        }

        public TrackingConfidence HandRightConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_HandRightConfidence(_pNative);
            }
        }

        public HandState HandRightState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_HandRightState(_pNative);
            }
        }

        public bool IsRestricted
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_IsRestricted(_pNative);
            }
        }

        public bool IsTracked
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_IsTracked(_pNative);
            }
        }

        public Dictionary<JointType, JointOrientation>
            JointOrientations
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var outCollectionSize = Windows_Kinect_Body_get_JointOrientations_Length(_pNative);
                var outKeys = new JointType[outCollectionSize];
                var outValues = new JointOrientation[outCollectionSize];
                var managedDictionary =
                    new Dictionary<JointType,
                        JointOrientation>();

                outCollectionSize =
                    Windows_Kinect_Body_get_JointOrientations(_pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++) managedDictionary.Add(outKeys[i], outValues[i]);

                return managedDictionary;
            }
        }

        public Dictionary<JointType, Joint> Joints
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var outCollectionSize = Windows_Kinect_Body_get_Joints_Length(_pNative);
                var outKeys = new JointType[outCollectionSize];
                var outValues = new Joint[outCollectionSize];
                var managedDictionary =
                    new Dictionary<JointType, Joint>();

                outCollectionSize = Windows_Kinect_Body_get_Joints(_pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++) managedDictionary.Add(outKeys[i], outValues[i]);

                return managedDictionary;
            }
        }

        public TrackingState LeanTrackingState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_LeanTrackingState(_pNative);
            }
        }

        public ulong TrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                return Windows_Kinect_Body_get_TrackingId(_pNative);
            }
        }

        public static int JointCount => Windows_Kinect_Body_get_JointCount();

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~Body()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_Body_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_Body_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<Body>(_pNative);
            Windows_Kinect_Body_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Activities(RootSystem.IntPtr pNative,
            [Out] Activity[] outKeys, [Out] DetectionResult[] outValues, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Activities_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Appearance(RootSystem.IntPtr pNative,
            [Out] Appearance[] outKeys, [Out] DetectionResult[] outValues, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Appearance_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern FrameEdges Windows_Kinect_Body_get_ClippedEdges(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern DetectionResult Windows_Kinect_Body_get_Engaged(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Expressions(RootSystem.IntPtr pNative,
            [Out] Expression[] outKeys, [Out] DetectionResult[] outValues, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Expressions_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern TrackingConfidence Windows_Kinect_Body_get_HandLeftConfidence(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern HandState Windows_Kinect_Body_get_HandLeftState(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern TrackingConfidence Windows_Kinect_Body_get_HandRightConfidence(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern HandState
            Windows_Kinect_Body_get_HandRightState(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Windows_Kinect_Body_get_IsRestricted(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Windows_Kinect_Body_get_IsTracked(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_JointOrientations(RootSystem.IntPtr pNative,
            [Out] JointType[] outKeys, [Out] JointOrientation[] outValues, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_JointOrientations_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Joints(RootSystem.IntPtr pNative,
            [Out] JointType[] outKeys, [Out] Joint[] outValues, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_Joints_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern TrackingState Windows_Kinect_Body_get_LeanTrackingState(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern ulong Windows_Kinect_Body_get_TrackingId(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_Body_get_JointCount();


        // Public Methods
        private void __EventCleanup()
        {
        }
    }
}