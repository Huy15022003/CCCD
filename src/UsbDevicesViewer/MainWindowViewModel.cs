namespace UsbDevicesViewer
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Text;
    using Vurdalakov;
    using Vurdalakov.UsbDevicesDotNet;
    using System.Linq;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System.IO;
    using Microsoft.Win32;
    using System.Timers;
    using System.Windows.Data;

    public class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "Connected" : "Disconnected";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class HubPortInfo
    {
        public string HubInfomation { get; set; }
        public string PortInfomation { get; set; }

        public HubPortInfo(string hub, string port)
        {
            HubInfomation = hub ?? "Không xác định";
            PortInfomation = port ?? "Không xác định";
        }
    }

    // Class để lưu trạng thái và lịch sử của từng thiết bị USB
    public class UsbDeviceStatus
    {
        public bool IsConnected { get; set; }
        public UsbDeviceViewModel Device { get; set; }
        public List<(DateTime Time, string Event)> EventHistory { get; set; } // Lịch sử sự kiện cắm/rút

        public UsbDeviceStatus(UsbDeviceViewModel device, bool isConnected)
        {
            Device = device;
            IsConnected = isConnected;
            EventHistory = new List<(DateTime, string)>();
            EventHistory.Add((DateTime.Now, isConnected ? "Connected" : "Disconnected"));
        }

        public void AddEvent(string eventType)
        {
            EventHistory.Add((DateTime.Now, eventType));
        }
    }

    // Class để hiển thị trạng thái thiết bị trong UI
    public class UsbDeviceStatusViewModel : ViewModelBase
    {
        private string deviceId;
        public string DeviceId
        {
            get => deviceId;
            set { deviceId = value; OnPropertyChanged(() => DeviceId); }
        }

        private string description;
        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(() => Description); }
        }

        private bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set { isConnected = value; OnPropertyChanged(() => IsConnected); }
        }

        private string lastEventTime;
        public string LastEventTime
        {
            get => lastEventTime;
            set { lastEventTime = value; OnPropertyChanged(() => LastEventTime); }
        }

        private string lastEvent;
        public string LastEvent
        {
            get => lastEvent;
            set { lastEvent = value; OnPropertyChanged(() => LastEvent); }
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        private Int32 selectedDeviceType;
        public Int32 SelectedDeviceType
        {
            get { return this.selectedDeviceType; }
            set
            {
                if (this.selectedDeviceType != value)
                {
                    this.selectedDeviceType = value;
                    this.OnPropertyChanged(() => this.SelectedDeviceType);
                }

                switch (this.selectedDeviceType)
                {
                    case 0:
                        this.SelectedDevice = this.SelectedUsbDevice;
                        break;
                    case 1:
                        this.SelectedDevice = this.SelectedUsbHub;
                        break;
                    case 2:
                        this.SelectedDevice = this.SelectedUsbHostController;
                        break;
                }

                this.PropertiesHeight = 4 == this.selectedDeviceType ? "0" : "2*";
            }
        }

        public ThreadSafeObservableCollection<UsbDeviceViewModel> UsbDevices { get; private set; }

        private UsbDeviceViewModel selectedUsbDevice;
        public UsbDeviceViewModel SelectedUsbDevice
        {
            get
            {
                return this.selectedUsbDevice;
            }
            set
            {
                if (value != this.selectedUsbDevice)
                {
                    this.selectedUsbDevice = value;
                    this.OnPropertyChanged(() => this.SelectedUsbDevice);

                    this.SelectedDevice = this.selectedUsbDevice;
                }
            }
        }

        public ThreadSafeObservableCollection<UsbDeviceViewModel> UsbHubs { get; private set; }

        private UsbDeviceViewModel selectedUsbHub;
        public UsbDeviceViewModel SelectedUsbHub
        {
            get
            {
                return this.selectedUsbHub;
            }
            set
            {
                if (value != this.selectedUsbHub)
                {
                    this.selectedUsbHub = value;
                    this.OnPropertyChanged(() => this.SelectedUsbHub);

                    this.SelectedDevice = this.selectedUsbHub;
                }
            }
        }

        public ThreadSafeObservableCollection<UsbDeviceViewModel> UsbHostControllers { get; private set; }

        private UsbDeviceViewModel selectedUsbHostController;
        public UsbDeviceViewModel SelectedUsbHostController
        {
            get
            {
                return this.selectedUsbHostController;
            }
            set
            {
                if (value != this.selectedUsbHostController)
                {
                    this.selectedUsbHostController = value;
                    this.OnPropertyChanged(() => this.SelectedUsbHostController);

                    this.SelectedDevice = this.selectedUsbHostController;
                }
            }
        }

        public ThreadSafeObservableCollection<UsbDeviceViewModel> UsbTreeItems { get; private set; }

        private UsbDeviceViewModel selectedUsbTreeItem;
        public UsbDeviceViewModel SelectedUsbTreeItem
        {
            get
            {
                return this.selectedUsbTreeItem;
            }
            set
            {
                if (value != this.selectedUsbTreeItem)
                {
                    this.selectedUsbTreeItem = value;
                    this.OnPropertyChanged(() => this.SelectedUsbTreeItem);

                    this.SelectedDevice = this.selectedUsbTreeItem;
                }
            }
        }

        private UsbDeviceViewModel selectedUsbReportItem;
        public UsbDeviceViewModel SelectedUsbReportItem
        {
            get { return this.selectedUsbReportItem; }
            set
            {
                if (this.selectedUsbReportItem != value)
                {
                    this.selectedUsbReportItem = value;
                    this.OnPropertyChanged(() => this.SelectedUsbReportItem);
                }
            }
        }

        private UsbDeviceViewModel selectedDevice;
        public UsbDeviceViewModel SelectedDevice
        {
            get
            {
                return this.selectedDevice;
            }
            set
            {
                if (value != this.selectedDevice)
                {
                    this.selectedDevice = value;
                    this.OnPropertyChanged(() => this.SelectedDevice);
                }
            }
        }

        private NameValueTypeViewModel selectedProperty;
        public NameValueTypeViewModel SelectedProperty
        {
            get
            {
                return this.selectedProperty;
            }
            set
            {
                if (value != this.selectedProperty)
                {
                    this.selectedProperty = value;
                    this.OnPropertyChanged(() => this.SelectedProperty);
                }
            }
        }

        private NameValueTypeViewModel selectedRegistryProperty;
        public NameValueTypeViewModel SelectedRegistryProperty
        {
            get
            {
                return this.selectedRegistryProperty;
            }
            set
            {
                if (value != this.selectedRegistryProperty)
                {
                    this.selectedRegistryProperty = value;
                    this.OnPropertyChanged(() => this.SelectedRegistryProperty);
                }
            }
        }

        private NameValueTypeViewModel selectedInterface;
        public NameValueTypeViewModel SelectedInterface
        {
            get
            {
                return this.selectedInterface;
            }
            set
            {
                if (value != this.selectedInterface)
                {
                    this.selectedInterface = value;
                    this.OnPropertyChanged(() => this.SelectedInterface);
                }
            }
        }

        // Từ điển để theo dõi trạng thái từng thiết bị USB
        private Dictionary<string, UsbDeviceStatus> usbDeviceStatuses;

        // Collection để hiển thị trạng thái thiết bị trong UI
        public ThreadSafeObservableCollection<UsbDeviceStatusViewModel> DeviceStatuses { get; private set; }

        // Đường dẫn file JSON mặc định
        private readonly string defaultJsonFilePath = "UsbDevicesReport.json";

        // Timer để debounce việc xuất JSON
        private readonly Timer exportJsonTimer;
        private bool exportPending;

        public MainWindowViewModel()
        {
            this.UsbDevices = new ThreadSafeObservableCollection<UsbDeviceViewModel>();
            this.UsbHubs = new ThreadSafeObservableCollection<UsbDeviceViewModel>();
            this.UsbHostControllers = new ThreadSafeObservableCollection<UsbDeviceViewModel>();
            this.UsbTreeItems = new ThreadSafeObservableCollection<UsbDeviceViewModel>();

            this.DeviceEvents = new ThreadSafeObservableCollection<DeviceEvent>();
            this.DeviceStatuses = new ThreadSafeObservableCollection<UsbDeviceStatusViewModel>();

            // Khởi tạo từ điển để theo dõi trạng thái thiết bị
            this.usbDeviceStatuses = new Dictionary<string, UsbDeviceStatus>();

            // Khởi tạo timer để debounce xuất JSON (500ms)
            this.exportJsonTimer = new Timer(500);
            this.exportJsonTimer.Elapsed += (s, e) =>
            {
                if (exportPending)
                {
                    ExportUsbReportToJson(defaultJsonFilePath);
                    exportPending = false;
                }
            };
            this.exportJsonTimer.AutoReset = false;

            this.ExitCommand = new CommandBase(this.OnExitCommand);
            this.RefreshCommand = new CommandBase(this.OnRefreshCommand);
            this.AboutCommand = new CommandBase(this.OnAboutCommand);

            this.CopyCommand = new CommandBase<String>(this.OnCopyCommand);
            this.ClearDeviceEventsCommand = new CommandBase<String>(this.OnClearDeviceEventsCommand);
            this.EnableDeviceWatcher(true);

            // Khởi tạo danh sách thiết bị và xuất JSON lần đầu
            this.Refresh();
            this.ExportUsbReportToJson(defaultJsonFilePath);
        }

        public void Close()
        {
            this.EnableDeviceWatcher(false);
            this.exportJsonTimer.Stop();
            this.exportJsonTimer.Dispose();
        }

        #region Device events

        private Win32UsbControllerDevices win32UsbControllerDevices = new Win32UsbControllerDevices();
        private DeviceManagementNotifications deviceManagementNotifications = new DeviceManagementNotifications();

        private void EnableDeviceWatcher(Boolean enable)
        {
            if (enable)
            {
                this.win32UsbControllerDevices.DeviceConnected += OnWin32UsbControllerDevicesDeviceConnected;
                this.win32UsbControllerDevices.DeviceDisconnected += OnWin32UsbControllerDevicesDeviceDisconnected;
                this.win32UsbControllerDevices.DeviceModified += OnWin32UsbControllerDevicesDeviceModified;

                this.win32UsbControllerDevices.StartWatcher();

                this.deviceManagementNotifications.DeviceConnected += OnDeviceManagementNotificationsDeviceConnected;
                this.deviceManagementNotifications.DeviceDisconnected += OnDeviceManagementNotificationsDeviceDisconnected;

                this.deviceManagementNotifications.Start(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE));
            }
            else
            {
                this.deviceManagementNotifications.Stop();

                this.deviceManagementNotifications.DeviceConnected -= OnDeviceManagementNotificationsDeviceConnected;
                this.deviceManagementNotifications.DeviceDisconnected -= OnDeviceManagementNotificationsDeviceDisconnected;

                this.win32UsbControllerDevices.StopWatcher();

                this.win32UsbControllerDevices.DeviceConnected -= OnWin32UsbControllerDevicesDeviceConnected;
                this.win32UsbControllerDevices.DeviceDisconnected -= OnWin32UsbControllerDevicesDeviceDisconnected;
                this.win32UsbControllerDevices.DeviceModified -= OnWin32UsbControllerDevicesDeviceModified;
            }
        }

        private Boolean refreshListOnDeviceManagementEvents = true;
        public Boolean RefreshListOnDeviceManagementEvents
        {
            get
            {
                return this.refreshListOnDeviceManagementEvents;
            }
            set
            {
                if (value != this.refreshListOnDeviceManagementEvents)
                {
                    this.refreshListOnDeviceManagementEvents = value;
                    this.OnPropertyChanged(() => this.RefreshListOnDeviceManagementEvents);
                }
            }
        }

        private Boolean refreshListOnWmiEvents = false;
        public Boolean RefreshListOnWmiEvents
        {
            get
            {
                return this.refreshListOnWmiEvents;
            }
            set
            {
                if (value != this.refreshListOnWmiEvents)
                {
                    this.refreshListOnWmiEvents = value;
                    this.OnPropertyChanged(() => this.RefreshListOnWmiEvents);
                }
            }
        }

        private Boolean selectConnectedDevice = true;
        public Boolean SelectConnectedDevice
        {
            get
            {
                return this.selectConnectedDevice;
            }
            set
            {
                if (value != this.selectConnectedDevice)
                {
                    this.selectConnectedDevice = value;
                    this.OnPropertyChanged(() => this.SelectConnectedDevice);
                }
            }
        }

        private void OnWin32UsbControllerDevicesDeviceConnected(Object sender, Win32UsbControllerDeviceEventArgs e)
        {
            this.DeviceEvents.Insert(0, new DeviceEvent(0, e.Device));

            // Tìm UsbDevice tương ứng
            var usbDevice = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DeviceId.Equals(e.Device.DeviceId, StringComparison.OrdinalIgnoreCase));
            if (usbDevice != null)
            {
                UpdateDeviceStatus(usbDevice, true, "Connected");
                this.RefreshDevice(usbDevice.DeviceId);
            }

            ScheduleExportJson();
        }

        private void OnWin32UsbControllerDevicesDeviceDisconnected(Object sender, Win32UsbControllerDeviceEventArgs e)
        {
            this.DeviceEvents.Insert(0, new DeviceEvent(1, e.Device));

            // Tìm UsbDevice tương ứng
            var usbDevice = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DeviceId.Equals(e.Device.DeviceId, StringComparison.OrdinalIgnoreCase));
            if (usbDevice != null)
            {
                UpdateDeviceStatus(usbDevice, false, "Disconnected");
                this.RefreshDevice(usbDevice.DeviceId);
            }
            else
            {
                // Nếu không tìm thấy, cập nhật trạng thái bằng DeviceId
                UpdateDeviceStatusById(e.Device.DeviceId, false, "Disconnected");
                this.RefreshDevice(e.Device.DeviceId);
            }

            ScheduleExportJson();
        }
        private void OnWin32UsbControllerDevicesDeviceModified(object sender, Win32UsbControllerDeviceEventArgs e)
        {
            this.DeviceEvents.Insert(0, new DeviceEvent(2, e.Device));

            // Tìm UsbDevice tương ứng
            var usbDevice = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DeviceId.Equals(e.Device.DeviceId, StringComparison.OrdinalIgnoreCase));
            if (usbDevice != null)
            {
                UpdateDeviceStatus(usbDevice, true, "Modified");
                this.RefreshDevice(usbDevice.DeviceId);
            }

            ScheduleExportJson();
        }
        private void OnDeviceManagementNotificationsDeviceConnected(Object sender, DeviceManagementNotificationsEventArgs e)
        {
            this.DeviceEvents.Insert(0, new DeviceEvent(3, e.DevicePath));

            // Tìm thiết bị tương ứng và cập nhật trạng thái
            var device = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DevicePath.Equals(e.DevicePath, StringComparison.OrdinalIgnoreCase));
            if (device != null)
            {
                UpdateDeviceStatus(device, true, "Connected");
                this.RefreshDevice(device.DeviceId);
            }

            ScheduleExportJson();
        }

        private void OnDeviceManagementNotificationsDeviceDisconnected(Object sender, DeviceManagementNotificationsEventArgs e)
        {
            this.DeviceEvents.Insert(0, new DeviceEvent(4, e.DevicePath));

            // Tìm thiết bị tương ứng và cập nhật trạng thái
            var device = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DevicePath.Equals(e.DevicePath, StringComparison.OrdinalIgnoreCase));
            if (device != null)
            {
                UpdateDeviceStatus(device, false, "Disconnected");
                this.RefreshDevice(device.DeviceId);
            }
            else
            {
                // Nếu không tìm thấy thiết bị, thử tìm trong từ điển trạng thái
                var deviceId = usbDeviceStatuses.FirstOrDefault(x => x.Value.Device?.DevicePath == e.DevicePath).Key;
                if (!string.IsNullOrEmpty(deviceId))
                {
                    UpdateDeviceStatusById(deviceId, false, "Disconnected");
                    this.RefreshDevice(deviceId);
                }
            }

            ScheduleExportJson();
        }

        // Cập nhật trạng thái thiết bị trong từ điển
        private void UpdateDeviceStatus(UsbDevice device, bool isConnected, string eventType)
        {
            if (device == null || string.IsNullOrEmpty(device.DeviceId)) return;

            var usbDevice = UsbDevice.GetDevices(new Guid(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE))
                .FirstOrDefault(d => d.DeviceId.Equals(device.DeviceId, StringComparison.OrdinalIgnoreCase));
            var deviceViewModel = usbDevice != null ? new UsbDeviceViewModel(usbDevice) : null;

            if (usbDeviceStatuses.ContainsKey(device.DeviceId))
            {
                usbDeviceStatuses[device.DeviceId].IsConnected = isConnected;
                usbDeviceStatuses[device.DeviceId].AddEvent(eventType);
                if (deviceViewModel != null)
                {
                    usbDeviceStatuses[device.DeviceId].Device = deviceViewModel;
                }
            }
            else if (deviceViewModel != null)
            {
                usbDeviceStatuses[device.DeviceId] = new UsbDeviceStatus(deviceViewModel, isConnected);
                usbDeviceStatuses[device.DeviceId].AddEvent(eventType);
            }

            // Cập nhật DeviceStatuses để hiển thị trong UI
            UpdateDeviceStatuses(device.DeviceId);
        }

        // Cập nhật trạng thái thiết bị theo DeviceId
        private void UpdateDeviceStatusById(string deviceId, bool isConnected, string eventType)
        {
            if (string.IsNullOrEmpty(deviceId)) return;

            if (usbDeviceStatuses.ContainsKey(deviceId))
            {
                usbDeviceStatuses[deviceId].IsConnected = isConnected;
                usbDeviceStatuses[deviceId].AddEvent(eventType);
            }

            // Cập nhật DeviceStatuses để hiển thị trong UI
            UpdateDeviceStatuses(deviceId);
        }

        // Cập nhật collection DeviceStatuses để hiển thị trong UI
        private void UpdateDeviceStatuses(string deviceId)
        {
            if (!usbDeviceStatuses.ContainsKey(deviceId)) return;

            var status = usbDeviceStatuses[deviceId];
            var viewModel = DeviceStatuses.FirstOrDefault(d => d.DeviceId == deviceId);
            var lastEvent = status.EventHistory.LastOrDefault();

            if (viewModel == null)
            {
                viewModel = new UsbDeviceStatusViewModel
                {
                    DeviceId = deviceId,
                    Description = status.Device?.Description ?? "Không xác định",
                    IsConnected = status.IsConnected,
                    LastEventTime = lastEvent.Time.ToString("HH:mm:ss.fff"),
                    LastEvent = lastEvent.Event
                };
                DeviceStatuses.Add(viewModel);
            }
            else
            {
                viewModel.Description = status.Device?.Description ?? "Không xác định";
                viewModel.IsConnected = status.IsConnected;
                viewModel.LastEventTime = lastEvent.Time.ToString("HH:mm:ss.fff");
                viewModel.LastEvent = lastEvent.Event;
            }
        }

        // Cập nhật danh sách thiết bị chỉ cho thiết bị bị ảnh hưởng
        private void RefreshDevice(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId)) return;

            // Cập nhật danh sách UsbDevices
            var deviceToUpdate = usbDeviceStatuses.ContainsKey(deviceId) ? usbDeviceStatuses[deviceId] : null;
            if (deviceToUpdate != null)
            {
                var existingDevice = this.UsbDevices.FirstOrDefault(d => d.DeviceId.Equals(deviceId, StringComparison.OrdinalIgnoreCase));
                if (deviceToUpdate.IsConnected)
                {
                    if (existingDevice == null)
                    {
                        this.UsbDevices.Add(deviceToUpdate.Device);
                    }
                    else
                    {
                        var index = this.UsbDevices.IndexOf(existingDevice);
                        this.UsbDevices[index] = deviceToUpdate.Device;
                    }
                }
                else
                {
                    if (existingDevice != null)
                    {
                        this.UsbDevices.Remove(existingDevice);
                    }
                }
            }

            // Cập nhật cây thiết bị
            this.RefreshTree();

            // Cập nhật Summary
            this.Summary = String.Format("{0:N0} USB devices, {1:N0} USB hubs and {2:N0} USB host controllers", this.UsbDevices.Count, this.UsbHubs.Count, this.UsbHostControllers.Count);
            this.OnPropertyChanged(() => this.Summary);
        }

        // Lên lịch xuất JSON với debounce
        private void ScheduleExportJson()
        {
            exportPending = true;
            exportJsonTimer.Stop();
            exportJsonTimer.Start();
        }

        public ThreadSafeObservableCollection<DeviceEvent> DeviceEvents { get; set; }

        private DeviceEvent selectedDeviceEvent;
        public DeviceEvent SelectedDeviceEvent
        {
            get
            {
                return this.selectedDeviceEvent;
            }
            set
            {
                if (value != this.selectedDeviceEvent)
                {
                    this.selectedDeviceEvent = value;
                    this.OnPropertyChanged(() => this.SelectedDeviceEvent);
                }
            }
        }

        public ICommand ClearDeviceEventsCommand { get; private set; }
        public void OnClearDeviceEventsCommand(String source)
        {
            this.DeviceEvents.Clear();
        }

        #endregion

        public ICommand ExitCommand { get; private set; }
        public void OnExitCommand()
        {
            Application.Current.MainWindow.Close();
        }

        public ICommand RefreshCommand { get; private set; }

        public RelayCommand ExportToJsonCommand { get; private set; }

        public void OnRefreshCommand()
        {
            this.Refresh();
            this.ExportUsbReportToJson(defaultJsonFilePath);
        }

        public ICommand AboutCommand { get; private set; }
        public void OnAboutCommand()
        {
            var aboutWindow = new AboutWindow(Application.Current.MainWindow);
            aboutWindow.ShowDialog();
        }

        public String Summary { get; private set; }

        public void Refresh(String deviceId = null, String devicePath = null)
        {
            this.Refresh(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_DEVICE, this.UsbDevices, this.SelectedUsbDevice, d => this.SelectedUsbDevice = d, deviceId, devicePath);
            this.Refresh(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_HUB, this.UsbHubs, this.SelectedUsbHub, d => this.SelectedUsbHub = d);
            this.Refresh(UsbDeviceWinApi.GUID_DEVINTERFACE_USB_HOST_CONTROLLER, this.UsbHostControllers, this.SelectedUsbHostController, d => this.SelectedUsbHostController = d);

            // Cập nhật từ điển trạng thái
            foreach (var device in this.UsbDevices)
            {
                if (!usbDeviceStatuses.ContainsKey(device.DeviceId))
                {
                    usbDeviceStatuses[device.DeviceId] = new UsbDeviceStatus(device, true);
                }
                else
                {
                    usbDeviceStatuses[device.DeviceId].IsConnected = true;
                    usbDeviceStatuses[device.DeviceId].Device = device;
                }
                UpdateDeviceStatuses(device.DeviceId);
            }

            // Xóa các thiết bị không còn kết nối
            var disconnectedDevices = usbDeviceStatuses.Where(kvp => !this.UsbDevices.Any(d => d.DeviceId == kvp.Key)).ToList();
            foreach (var kvp in disconnectedDevices)
            {
                usbDeviceStatuses[kvp.Key].IsConnected = false;
                UpdateDeviceStatuses(kvp.Key);
            }

            this.RefreshTree();

            if (null == this.SelectedDevice)
            {
                this.SelectedDeviceType = this.SelectedDeviceType;
            }

            this.Summary = String.Format("{0:N0} USB devices, {1:N0} USB hubs and {2:N0} USB host controllers", this.UsbDevices.Count, this.UsbHubs.Count, this.UsbHostControllers.Count);
            this.OnPropertyChanged(() => this.Summary);
        }

        private void Refresh(String guid, ThreadSafeObservableCollection<UsbDeviceViewModel> deviceList, UsbDeviceViewModel selectedDevice, Action<UsbDeviceViewModel> setSelectedDevice, String deviceId = null, String devicePath = null)
        {
            if (String.IsNullOrEmpty(deviceId) && String.IsNullOrEmpty(devicePath))
            {
                if (selectedDevice != null)
                {
                    deviceId = selectedDevice.DeviceId;
                }
                else if (deviceList.Count > 0)
                {
                    deviceId = deviceList[0].DeviceId;
                }
            }

            deviceList.Clear();

            UsbDevice[] usbDevices = UsbDevice.GetDevices(new Guid(guid));

            List<UsbDeviceViewModel> usbDeviceViewModels = new List<UsbDeviceViewModel>();
            foreach (UsbDevice usbDevice in usbDevices)
            {
                usbDeviceViewModels.Add(new UsbDeviceViewModel(usbDevice));
            }

            deviceList.AddRange(usbDeviceViewModels);

            if (!String.IsNullOrEmpty(deviceId))
            {
                foreach (UsbDeviceViewModel usbDeviceViewModel in deviceList)
                {
                    if (usbDeviceViewModel.DeviceId.Equals(deviceId, StringComparison.CurrentCultureIgnoreCase))
                    {
                        setSelectedDevice(usbDeviceViewModel);
                        return;
                    }
                }
            }

            if (!String.IsNullOrEmpty(devicePath))
            {
                foreach (UsbDeviceViewModel usbDeviceViewModel in deviceList)
                {
                    if (usbDeviceViewModel.DevicePath.Equals(devicePath, StringComparison.CurrentCultureIgnoreCase))
                    {
                        setSelectedDevice(usbDeviceViewModel);
                        return;
                    }
                }
            }

            if (deviceList.Count > 0)
            {
                setSelectedDevice(deviceList[0]);
            }
        }

        private void RefreshTree()
        {
            this.UsbTreeItems.Clear();

            var root = new UsbDeviceViewModel();

            foreach (var controller in this.UsbHostControllers)
            {
                root.TreeViewItems.Add(controller);

                controller.TreeViewItems.Clear();
                foreach (var hub in this.UsbHubs)
                {
                    if (hub.ParentDeviceId.Equals(controller.DeviceId, StringComparison.CurrentCultureIgnoreCase))
                    {
                        controller.TreeViewItems.Add(hub);

                        FillUsbHub(hub);
                    }
                }
            }

            this.UsbTreeItems.Add(root);
        }

        private void FillUsbHub(UsbDeviceViewModel hub)
        {
            hub.TreeViewItems.Clear();

            foreach (var subhub in this.UsbHubs)
            {
                if (subhub.ParentDeviceId.Equals(hub.DeviceId, StringComparison.CurrentCultureIgnoreCase))
                {
                    hub.TreeViewItems.Add(subhub);

                    FillUsbHub(subhub);
                }
            }

            foreach (var device in this.UsbDevices)
            {
                if (device.ParentDeviceId.Equals(hub.DeviceId, StringComparison.CurrentCultureIgnoreCase))
                {
                    hub.TreeViewItems.Add(device);
                }
            }
        }

        public ICommand CopyCommand { get; private set; }
        public void OnCopyCommand(String source)
        {
            try
            {
                switch (source)
                {
                    case "1001":
                        Clipboard.SetText(this.SelectedUsbDevice.Vid);
                        break;
                    case "1002":
                        Clipboard.SetText(this.SelectedUsbDevice.Pid);
                        break;
                    case "1003":
                        Clipboard.SetText(this.SelectedUsbDevice.HubAndPort);
                        break;
                    case "1004":
                        Clipboard.SetText(this.SelectedUsbDevice.Description);
                        break;
                    case "1005":
                        Clipboard.SetText(this.SelectedUsbDevice.DeviceId);
                        break;
                    case "1006":
                        Clipboard.SetText(this.SelectedUsbDevice.DevicePath);
                        break;
                    case "1101":
                        Clipboard.SetText(this.SelectedUsbHub.Vid);
                        break;
                    case "1102":
                        Clipboard.SetText(this.SelectedUsbHub.Pid);
                        break;
                    case "1103":
                        Clipboard.SetText(this.SelectedUsbHub.HubAndPort);
                        break;
                    case "1104":
                        Clipboard.SetText(this.SelectedUsbHub.Description);
                        break;
                    case "1105":
                        Clipboard.SetText(this.SelectedUsbHub.DeviceId);
                        break;
                    case "1106":
                        Clipboard.SetText(this.SelectedUsbHub.DevicePath);
                        break;
                    case "1204":
                        Clipboard.SetText(this.SelectedUsbHostController.Description);
                        break;
                    case "1205":
                        Clipboard.SetText(this.SelectedUsbHostController.DeviceId);
                        break;
                    case "1206":
                        Clipboard.SetText(this.SelectedUsbHostController.DevicePath);
                        break;
                    case "1301":
                        Clipboard.SetText(this.SelectedDeviceEvent.Time.ToString("HH:mm:ss.ffff"));
                        break;
                    case "1302":
                        String[] eventTypes = { "Connected", "Disconnected", "Modified" };
                        Clipboard.SetText(eventTypes[this.SelectedDeviceEvent.EventType]);
                        break;
                    case "1303":
                        Clipboard.SetText(this.SelectedDeviceEvent.Vid);
                        break;
                    case "1304":
                        Clipboard.SetText(this.SelectedDeviceEvent.Pid);
                        break;
                    case "1305":
                        Clipboard.SetText(this.SelectedDeviceEvent.HubAndPort);
                        break;
                    case "1306":
                        Clipboard.SetText(this.SelectedDeviceEvent.DeviceId);
                        break;
                    case "1307":
                        Clipboard.SetText(this.SelectedDeviceEvent.ControllerId);
                        break;
                    case "2001":
                        Clipboard.SetText(this.SelectedProperty.Name);
                        break;
                    case "2002":
                        Clipboard.SetText(this.SelectedProperty.Type as String);
                        break;
                    case "2003":
                        Clipboard.SetText(this.SelectedProperty.Value as String);
                        break;
                    case "3001":
                        Clipboard.SetText(this.SelectedRegistryProperty.Name);
                        break;
                    case "3002":
                        Clipboard.SetText(this.SelectedRegistryProperty.Type as String);
                        break;
                    case "3003":
                        Clipboard.SetText(this.SelectedRegistryProperty.Value as String);
                        break;
                    case "4001":
                        Clipboard.SetText(this.SelectedInterface.Value as String);
                        break;
                }
            }
            catch { }
        }

        private String propertiesHeight = "2*";

        public String PropertiesHeight
        {
            get { return this.propertiesHeight; }
            set
            {
                if (this.propertiesHeight != value)
                {
                    this.propertiesHeight = value;
                    this.OnPropertyChanged(() => this.PropertiesHeight);
                }
            }
        }

        public void ExportUsbReportToJson(string filePath)
        {
            try
            {
                // Hàm hỗ trợ để tách HubAndPort thành Hub và Port
                HubPortInfo SplitHubAndPort(string hubAndPort, bool isRootHub = false)
                {
                    if (isRootHub)
                    {
                        return new HubPortInfo("Root", "N/A");
                    }

                    if (string.IsNullOrEmpty(hubAndPort) || hubAndPort == "Không xác định")
                    {
                        return new HubPortInfo(null, null);
                    }

                    var parts = hubAndPort.Split(':');
                    if (parts.Length == 2)
                    {
                        return new HubPortInfo(parts[0], parts[1]);
                    }

                    return new HubPortInfo(null, null);
                }

                // Tạo cấu trúc dữ liệu JSON
                var reportData = new
                {
                    UsbHubs = this.UsbHubs.Select((hub, index) => new
                    {
                        HubInfo = new
                        {
                            HubPort = SplitHubAndPort(
                                hub.HubAndPort ?? (hub.DeviceId?.Contains("ROOT_HUB") == true ? "Root" : "Không xác định"),
                                hub.DeviceId?.Contains("ROOT_HUB") == true
                            ),
                            Vid = hub.Vid ?? "Không có",
                            Pid = hub.Pid ?? "Không có",
                            Manufacturer = hub.Manufacturer ?? "Không xác định",
                            SerialNumber = hub.SerialNumber ?? "Không có",
                            DevicePath = hub.DevicePath,
                            DeviceId = hub.DeviceId,
                            Description = hub.Description ?? "Không xác định"
                        },
                        Devices = hub.TreeViewItems
                            .Where(device => device.DeviceType == UsbDeviceType.Device) // Chỉ lấy các thiết bị USB, không lấy sub-hub
                            .OrderBy(device => device.HubAndPort) // Sắp xếp theo HubAndPort (nếu có)
                            .Select(device => new
                            {
                                HubPort = SplitHubAndPort(device.HubAndPort ?? "Không xác định"),
                                Vid = device.Vid ?? "Không có",
                                Pid = device.Pid ?? "Không có",
                                Manufacturer = device.Manufacturer ?? "Không xác định",
                                SerialNumber = device.SerialNumber ?? "Không có",
                                DevicePath = device.DevicePath,
                                DeviceId = device.DeviceId,
                                Description = device.Description ?? "Không xác định"
                            }).ToList()
                    }).ToList(),
                    Summary = this.Summary
                };

                // Chuyển đổi sang JSON và ghi file
                string json = JsonConvert.SerializeObject(reportData, Formatting.Indented);
                File.WriteAllText(filePath, json);

                // Không hiển thị MessageBox khi tự động xuất
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi xuất JSON: {ex.Message}");
            }
        }

    }
}