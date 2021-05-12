using NUnit.Framework;
using Spreetail.MultiValueDictionary.Services.Interfaces.v1;
using System;

namespace Spreetail.MultiValueDictionary.Services.Implementation.v1.Tests
{
    [TestFixture]
    public class MultiValueDictionaryImplTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestAddAndGetAllMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("baz", "bang");
            Assert.AreEqual(nvd.GetAllMembers().Count, 2);
            Assert.AreEqual(nvd.GetAllMembers().Contains("bar"), true);
            Assert.AreEqual(nvd.GetAllMembers().Contains("bar2"), false);
        }
        [Test]
        public void TestAddMethodException()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            Assert.Throws<Exception>(() => nvd.Add("foo", "bar"));
        }
        [Test]
        public void TestMembersMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo", "bar2");
            Assert.AreEqual(nvd.GetMembers("foo").Count, 2);
            Assert.AreEqual(nvd.GetMembers("foo").Contains("bar"), true);
            Assert.AreEqual(nvd.GetMembers("foo").Contains("bar4"), false);
        }
        [Test]
        public void TestMembersException()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo", "bar2");
            Assert.Throws<Exception>(() => nvd.GetMembers("foo2"));
        }
        [Test]
        public void TestGetKeyMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            Assert.AreEqual(nvd.GetKeys().Count, 2);
            Assert.AreEqual(nvd.GetKeys().Contains("foo"), true);
            Assert.AreEqual(nvd.GetKeys().Contains("foo2"), false);
        }
        [Test]
        public void TestRemoveAllMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            nvd.RemoveAll("foo3");
            Assert.AreEqual(nvd.GetKeys().Count, 1);
        }
        [Test]
        public void TestRemoveAllException()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            Assert.Throws<Exception>(() => nvd.RemoveAll("foo3"));
        }
        [Test]
        public void TestClearMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            nvd.Clear();
            Assert.AreEqual(nvd.GetKeys().Count, 0);
        }
        [Test]
        public void TestItemsMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            Assert.AreEqual(nvd.GetItems().Count, 2);
        }
        [Test]
        public void TestAllMembersMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            Assert.AreEqual(nvd.GetAllMembers().Count, 2);
            Assert.AreEqual(nvd.GetAllMembers().Contains("bar"), true);
            Assert.AreEqual(nvd.GetAllMembers().Contains("foo5"), false);
        }
        [Test]
        public void TestKeyExistMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            Assert.AreEqual(nvd.CheckKeyExists("foo3"), true);
        }
        [Test]
        public void TestValueExistMethod()
        {
            IMultiValueDictionary<string, string> nvd = new MultiValueDictionaryImpl<string, string>();
            nvd.Add("foo", "bar");
            nvd.Add("foo3", "bar2");
            Assert.AreEqual(nvd.CheckValueExists("foo", "bar"), true);
        }
    }
}