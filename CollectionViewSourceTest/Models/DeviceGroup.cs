using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionViewSourceTest.Models
{
    public class DeviceGroup : IGrouping<int, Device>
    {
        private readonly List<Device> _menuItemsGroup;

        public DeviceGroup(int key, IEnumerable<Device> items)
        {
            Key = key;
            _menuItemsGroup = new List<Device>(items);
        }

        public int Key { get; }

        public IEnumerator<Device> GetEnumerator() => _menuItemsGroup.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _menuItemsGroup.GetEnumerator();
    }
}