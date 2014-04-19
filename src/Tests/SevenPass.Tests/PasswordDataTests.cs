﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using NUnit.Framework;
using SevenPass.IO;

namespace SevenPass.Tests
{
    [TestFixture]
    public class PasswordDataTests
    {
        [Test]
        public async Task Should_support_binary_keyfile()
        {
            using (var input = TestFiles.Read("Demo7Pass.bin"))
            {
                var data = new PasswordData();
                await data.AddKeyFile(input);

                Assert.AreEqual(
                    "96-4B-38-32-86-FB-A5-15-81-E8-44-76-25-76-67-1B-A0-2F-62-DC-98-34-A0-D4-95-4A-6D-00-23-D8-79-E8",
                    BitConverter.ToString(data.GetMasterKey().ToArray()));
            }
        }

        [Test]
        public async Task Should_support_hex_keyfile()
        {
            using (var input = TestFiles.Read("Demo7Pass.hex"))
            {
                var data = new PasswordData();
                await data.AddKeyFile(input);

                Assert.AreEqual(
                    "96-4B-38-32-86-FB-A5-15-81-E8-44-76-25-76-67-1B-A0-2F-62-DC-98-34-A0-D4-95-4A-6D-00-23-D8-79-E8",
                    BitConverter.ToString(data.GetMasterKey().ToArray()));
            }
        }

        [Test]
        public async Task Should_support_password_and_keyfile()
        {
            using (var input = TestFiles.Read("Demo7Pass.key"))
            {
                var data = new PasswordData
                {
                    Password = "demo",
                };
                await data.AddKeyFile(input);

                Assert.AreEqual(
                    "F7-8B-E1-03-50-F0-4C-C8-7D-3F-70-30-EE-DE-60-E3-37-99-C6-66-53-16-97-5B-B4-42-F8-B8-03-BD-6B-AA",
                    BitConverter.ToString(data.GetMasterKey().ToArray()));
            }
        }

        [Test]
        public void Should_support_password_only()
        {
            var data = new PasswordData
            {
                Password = "demo",
            };

            Assert.AreEqual(
                "17-59-39-01-89-83-AB-CA-A4-02-9B-A8-1E-61-AD-BA-A6-3F-3F-AB-E3-8B-ED-84-A9-ED-D0-3B-EA-58-7A-DE",
                BitConverter.ToString(data.GetMasterKey().ToArray()));
        }

        [Test]
        public async Task Should_support_xml_keyfile()
        {
            using (var input = TestFiles.Read("Demo7Pass.key"))
            {
                var data = new PasswordData();
                await data.AddKeyFile(input);

                Assert.AreEqual(
                    "2E-6F-69-54-FA-AD-F3-6C-27-B7-2D-93-DA-06-A8-F5-41-CC-54-C4-D4-E8-4D-B8-86-C0-E0-6E-99-AB-8E-48",
                    BitConverter.ToString(data.GetMasterKey().ToArray()));
            }
        }
    }
}