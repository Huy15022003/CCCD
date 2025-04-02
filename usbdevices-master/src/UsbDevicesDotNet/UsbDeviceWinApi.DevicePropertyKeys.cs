namespace Vurdalakov.UsbDevicesDotNet
{
    using System;

    public static partial class UsbDeviceWinApi
    {

        // devpkey.h

        public static class DevicePropertyKeys
        {
            public static DEVPROPKEY DEVPKEY_NAME = new DEVPROPKEY() { Fmtid = new Guid(0xb725f130, 0x47ef, 0x101a, 0xa5, 0xf1, 0x02, 0x60, 0x8c, 0x9e, 0xeb, 0xac), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_Device_DeviceDesc = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_HardwareIds = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_CompatibleIds = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_Service = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_Class = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 9 };
            public static DEVPROPKEY DEVPKEY_Device_ClassGuid = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_Device_Driver = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 11 };
            public static DEVPROPKEY DEVPKEY_Device_ConfigFlags = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 12 };
            public static DEVPROPKEY DEVPKEY_Device_Manufacturer = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 13 };
            public static DEVPROPKEY DEVPKEY_Device_FriendlyName = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 14 };
            public static DEVPROPKEY DEVPKEY_Device_LocationInfo = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 15 };
            public static DEVPROPKEY DEVPKEY_Device_PDOName = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 16 };
            public static DEVPROPKEY DEVPKEY_Device_Capabilities = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 17 };
            public static DEVPROPKEY DEVPKEY_Device_UINumber = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 18 };
            public static DEVPROPKEY DEVPKEY_Device_UpperFilters = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 19 };
            public static DEVPROPKEY DEVPKEY_Device_LowerFilters = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 20 };
            public static DEVPROPKEY DEVPKEY_Device_BusTypeGuid = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 21 };
            public static DEVPROPKEY DEVPKEY_Device_LegacyBusType = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 22 };
            public static DEVPROPKEY DEVPKEY_Device_BusNumber = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 23 };
            public static DEVPROPKEY DEVPKEY_Device_EnumeratorName = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 24 };
            public static DEVPROPKEY DEVPKEY_Device_Security = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 25 };
            public static DEVPROPKEY DEVPKEY_Device_SecuritySDS = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 26 };
            public static DEVPROPKEY DEVPKEY_Device_DevType = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 27 };
            public static DEVPROPKEY DEVPKEY_Device_Exclusive = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 28 };
            public static DEVPROPKEY DEVPKEY_Device_Characteristics = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 29 };
            public static DEVPROPKEY DEVPKEY_Device_Address = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 30 };
            public static DEVPROPKEY DEVPKEY_Device_UINumberDescFormat = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 31 };
            public static DEVPROPKEY DEVPKEY_Device_PowerData = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 32 };
            public static DEVPROPKEY DEVPKEY_Device_RemovalPolicy = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 33 };
            public static DEVPROPKEY DEVPKEY_Device_RemovalPolicyDefault = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 34 };
            public static DEVPROPKEY DEVPKEY_Device_RemovalPolicyOverride = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 35 };
            public static DEVPROPKEY DEVPKEY_Device_InstallState = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 36 };
            public static DEVPROPKEY DEVPKEY_Device_LocationPaths = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 37 };
            public static DEVPROPKEY DEVPKEY_Device_BaseContainerId = new DEVPROPKEY() { Fmtid = new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), Pid = 38 };
            public static DEVPROPKEY DEVPKEY_Device_DevNodeStatus = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_ProblemCode = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_EjectionRelations = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_RemovalRelations = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_Device_PowerRelations = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_BusRelations = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_Device_Parent = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 8 };
            public static DEVPROPKEY DEVPKEY_Device_Children = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 9 };
            public static DEVPROPKEY DEVPKEY_Device_Siblings = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_Device_TransportRelations = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 11 };
            public static DEVPROPKEY DEVPKEY_Device_ProblemStatus = new DEVPROPKEY() { Fmtid = new Guid(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7), Pid = 12 };
            public static DEVPROPKEY DEVPKEY_Device_Reported = new DEVPROPKEY() { Fmtid = new Guid(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_Legacy = new DEVPROPKEY() { Fmtid = new Guid(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_ContainerId = new DEVPROPKEY() { Fmtid = new Guid(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_InLocalMachineContainer = new DEVPROPKEY() { Fmtid = new Guid(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_ModelId = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_FriendlyNameAttributes = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_ManufacturerAttributes = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_PresenceNotForDevice = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_Device_SignalStrength = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_IsAssociateableByUserAction = new DEVPROPKEY() { Fmtid = new Guid(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_Numa_Proximity_Domain = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 1 };
            public static DEVPROPKEY DEVPKEY_Device_DHP_Rebalance_Policy = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_Numa_Node = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_BusReportedDeviceDesc = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_IsPresent = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_Device_HasProblem = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_ConfigurationId = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_Device_ReportedDeviceIdsHash = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 8 };
            public static DEVPROPKEY DEVPKEY_Device_PhysicalDeviceLocation = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 9 };
            public static DEVPROPKEY DEVPKEY_Device_BiosDeviceName = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_Device_DriverProblemDesc = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 11 };
            public static DEVPROPKEY DEVPKEY_Device_DebuggerSafe = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 12 };
            public static DEVPROPKEY DEVPKEY_Device_PostInstallInProgress = new DEVPROPKEY() { Fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), Pid = 13 };
            public static DEVPROPKEY DEVPKEY_Device_SessionId = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_InstallDate = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 100 };
            public static DEVPROPKEY DEVPKEY_Device_FirstInstallDate = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 101 };
            public static DEVPROPKEY DEVPKEY_Device_LastArrivalDate = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 102 };
            public static DEVPROPKEY DEVPKEY_Device_LastRemovalDate = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 103 };
            public static DEVPROPKEY DEVPKEY_Device_DriverDate = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_DriverVersion = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_DriverDesc = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_Device_DriverInfPath = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_Device_DriverInfSection = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_Device_DriverInfSectionExt = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_Device_MatchingDeviceId = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 8 };
            public static DEVPROPKEY DEVPKEY_Device_DriverProvider = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 9 };
            public static DEVPROPKEY DEVPKEY_Device_DriverPropPageProvider = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_Device_DriverCoInstallers = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 11 };
            public static DEVPROPKEY DEVPKEY_Device_ResourcePickerTags = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 12 };
            public static DEVPROPKEY DEVPKEY_Device_ResourcePickerExceptions = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 13 };
            public static DEVPROPKEY DEVPKEY_Device_DriverRank = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 14 };
            public static DEVPROPKEY DEVPKEY_Device_DriverLogoLevel = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 15 };
            public static DEVPROPKEY DEVPKEY_Device_NoConnectSound = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 17 };
            public static DEVPROPKEY DEVPKEY_Device_GenericDriverInstalled = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 18 };
            public static DEVPROPKEY DEVPKEY_Device_AdditionalSoftwareRequested = new DEVPROPKEY() { Fmtid = new Guid(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6), Pid = 19 };
            public static DEVPROPKEY DEVPKEY_Device_SafeRemovalRequired = new DEVPROPKEY() { Fmtid = new Guid(0xafd97640,  0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_Device_SafeRemovalRequiredOverride = new DEVPROPKEY() { Fmtid = new Guid(0xafd97640,  0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_Model = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_VendorWebSite = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_DetailedDescription = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_DocumentationLink = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_Icon = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_DrvPkg_BrandingIcon = new DEVPROPKEY() { Fmtid = new Guid(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_UpperFilters = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 19 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_LowerFilters = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 20 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_Security = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 25 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_SecuritySDS = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 26 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_DevType = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 27 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_Exclusive = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 28 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_Characteristics = new DEVPROPKEY() { Fmtid = new Guid(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b), Pid = 29 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_Name = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_ClassName = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_Icon = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_ClassInstaller = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_PropPageProvider = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_NoInstallClass = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 7 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_NoDisplayClass = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 8 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_SilentInstall = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 9 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_NoUseClass = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 10 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_DefaultService = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 11 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_IconPath = new DEVPROPKEY() { Fmtid = new Guid(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66), Pid = 12 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_DHPRebalanceOptOut = new DEVPROPKEY() { Fmtid = new Guid(0xd14d3ef3, 0x66cf, 0x4ba2, 0x9d, 0x38, 0x0d, 0xdb, 0x37, 0xab, 0x47, 0x01), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DeviceClass_ClassCoInstallers = new DEVPROPKEY() { Fmtid = new Guid(0x713d1703, 0xa2e2, 0x49f5, 0x92, 0x14, 0x56, 0x47, 0x2e, 0xf3, 0xda, 0x5c), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DeviceInterface_FriendlyName = new DEVPROPKEY() { Fmtid = new Guid(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DeviceInterface_Enabled = new DEVPROPKEY() { Fmtid = new Guid(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_DeviceInterface_ClassGuid = new DEVPROPKEY() { Fmtid = new Guid(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22), Pid = 4 };
            public static DEVPROPKEY DEVPKEY_DeviceInterface_ReferenceString = new DEVPROPKEY() { Fmtid = new Guid(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22), Pid = 5 };
            public static DEVPROPKEY DEVPKEY_DeviceInterface_Restricted = new DEVPROPKEY() { Fmtid = new Guid(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22), Pid = 6 };
            public static DEVPROPKEY DEVPKEY_DeviceInterfaceClass_DefaultInterface = new DEVPROPKEY() { Fmtid = new Guid(0x14c83a99, 0x0b3f, 0x44b7, 0xbe, 0x4c, 0xa1, 0x78, 0xd3, 0x99, 0x05, 0x64), Pid = 2 };
            public static DEVPROPKEY DEVPKEY_DeviceInterfaceClass_Name = new DEVPROPKEY() { Fmtid = new Guid(0x14c83a99, 0x0b3f, 0x44b7, 0xbe, 0x4c, 0xa1, 0x78, 0xd3, 0x99, 0x05, 0x64), Pid = 3 };
            public static DEVPROPKEY DEVPKEY_Device_Model = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 39 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Address = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 51 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_DiscoveryMethod = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 52 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsEncrypted = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 53 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsAuthenticated = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 54 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsConnected = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 55 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsPaired = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 56 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Icon = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 57 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Version = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 65 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Last_Seen = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 66 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Last_Connected = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 67 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsShowInDisconnectedState = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 68 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsLocalMachine = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 70 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_MetadataPath = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 71 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsMetadataSearchInProgress = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 72 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_MetadataChecksum = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 73 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsNotInterestingForDisplay = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 74 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_LaunchDeviceStageOnDeviceConnect = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 76 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_LaunchDeviceStageFromExplorer = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 77 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_BaselineExperienceId = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 78 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsDeviceUniquelyIdentifiable = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 79 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_AssociationArray = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 80 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_DeviceDescription1 = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 81 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_DeviceDescription2 = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 82 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_HasProblem = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 83 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsSharedDevice = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 84 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsNetworkDevice = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 85 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsDefaultDevice = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 86 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_MetadataCabinet = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 87 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_RequiresPairingElevation = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 88 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_ExperienceId = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 89 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Category = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 90 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Category_Desc_Singular = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 91 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Category_Desc_Plural = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 92 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Category_Icon = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 93 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_CategoryGroup_Desc = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 94 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_CategoryGroup_Icon = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 95 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_PrimaryCategory = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 97 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_UnpairUninstall = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 98 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_RequiresUninstallElevation = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 99 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_DeviceFunctionSubRank = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 100 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_AlwaysShowDeviceAsConnected = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 101 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_ConfigFlags = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 105 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_PrivilegedPackageFamilyNames = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 106 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_CustomPrivilegedPackageFamilyNames = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 107 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_IsRebootRequired = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 108 };
            public static DEVPROPKEY DEVPKEY_Device_InstanceId = new DEVPROPKEY() { Fmtid = new Guid(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57), Pid = 256 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_FriendlyName = new DEVPROPKEY() { Fmtid = new Guid(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD), Pid = 12288 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_Manufacturer = new DEVPROPKEY() { Fmtid = new Guid(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD), Pid = 8192 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_ModelName = new DEVPROPKEY() { Fmtid = new Guid(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD), Pid = 8194 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_ModelNumber = new DEVPROPKEY() { Fmtid = new Guid(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD), Pid = 8195 };
            public static DEVPROPKEY DEVPKEY_DeviceContainer_InstallInProgress = new DEVPROPKEY() { Fmtid = new Guid(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29), Pid = 9 };
        }
    }
}
