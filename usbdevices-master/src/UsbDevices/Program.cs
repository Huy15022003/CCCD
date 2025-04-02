namespace Vurdalakov.UsbDevicesDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(String[] args)
        {
            UsbDevice[] usbDevices = UsbDevice.GetDevices();

            if (usbDevices.Length == 0)
            {
                Console.WriteLine("Không có thiết bị USB nào được kết nối.");
                return;
            }

            // Nhóm USB theo Hub
            var usbByHub = usbDevices.GroupBy(d => d.Hub).ToDictionary(g => g.Key, g => g.ToList());

            Console.WriteLine("\n===== Danh sách Hub USB =====");

            foreach (var hub in usbByHub.Keys.OrderBy(h => h))
            {
                Console.WriteLine($"\n🔌 Hub {hub}:");

                foreach (var usbDevice in usbByHub[hub])
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"- Hub:Port       = {usbDevice.Hub}:{usbDevice.Port}");
                    Console.WriteLine($"- VID:PID        = VID_{usbDevice.Vid}&PID_{usbDevice.Pid}");
                    Console.WriteLine($"- Manufacturer   = {GetManufacturer(usbDevice)}");
                    Console.WriteLine($"- Serial Number  = {GetSerialNumber(usbDevice)}");
                    Console.WriteLine($"- Device Path    = {usbDevice.DevicePath}");
                    Console.WriteLine($"- Device ID      = {usbDevice.DeviceId}");
                    Console.WriteLine($"- Description    = {usbDevice.BusReportedDeviceDescription}");
                }
            }
        }

        static string GetManufacturer(UsbDevice usbDevice)
        {
            object manufacturer = usbDevice.GetRegistryPropertyValue(UsbDeviceWinApi.DeviceRegistryPropertyKeys.SPDRP_MFG);
            return manufacturer?.ToString() ?? "Unknown";
        }

        static string GetSerialNumber(UsbDevice usbDevice)
        {
            object serialObj = usbDevice.GetRegistryPropertyValue(UsbDeviceWinApi.DeviceRegistryPropertyKeys.SPDRP_HARDWAREID);
            if (serialObj is string[] hardwareIds && hardwareIds.Length > 0)
            {
                string lastPart = hardwareIds[0].Split('\\').LastOrDefault();
                if (!string.IsNullOrEmpty(lastPart))
                {
                    return lastPart;
                }
            }
            return "Unknown";
        }
    }
}
