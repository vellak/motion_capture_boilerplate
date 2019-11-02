using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameEdges
    //
    [RootSystem.FlagsAttribute]
    public enum FrameEdges : uint
    {
        None = 0,
        Right = 1,
        Left = 2,
        Top = 4,
        Bottom = 8
    }
}