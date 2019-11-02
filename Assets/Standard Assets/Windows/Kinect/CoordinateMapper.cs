using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.CoordinateMapper
    //
    public sealed partial class CoordinateMapper : INativeWrapper

    {
        // Events
        private static GCHandle
            _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<CoordinateMappingChangedEventArgs>>>
            Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks =
                new CollectionMap<RootSystem.IntPtr,
                    List<RootSystem.EventHandler<CoordinateMappingChangedEventArgs>>>();

        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal CoordinateMapper(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_CoordinateMapper_AddRefObject(ref _pNative);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~CoordinateMapper()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<CoordinateMapper>(_pNative);
            Windows_Kinect_CoordinateMapper_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }

        [MonoPInvokeCallback(typeof(_Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate))]
        private static void Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result,
            RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<CoordinateMappingChangedEventArgs>> callbackList = null;
            Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<CoordinateMapper>(pNative);
                var args = new CoordinateMappingChangedEventArgs(result);
                foreach (var func in callbackList)
                    EventPump.Instance.Enqueue(() =>
                    {
                        try
                        {
                            func(objThis, args);
                        }
                        catch
                        {
                        }
                    });
            }
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(
            RootSystem.IntPtr pNative, _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate eventCallback,
            bool unsubscribe);

        public event RootSystem.EventHandler<CoordinateMappingChangedEventArgs> CoordinateMappingChanged
        {
            add
            {
                EventPump.EnsureInitialized();

                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if (callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(
                            Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler);
                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle =
                            GCHandle.Alloc(del);
                        Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero) return;

                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if (callbackList.Count == 0)
                    {
                        Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative,
                            Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(
            RootSystem.IntPtr pNative, CameraSpacePoint cameraPoint);

        public DepthSpacePoint MapCameraPointToDepthSpace(CameraSpacePoint cameraPoint)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var objectPointer = Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(_pNative, cameraPoint);
            ExceptionHelper.CheckLastError();
            var obj = (DepthSpacePoint) Marshal.PtrToStructure(
                objectPointer, typeof(DepthSpacePoint));
            Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(
            RootSystem.IntPtr pNative, CameraSpacePoint cameraPoint);

        public ColorSpacePoint MapCameraPointToColorSpace(CameraSpacePoint cameraPoint)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var objectPointer = Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(_pNative, cameraPoint);
            ExceptionHelper.CheckLastError();
            var obj = (ColorSpacePoint) Marshal.PtrToStructure(
                objectPointer, typeof(ColorSpacePoint));
            Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(
            RootSystem.IntPtr pNative, DepthSpacePoint depthPoint, ushort depth);

        public CameraSpacePoint MapDepthPointToCameraSpace(DepthSpacePoint depthPoint,
            ushort depth)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var objectPointer = Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(_pNative, depthPoint, depth);
            ExceptionHelper.CheckLastError();
            var obj = (CameraSpacePoint) Marshal.PtrToStructure(
                objectPointer, typeof(CameraSpacePoint));
            Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(
            RootSystem.IntPtr pNative, DepthSpacePoint depthPoint, ushort depth);

        public ColorSpacePoint MapDepthPointToColorSpace(DepthSpacePoint depthPoint,
            ushort depth)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var objectPointer = Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(_pNative, depthPoint, depth);
            ExceptionHelper.CheckLastError();
            var obj = (ColorSpacePoint) Marshal.PtrToStructure(
                objectPointer, typeof(ColorSpacePoint));
            Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(
            RootSystem.IntPtr pNative, RootSystem.IntPtr cameraPoints, int cameraPointsSize,
            RootSystem.IntPtr depthPoints, int depthPointsSize);

        public void MapCameraPointsToDepthSpace(CameraSpacePoint[] cameraPoints,
            DepthSpacePoint[] depthPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var cameraPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(cameraPoints,
                    GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            var depthPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthPoints,
                    GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(_pNative, _cameraPoints, cameraPoints.Length,
                _depthPoints, depthPoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(
            RootSystem.IntPtr pNative, RootSystem.IntPtr cameraPoints, int cameraPointsSize,
            RootSystem.IntPtr colorPoints, int colorPointsSize);

        public void MapCameraPointsToColorSpace(CameraSpacePoint[] cameraPoints,
            ColorSpacePoint[] colorPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var cameraPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(cameraPoints,
                    GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            var colorPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(colorPoints,
                    GCHandleType.Pinned));
            var _colorPoints = colorPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(_pNative, _cameraPoints, cameraPoints.Length,
                _colorPoints, colorPoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(
            RootSystem.IntPtr pNative, RootSystem.IntPtr depthPoints, int depthPointsSize, RootSystem.IntPtr depths,
            int depthsSize, RootSystem.IntPtr cameraPoints, int cameraPointsSize);

        public void MapDepthPointsToCameraSpace(DepthSpacePoint[] depthPoints, ushort[] depths,
            CameraSpacePoint[] cameraPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthPoints,
                    GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            var depthsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depths,
                    GCHandleType.Pinned));
            var _depths = depthsSmartGCHandle.AddrOfPinnedObject();
            var cameraPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(cameraPoints,
                    GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(_pNative, _depthPoints, depthPoints.Length,
                _depths, depths.Length, _cameraPoints, cameraPoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthPoints, int depthPointsSize, RootSystem.IntPtr depths, int depthsSize,
            RootSystem.IntPtr colorPoints, int colorPointsSize);

        public void MapDepthPointsToColorSpace(DepthSpacePoint[] depthPoints, ushort[] depths,
            ColorSpacePoint[] colorPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthPoints,
                    GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            var depthsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depths,
                    GCHandleType.Pinned));
            var _depths = depthsSmartGCHandle.AddrOfPinnedObject();
            var colorPointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(colorPoints,
                    GCHandleType.Pinned));
            var _colorPoints = colorPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(_pNative, _depthPoints, depthPoints.Length,
                _depths, depths.Length, _colorPoints, colorPoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr cameraSpacePoints,
            int cameraSpacePointsSize);

        public void MapDepthFrameToCameraSpace(ushort[] depthFrameData,
            CameraSpacePoint[] cameraSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthFrameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthFrameData,
                    GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var cameraSpacePointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(cameraSpacePoints,
                    GCHandleType.Pinned));
            var _cameraSpacePoints = cameraSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(_pNative, _depthFrameData, depthFrameData.Length,
                _cameraSpacePoints, cameraSpacePoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr colorSpacePoints,
            int colorSpacePointsSize);

        public void MapDepthFrameToColorSpace(ushort[] depthFrameData,
            ColorSpacePoint[] colorSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthFrameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthFrameData,
                    GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var colorSpacePointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(colorSpacePoints,
                    GCHandleType.Pinned));
            var _colorSpacePoints = colorSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(_pNative, _depthFrameData, depthFrameData.Length,
                _colorSpacePoints, colorSpacePoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr depthSpacePoints,
            int depthSpacePointsSize);

        public void MapColorFrameToDepthSpace(ushort[] depthFrameData,
            DepthSpacePoint[] depthSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthFrameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthFrameData,
                    GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var depthSpacePointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthSpacePoints,
                    GCHandleType.Pinned));
            var _depthSpacePoints = depthSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(_pNative, _depthFrameData, depthFrameData.Length,
                _depthSpacePoints, depthSpacePoints.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr cameraSpacePoints,
            int cameraSpacePointsSize);

        public void MapColorFrameToCameraSpace(ushort[] depthFrameData,
            CameraSpacePoint[] cameraSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var depthFrameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(depthFrameData,
                    GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var cameraSpacePointsSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(cameraSpacePoints,
                    GCHandleType.Pinned));
            var _cameraSpacePoints = cameraSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(_pNative, _depthFrameData, depthFrameData.Length,
                _cameraSpacePoints, cameraSpacePoints.Length);
            ExceptionHelper.CheckLastError();
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative,
                                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, true);

                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);
    }
}