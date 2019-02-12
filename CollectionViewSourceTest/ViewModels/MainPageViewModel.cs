using Template10.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CollectionViewSourceTest.Models;

namespace CollectionViewSourceTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Device> _devices = new ObservableCollection<Device>();
        private IEnumerable<DeviceGroup> _groupedDevices;
        private int _selectedCommType;


        public MainPageViewModel()
        {
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 1, Name = "Name1"});
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 1, Name = "Name1.1"});
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 2, Name = "Name2"});
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 2, Name = "Name2.2"});
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 3, Name = "Name3"});
            _devices.Add(new Device{CommTypeId = 0, DeviceTypeId = 3, Name = "Name3.3"});
            _devices.Add(new Device{CommTypeId = 1, DeviceTypeId = 1, Name = "Name4"});
            _devices.Add(new Device{CommTypeId = 1, DeviceTypeId = 1, Name = "Name4.4"});
            _devices.Add(new Device{CommTypeId = 1, DeviceTypeId = 2, Name = "Name5"});
            _devices.Add(new Device{CommTypeId = 1, DeviceTypeId = 2, Name = "Name5.5"});
            CommTypes.Add(0);
            CommTypes.Add(1);
            SelectedCommType = 0;
        }


        public ObservableCollection<int> CommTypes { get; set; } = new ObservableCollection<int>();

        public int SelectedCommType
        {
            get => _selectedCommType;
            set
            {
                _selectedCommType = value;
                IEnumerable<DeviceGroup> grouped = _devices.OrderBy(d => d.Name)
                    .Where(d => d.CommTypeId == value)
                    .GroupBy(d => d.DeviceTypeId)
                    .Select(g => new DeviceGroup(g.Key, g));
                GroupedDevices = grouped;
            }
        }

        public IEnumerable<DeviceGroup> GroupedDevices
        {
            get => _groupedDevices;
            private set => Set(ref _groupedDevices, value);
        }
    }
}
