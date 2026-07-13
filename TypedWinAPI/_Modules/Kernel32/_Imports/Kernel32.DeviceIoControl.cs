using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

unsafe partial class Kernel32
{
    #region Common

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 DeviceIoControl(
        HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped);

    #region DeviceIoControl Without IN OUT

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(HDevice hDevice, DeviceIoControlCode dwIoControlCode)
        => DeviceIoControl(hDevice, dwIoControlCode, null, 0, null, 0, out _, null);

    #endregion

    #region DeviceIoControl With generic fixed IN|OUT

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl<TIn, TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        in TIn lpIn, out TOut lpOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
        where TIn : unmanaged
        where TOut : unmanaged
    {
        fixed (TIn* inPtr = &lpIn)
        fixed (TOut* outPtr = &lpOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)sizeof(TIn),
                outPtr, (uint)sizeof(TOut),
                out lpBytesReturned, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlIN<TIn>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        in TIn lpIn, void* lpOverlapped = null)
        where TIn : unmanaged
    {
        fixed (TIn* inPtr = &lpIn)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)sizeof(TIn),
                null, 0,
                out _, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlOUT<TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        out TOut lpOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
        where TOut : unmanaged
    {
        fixed (TOut* outPtr = &lpOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                null, 0,
                outPtr, (uint)sizeof(TOut),
                out lpBytesReturned, lpOverlapped);
    }

    #endregion

    #region DeviceIoControl With generic VariableRangedArray IN|OUT as Spans

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl<TIn, TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        ReadOnlySpan<byte> vraIn, Span<byte> vraOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
    where TIn : unmanaged
    where TOut : unmanaged
    {
#if DEBUG
        if (vraIn.Length < sizeof(TIn))
            throw new ArgumentOutOfRangeException(nameof(vraIn));
        if (vraOut.Length < sizeof(TOut))
            throw new ArgumentOutOfRangeException(nameof(vraOut));
#endif
        fixed (byte* inPtr = vraIn)
        fixed (byte* outPtr = vraOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)vraIn.Length,
                outPtr, (uint)vraOut.Length,
                out lpBytesReturned, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlIN<TIn>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        ReadOnlySpan<byte> vraIn, void* lpOverlapped = null)
        where TIn : unmanaged
    {
#if DEBUG
        if (vraIn.Length < sizeof(TIn))
            throw new ArgumentOutOfRangeException(nameof(vraIn));
#endif
        fixed (byte* inPtr = vraIn)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)vraIn.Length,
                null, 0,
                out _, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlOUT<TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        Span<byte> vraOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
        where TOut : unmanaged
    {
#if DEBUG
        if (vraOut.Length < sizeof(TOut))
            throw new ArgumentOutOfRangeException(nameof(vraOut));
#endif
        fixed (byte* outPtr = vraOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                null, 0,
                outPtr, (uint)vraOut.Length,
                out lpBytesReturned, lpOverlapped);
    }

    #endregion

    #region DeviceIoControl With VariableRangedArray IN|OUT as Spans

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        ReadOnlySpan<byte> vraIn, Span<byte> vraOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
    {
        fixed (byte* inPtr = vraIn)
        fixed (byte* outPtr = vraOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)vraIn.Length,
                outPtr, (uint)vraOut.Length,
                out lpBytesReturned, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlIN(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        ReadOnlySpan<byte> vraIn, void* lpOverlapped = null)
    {
        fixed (byte* inPtr = vraIn)
            return DeviceIoControl(hDevice, dwIoControlCode,
                inPtr, (uint)vraIn.Length,
                null, 0,
                out _, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlOUT(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        Span<byte> vraOut,
        out uint lpBytesReturned, void* lpOverlapped = null)
    {
        fixed (byte* outPtr = vraOut)
            return DeviceIoControl(hDevice, dwIoControlCode,
                null, 0,
                outPtr, (uint)vraOut.Length,
                out lpBytesReturned, lpOverlapped);
    }

    #endregion

    #region DeviceIoControl With generic VariableRangedArray IN|OUT as Pointers

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl<TIn, TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* inPtr, uint inLen, void* outPtr, uint outLen,
        out uint lpBytesReturned, void* lpOverlapped = null)
        where TIn : unmanaged
        where TOut : unmanaged
    {
#if DEBUG
        ArgumentOutOfRangeException.ThrowIfLessThan(inLen, (uint)sizeof(TIn), nameof(inLen));
        ArgumentOutOfRangeException.ThrowIfLessThan(outLen, (uint)sizeof(TOut), nameof(outLen));
#endif
        return DeviceIoControl(hDevice, dwIoControlCode,
            inPtr, inLen,
            outPtr, outLen,
            out lpBytesReturned, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlIN<TIn>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* inPtr, uint inLen, void* lpOverlapped = null)
        where TIn : unmanaged
    {
#if DEBUG
        ArgumentOutOfRangeException.ThrowIfLessThan(inLen, (uint)sizeof(TIn), nameof(inLen));
#endif
        return DeviceIoControl(hDevice, dwIoControlCode,
            inPtr, inLen,
            null, 0,
            out _, lpOverlapped);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlOUT<TOut>(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* outPtr, uint outLen,
        out uint lpBytesReturned, void* lpOverlapped = null)
        where TOut : unmanaged
    {
#if DEBUG
        ArgumentOutOfRangeException.ThrowIfLessThan(outLen, (uint)sizeof(TOut), nameof(outLen));
#endif
        return DeviceIoControl(hDevice, dwIoControlCode,
            null, 0,
            outPtr, outLen,
            out lpBytesReturned, lpOverlapped);
    }

    #endregion

    #region DeviceIoControl With VariableRangedArray IN|OUT as Pointers

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlIN(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* inPtr, uint inLen, void* lpOverlapped = null)
        => DeviceIoControl(hDevice, dwIoControlCode,
            inPtr, inLen,
            null, 0,
            out _, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControlOUT(HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* outPtr, uint outLen,
        out uint lpBytesReturned, void* lpOverlapped = null)
        => DeviceIoControl(hDevice, dwIoControlCode,
            null, 0,
            outPtr, outLen,
            out lpBytesReturned, lpOverlapped);

    #endregion

    #region DeviceIoControl With enums instead of DeviceIoControlCode.

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, DiskControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, FsControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, MountMgrControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, StorageControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, VideoControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);

    #endregion

    #endregion

    #region DiskControlCode

    #region DriveGeometry & Ex
    /// <summary>
    /// Retrieves information about the physical disk's geometry: type, number of cylinders, tracks per cylinder, sectors per track, and bytes per sector.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometry(HDevice hDevice, out DiskGeometry geometry)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveGeometry, out geometry, out _);

    /// <summary>
    /// Retrieves extended information about the physical disk's geometry: type, number of cylinders, tracks per cylinder, sectors per track, bytes per sector, and disk size.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometryEx(HDevice hDevice, out DiskGeometryEx geometry)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveGeometryEx, out geometry, out _);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometryEx(HDevice hDevice, Span<byte> geometry, out uint written)
        => DeviceIoControlOUT<DiskGeometryEx>(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveGeometryEx, geometry, out written);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometryEx(HDevice hDevice, void* geometryPtr, uint vraLen, out uint written)
        => DeviceIoControlOUT<DiskGeometryEx>(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveGeometryEx, geometryPtr, vraLen, out written);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometryEx(HDevice hDevice, Span<byte> geometryBuffer, out uint written, out DiskGeometryEx geometryOut)
    {
        Bool4 result = DiskGetDriveGeometryEx(hDevice, geometryBuffer, out written);
        if (result && written >= sizeof(DiskGeometryEx))
            geometryOut = Unsafe.As<byte, DiskGeometryEx>(ref MemoryMarshal.GetReference(geometryBuffer));
        else
            geometryOut = Unsafe.NullRef<DiskGeometryEx>();
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveGeometryEx(HDevice hDevice, void* geometryPtr, uint vraLen, out uint written, out DiskGeometryEx geometryOut)
    {
        Bool4 result = DiskGetDriveGeometryEx(hDevice, geometryPtr, vraLen, out written);
        if (result && written >= sizeof(DiskGeometryEx))
            geometryOut = *(DiskGeometryEx*)geometryPtr;
        else
            geometryOut = Unsafe.NullRef<DiskGeometryEx>();
        return result;
    }

    #endregion

    #region PartitionInfo & Ex

    /// <summary>
    /// Retrieves partition information for the specified partition (Legacy MBR).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetPartitionInfo(HDevice hDevice, out PartitionInformation info)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetPartitionInfo, out info, out _);
    /// <summary>
    /// Retrieves extended information about the disk partition (GPT/MBR).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetPartitionInfoEx(HDevice hDevice, out PartitionInformationEx info)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetPartitionInfoEx, out info, out _);
    /// <summary>
    /// Sets partition information for the specified disk partition (GPT/MBR).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskSetPartitionInfoEx(HDevice hDevice, in PartitionInformationEx info)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.SetPartitionInfoEx, in info);

    #endregion

    #region DriveLayout

    /// <summary>
    /// Returns information about the number of partitions on a disk and the features of each partition.
    /// </summary>
    /// <remarks>Note: For disks with many partitions, this might require a custom buffer. This wrapper assumes standard layout.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveLayoutEx(HDevice hDevice, out DriveLayoutInformationEx layout)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveLayoutEx, out layout, out _);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveLayoutEx(HDevice hDevice, Span<byte> layout, out uint written)
        => DeviceIoControlOUT<DriveLayoutInformationEx>(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveLayoutEx, layout, out written);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveLayoutEx(HDevice hDevice, void* layoutPtr, uint vraLen, out uint written)
        => DeviceIoControlOUT<DriveLayoutInformationEx>(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetDriveLayoutEx, layoutPtr, vraLen, out written);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveLayoutEx(HDevice hDevice, Span<byte> layoutBuffer, out uint written, out DriveLayoutInformationEx layoutOut)
    {
        Bool4 result = DiskGetDriveLayoutEx(hDevice, layoutBuffer, out written);
        if (result && written >= sizeof(DriveLayoutInformationEx))
            layoutOut = Unsafe.As<byte, DriveLayoutInformationEx>(ref MemoryMarshal.GetReference(layoutBuffer));
        else
            layoutOut = Unsafe.NullRef<DriveLayoutInformationEx>();
        return result;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetDriveLayoutEx(HDevice hDevice, byte* layoutPtr, uint vraLen, out uint written, out DriveLayoutInformationEx layoutOut)
    {
        Bool4 result = DiskGetDriveLayoutEx(hDevice, layoutPtr, vraLen, out written);
        if (result && written >= sizeof(DriveLayoutInformationEx))
            layoutOut = *(DriveLayoutInformationEx*)layoutPtr;
        else
            layoutOut = Unsafe.NullRef<DriveLayoutInformationEx>();
        return result;
    }

    #endregion

    #region Other

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskGetLengthInfo(HDevice hDevice, out long length)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.GetLengthInfo, out length, out _);
    /// <summary>
    /// Invalidates the cached partition table and re-enumerates the device.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskUpdateProperties(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.UpdateProperties);

    /// <summary>
    /// Determines whether the specified disk is writable.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskIsWritable(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.IsWritable);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DiskFormatTracks(HDevice hDevice, in DiskFormatParameters parameters)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)DiskControlCode.FormatTracks, in parameters);

    #endregion

    #endregion

    #region FsControlCode

    #region Volume State

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsLockVolume(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.LockVolume);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsUnlockVolume(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.UnlockVolume);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsDismountVolume(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.DismountVolume);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsIsVolumeMounted(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.IsVolumeMounted);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsIsVolumeDirty(HDevice hDevice, out VolumeDirtyFlags isDirty)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)FsControlCode.IsVolumeDirty, out isDirty, out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsAllowExtendedDasdIo(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.AllowExtendedDasdIo);

    #endregion

    #region File & Cluster Operations (VRA Heavily Used)

    // GetRetrievalPointers takes a STARTING_VCN_INPUT_BUFFER and returns a variable-length RETRIEVAL_POINTERS_BUFFER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsGetRetrievalPointers(HDevice hDevice, in long vcnIn, Span<byte> retrievalPointersOut, out uint written)
    {
        fixed (long* inPtr = &vcnIn)
        fixed (byte* outPtr = retrievalPointersOut)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.GetRetrievalPointers,
                inPtr, sizeof(long),
                outPtr, (uint)retrievalPointersOut.Length,
                out written, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsGetRetrievalPointers(HDevice hDevice, in long vcnIn, void* retrievalPointersPtr, uint vraLen, out uint written)
    {
        fixed (long* inPtr = &vcnIn)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.GetRetrievalPointers,
                inPtr, sizeof(long),
                retrievalPointersPtr, vraLen,
                out written, null);
    }

    // GetVolumeBitmap returns a STARTING_LCN_INPUT_BUFFER (IN) and VOLUME_BITMAP_BUFFER (OUT - VRA)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsGetVolumeBitmap(HDevice hDevice, in long lcnIn, void* bitmapPtr, uint vraLen, out uint written)
    {
        fixed (long* inPtr = &lcnIn)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)FsControlCode.GetVolumeBitmap,
                inPtr, sizeof(long),
                bitmapPtr, vraLen,
                out written, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsMoveFile(HDevice hDevice, in FsMoveFileParams moveParams)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)FsControlCode.MoveFile, in moveParams);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsSetZeroData(HDevice hDevice, in FsFileZeroDataInformation zeroData)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)FsControlCode.SetZeroData, in zeroData);

    #endregion

    #region Reparse Points (Symlinks/Junctions)

    // Reparse points are variable length (REPARSE_DATA_BUFFER)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsGetReparsePoint(HDevice hDevice, void* reparseBufferPtr, uint vraLen, out uint written)
        => DeviceIoControlOUT<FsReparseDataBuffer>(hDevice, (DeviceIoControlCode)(uint)FsControlCode.GetReparsePoint, reparseBufferPtr, vraLen, out written);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsSetReparsePoint(HDevice hDevice, void* reparseBufferPtr, uint vraLen)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)FsControlCode.SetReparsePoint, reparseBufferPtr, vraLen);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 FsDeleteReparsePoint(HDevice hDevice, void* reparseBufferPtr, uint vraLen)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)FsControlCode.DeleteReparsePoint, reparseBufferPtr, vraLen);

    #endregion

    #endregion

    #region MountMgrControlCode

    // QueryPoints returns a MOUNTMGR_MOUNT_POINTS struct which is a VRA containing multiple MOUNTMGR_MOUNT_POINT
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 MountMgrQueryPoints(HDevice hDevice, in MountMgrMountPoint inputPoint, void* pointsBufferPtr, uint vraLen, out uint written)
    {
        fixed (MountMgrMountPoint* inPtr = &inputPoint)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)MountMgrControlCode.QueryPoints,
                inPtr, (uint)sizeof(MountMgrMountPoint),
                pointsBufferPtr, vraLen,
                out written, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 MountMgrQueryAutoMount(HDevice hDevice, out uint autoMountState)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)MountMgrControlCode.QueryAutoMount, out autoMountState, out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 MountMgrSetAutoMount(HDevice hDevice, in uint autoMountState)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)MountMgrControlCode.SetAutoMount, in autoMountState);

    #endregion

    #region StorageControlCode

    #region Device Properties & Info

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageGetDeviceNumber(HDevice hDevice, out StorageDeviceNumber deviceNumber)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.GetDeviceNumber, out deviceNumber, out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageGetHotplugInfo(HDevice hDevice, out StorageHotplugInfo hotplugInfo)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.GetHotplugInfo, out hotplugInfo, out _);

    // QueryProperty takes a STORAGE_PROPERTY_QUERY and returns a VRA (STORAGE_DEVICE_DESCRIPTOR, STORAGE_ADAPTER_DESCRIPTOR, etc.)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageQueryProperty(HDevice hDevice, in StoragePropertyQuery query, void* descriptorPtr, uint vraLen, out uint written)
    {
        fixed (StoragePropertyQuery* inPtr = &query)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.QueryProperty,
                inPtr, (uint)sizeof(StoragePropertyQuery),
                descriptorPtr, vraLen,
                out written, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageQueryProperty(HDevice hDevice, in StoragePropertyQuery query, Span<byte> descriptorBuffer, out uint written)
    {
        fixed (StoragePropertyQuery* inPtr = &query)
        fixed (byte* outPtr = descriptorBuffer)
            return DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.QueryProperty,
                inPtr, (uint)sizeof(StoragePropertyQuery),
                outPtr, (uint)descriptorBuffer.Length,
                out written, null);
    }

    #endregion

    #region Media Operations

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageCheckVerify(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.CheckVerify);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageEjectMedia(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.EjectMedia);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageLoadMedia(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.LoadMedia);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageReserve(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.Reserve);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 StorageRelease(HDevice hDevice)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)StorageControlCode.Release);

    #endregion

    #endregion

    #region VideoControlCode

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 VideoSetDisplayMode(HDevice hDevice, VideoDisplayMode requestedMode)
        => DeviceIoControlIN(hDevice, (DeviceIoControlCode)(uint)VideoControlCode.SetDisplayMode, requestedMode);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 VideoQueryDisplayParameters(HDevice hDevice, out VideoModeInformation modeInfo)
        => DeviceIoControlOUT(hDevice, (DeviceIoControlCode)(uint)VideoControlCode.QueryDisplayParameters, out modeInfo, out _);

    #endregion
}