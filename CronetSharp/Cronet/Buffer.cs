﻿using System;
using System.Runtime.InteropServices;
using CronetSharp.Cronet.Marshalers;
using CronetSharp.CronetAsm;

namespace CronetSharp.Cronet
{
    internal static class Buffer
    {
        [DllImport(CronetLoader.Dll)]
        internal static extern IntPtr Cronet_Buffer_Create();
        
        [DllImport(CronetLoader.Dll)]
        internal static extern void Cronet_Buffer_Destroy(IntPtr bufferPtr);
        
        [DllImport(CronetLoader.Dll)]
        internal static extern void Cronet_Buffer_InitWithDataAndCallback(IntPtr bufferPtr, IntPtr rawDataPtr, ulong size, IntPtr bufferCallbackPtr);
        
        [DllImport(CronetLoader.Dll)]
        internal static extern void Cronet_Buffer_InitWithAlloc(IntPtr bufferPtr, ulong size);
        
        [DllImport(CronetLoader.Dll)]
        internal static extern ulong Cronet_Buffer_GetSize(IntPtr bufferPtr);
        
        [DllImport(CronetLoader.Dll)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringMarshaler))]
        internal static extern string Cronet_Buffer_GetData(IntPtr bufferPtr);
    }
}