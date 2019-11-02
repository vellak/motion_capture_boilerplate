using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameSourceTypes
    //
    [RootSystem.FlagsAttribute]
    public enum FrameSourceTypes : uint
    {
        None = 0,
        Color = 1,
        Infrared = 2,
        LongExposureInfrared = 4,
        Depth = 8,
        BodyIndex = 16,
        Body = 32,
        Audio = 64
    }
}