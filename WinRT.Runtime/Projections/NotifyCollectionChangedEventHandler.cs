﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using WinRT;
using WinRT.Interop;

namespace ABI.System.Collections.Specialized
{

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    [Guid("CA10B37C-F382-4591-8557-5E24965279B0")]
    public static class NotifyCollectionChangedEventHandler
    {
        private unsafe delegate int Abi_Invoke(IntPtr thisPtr, IntPtr sender, IntPtr e);

        private static readonly global::WinRT.Interop.IDelegateVftbl AbiToProjectionVftable;
        public static readonly IntPtr AbiToProjectionVftablePtr;

        static NotifyCollectionChangedEventHandler()
        {
            AbiInvokeDelegate = new Abi_Invoke(Do_Abi_Invoke);
            AbiToProjectionVftable = new global::WinRT.Interop.IDelegateVftbl
            {
                IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
                Invoke = Marshal.GetFunctionPointerForDelegate(AbiInvokeDelegate)
            };
            var nativeVftbl = ComWrappersSupport.AllocateVtableMemory(typeof(NotifyCollectionChangedEventHandler), Marshal.SizeOf<global::WinRT.Interop.IDelegateVftbl>());
            Marshal.StructureToPtr(AbiToProjectionVftable, nativeVftbl, false);
            AbiToProjectionVftablePtr = nativeVftbl;
        }

        public static global::System.Delegate AbiInvokeDelegate { get; }

        public static unsafe IObjectReference CreateMarshaler(global::System.Collections.Specialized.NotifyCollectionChangedEventHandler managedDelegate) => ComWrappersSupport.CreateCCWForObject(managedDelegate).As<global::WinRT.Interop.IDelegateVftbl>(GuidGenerator.GetIID(typeof(NotifyCollectionChangedEventHandler)));

        public static IntPtr GetAbi(IObjectReference value) => MarshalInterfaceHelper<global::System.Collections.Specialized.NotifyCollectionChangedEventHandler>.GetAbi(value);

        public static unsafe global::System.Collections.Specialized.NotifyCollectionChangedEventHandler FromAbi(IntPtr nativeDelegate)
        {
            var abiDelegate = ObjectReference<IDelegateVftbl>.FromAbi(nativeDelegate);
            return (global::System.Collections.Specialized.NotifyCollectionChangedEventHandler)ComWrappersSupport.TryRegisterObjectForInterface(new global::System.Collections.Specialized.NotifyCollectionChangedEventHandler(new NativeDelegateWrapper(abiDelegate).Invoke), nativeDelegate);
        }

        [global::WinRT.ObjectReferenceWrapper(nameof(_nativeDelegate))]
        private class NativeDelegateWrapper
        {
            private readonly ObjectReference<global::WinRT.Interop.IDelegateVftbl> _nativeDelegate;

            public NativeDelegateWrapper(ObjectReference<global::WinRT.Interop.IDelegateVftbl> nativeDelegate)
            {
                _nativeDelegate = nativeDelegate;
            }

            public void Invoke(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                IntPtr ThisPtr = _nativeDelegate.ThisPtr;
                var abiInvoke = Marshal.GetDelegateForFunctionPointer<Abi_Invoke>(_nativeDelegate.Vftbl.Invoke);
                IObjectReference __sender = default;
                IObjectReference __e = default;
                try
                {
                    __sender = MarshalInspectable.CreateMarshaler(sender);
                    __e = global::ABI.System.Collections.Specialized.NotifyCollectionChangedEventArgs.CreateMarshaler(e);
                    global::WinRT.ExceptionHelpers.ThrowExceptionForHR(abiInvoke(ThisPtr, MarshalInspectable.GetAbi(__sender), global::ABI.System.Collections.Specialized.NotifyCollectionChangedEventArgs.GetAbi(__e)));
                }
                finally
                {
                    MarshalInspectable.DisposeMarshaler(__sender);
                    global::ABI.System.Collections.Specialized.NotifyCollectionChangedEventArgs.DisposeMarshaler(__e);
                }

            }
        }

        public static IntPtr FromManaged(global::System.Collections.Specialized.NotifyCollectionChangedEventHandler managedDelegate) => CreateMarshaler(managedDelegate).GetRef();

        public static void DisposeMarshaler(IObjectReference value) => MarshalInterfaceHelper<global::System.Collections.Specialized.NotifyCollectionChangedEventHandler>.DisposeMarshaler(value);

        public static void DisposeAbi(IntPtr abi) => MarshalInterfaceHelper<global::System.Collections.Specialized.NotifyCollectionChangedEventHandler>.DisposeAbi(abi);

        private static unsafe int Do_Abi_Invoke(IntPtr thisPtr, IntPtr sender, IntPtr e)
        {
            try
            {
                global::WinRT.ComWrappersSupport.MarshalDelegateInvoke(thisPtr, (global::System.Collections.Specialized.NotifyCollectionChangedEventHandler invoke) =>
                {
                    invoke(MarshalInspectable.FromAbi(sender), global::ABI.System.Collections.Specialized.NotifyCollectionChangedEventArgs.FromAbi(e));
                });
            }
            catch (global::System.Exception __exception__)
            {
                global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
            }
            return 0;
        }
    }
}
