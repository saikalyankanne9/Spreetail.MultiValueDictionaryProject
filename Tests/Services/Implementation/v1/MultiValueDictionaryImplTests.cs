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
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("baz", "bang");
            Assert.AreEqual(mvd.GetAllMembers().Count, 2);
            Assert.AreEqual(mvd.GetAllMembers().Contains("bar"), true);
            Assert.AreEqual(mvd.GetAllMembers().Contains("bar2"), false);
        }
        [Test]
        public void TestAddMethodException()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            Assert.Throws<Exception>(() => mvd.Add("foo", "bar"));
        }
        [Test]
        public void TestMembersMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo", "bar2");
            Assert.AreEqual(mvd.GetMembers("foo").Count, 2);
            Assert.AreEqual(mvd.GetMembers("foo").Contains("bar"), true);
            Assert.AreEqual(mvd.GetMembers("foo").Contains("bar4"), false);
        }
        [Test]
        public void TestMembersException()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo", "bar2");
            Assert.Throws<Exception>(() => mvd.GetMembers("foo2"));
        }
        [Test]
        public void TestGetKeyMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            Assert.AreEqual(mvd.GetKeys().Count, 2);
            Assert.AreEqual(mvd.GetKeys().Contains("foo"), true);
            Assert.AreEqual(mvd.GetKeys().Contains("foo2"), false);
        }
        [Test]
        public void TestRemoveAllMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            mvd.RemoveAll("foo3");
            Assert.AreEqual(mvd.GetKeys().Count, 1);
        }
        [Test]
        public void TestRemoveAllException()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            Assert.Throws<Exception>(() => mvd.RemoveAll("foo3"));
        }
        [Test]
        public void TestClearMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            mvd.Clear();
            Assert.AreEqual(mvd.GetKeys().Count, 0);
        }
        [Test]
        public void TestItemsMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            Assert.AreEqual(mvd.GetItems().Count, 2);
        }
        [Test]
        public void TestAllMembersMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            Assert.AreEqual(mvd.GetAllMembers().Count, 2);
            Assert.AreEqual(mvd.GetAllMembers().Contains("bar"), true);
            Assert.AreEqual(mvd.GetAllMembers().Contains("foo5"), false);
        }
        [Test]
        public void TestKeyExistMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            Assert.AreEqual(mvd.CheckKeyExists("foo3"), true);
        }
        [Test]
        public void TestValueExistMethod()
        {
            IMultiValueDictionary<string, string> mvd = new MultiValueDictionaryImpl<string, string>();
            mvd.Add("foo", "bar");
            mvd.Add("foo3", "bar2");
            Assert.AreEqual(mvd.CheckValueExists("foo", "bar"), true);
        }
    }
}