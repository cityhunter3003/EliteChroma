﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EliteChroma.Core.Tests.Internal;
using EliteChroma.Elite.Internal;
using EliteFiles.Bindings;
using Xunit;
using static EliteChroma.Core.Internal.NativeMethods;

namespace EliteChroma.Core.Tests
{
    [SuppressMessage("DocumentationRules", "SA1649:File name should match first type name", Justification = "xUnit test class.")]
    public class ModifierKeysWatcherTest
    {
        [Fact]
        public void GetsAllPressedModifiers()
        {
            var nmm = new NativeMethodsMock()
            {
                PressedKeys =
                {
                    VirtualKey.VK_LCONTROL,
                    (VirtualKey)'A',
                },
            };

            using var mkw = new ModifierKeysWatcher(nmm);

            var key1 = FromXml<DeviceKey>("<Key1 Device='Keyboard' Key='Key_LeftControl' />");
            var key2 = FromXml<DeviceKey>("<Key1 Device='Keyboard' Key='Key_LeftShift' />");
            var key3 = FromXml<DeviceKey>("<Key2 Device='Keyboard' Key='Key_A' />");

            mkw.Watch(new[] { key1, key2, key3 });

            var keys = mkw.InvokePrivateMethod<IEnumerable<DeviceKey>>("GetAllPressedModifiers").ToList();

            Assert.Contains(key1, keys);
            Assert.DoesNotContain(key2, keys);
            Assert.Contains(key3, keys);
        }

        private static T FromXml<T>(string xml)
            where T : DeviceKeyBase
        {
            var xe = XElement.Parse(xml);

            var fromXml = typeof(T).GetMethod("FromXml", BindingFlags.NonPublic | BindingFlags.Static);

            return (T)fromXml.Invoke(null, new object[] { xe });
        }

        private sealed class NativeMethodsMock : NativeMethodsStub
        {
            private const short _hiBit = unchecked((short)0x8000);

            public HashSet<VirtualKey> PressedKeys { get; } = new HashSet<VirtualKey>();

            public override short GetAsyncKeyState(VirtualKey vKey)
            {
                return PressedKeys.Contains(vKey) ? _hiBit : (short)0;
            }
        }
    }
}
