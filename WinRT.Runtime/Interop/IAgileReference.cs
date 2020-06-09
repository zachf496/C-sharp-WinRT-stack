﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WinRT.Interop
{
    [WindowsRuntimeType]
    [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
    internal interface IAgileReference
    {
        IObjectReference Resolve(Guid riid);
    }

    [WindowsRuntimeType]
    [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
    public interface IAgileObject
    {
    }
}

namespace ABI.WinRT.Interop
{
    using global::WinRT;
    using WinRT.Interop;

    [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
    internal class IAgileReference : global::WinRT.Interop.IAgileReference
    {
        [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
        public struct Vftbl
        {
            public delegate int _Resolve(IntPtr thisPtr, ref Guid riid, out IntPtr objectReference);

            public global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;
            public _Resolve Resolve;

            public static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;

            static Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
                    Resolve = Do_Abi_Resolve
                };
                AbiToProjectionVftablePtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vftbl>());
                Marshal.StructureToPtr(AbiToProjectionVftable, AbiToProjectionVftablePtr, false);
            }

            private static int Do_Abi_Resolve(IntPtr thisPtr, ref Guid riid, out IntPtr objectReference)
            {
                IObjectReference _objectReference = default;

                objectReference = default;

                try
                {
                    _objectReference = global::WinRT.ComWrappersSupport.FindObject<global::WinRT.Interop.IAgileReference>(thisPtr).Resolve(riid);
                    objectReference = _objectReference?.GetRef() ?? IntPtr.Zero;
                }
                catch (Exception __exception__)
                {
                    return __exception__.HResult;
                }
                return 0;
            }
        }

        public static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IAgileReference(IObjectReference obj) => (obj != null) ? new IAgileReference(obj) : null;
        public static implicit operator IAgileReference(ObjectReference<Vftbl> obj) => (obj != null) ? new IAgileReference(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();

        public IAgileReference(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        public IAgileReference(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public IObjectReference Resolve(Guid riid)
        {
            ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.Resolve(ThisPtr, ref riid, out IntPtr ptr));
            try
            {
                return ComWrappersSupport.GetObjectReferenceForInterface(ptr);
            }
            finally
            {
                MarshalInspectable.DisposeAbi(ptr);
            }
        }
    }

    [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
    public class IAgileObject : global::WinRT.Interop.IAgileObject
    {
        [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
        public struct Vftbl
        {
            public global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;

            public static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;

            static Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
                };
                AbiToProjectionVftablePtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vftbl>());
                Marshal.StructureToPtr(AbiToProjectionVftable, AbiToProjectionVftablePtr, false);
            }
        }

        public static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IAgileObject(IObjectReference obj) => (obj != null) ? new IAgileObject(obj) : null;
        public static implicit operator IAgileObject(ObjectReference<Vftbl> obj) => (obj != null) ? new IAgileObject(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();

        public IAgileObject(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        public IAgileObject(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }
    }
}
