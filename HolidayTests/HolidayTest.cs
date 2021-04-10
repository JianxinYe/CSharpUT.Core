using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{

    public class HolidayForTest : Holiday
    {
        private DateTime _today;

        public DateTime Today
        {
            set => _today = value;
        }

        protected override DateTime GetToday()
        {
            return _today;
        }
    }


    [TestFixture]
    public class HolidayTest
    {
        //[Test]
        //public void Test1()
        //{
        //    Assert.True(true);
        //}

        //[Test]
        //public void TodayIsXmasTest()
        //{
        //    var holiday = new Lib.Holiday();
        //    var msg = holiday.SayHello();

        //    Assert.AreEqual("Today is not Xmas", msg);
        //    //Assert.True(true);
        //}

        //[Test]
        //public void TodayIsNotXmasTest()
        //{
        //    var holiday = new Lib.Holiday();
        //    var msg = holiday.SayHello();

        //    Assert.AreNotEqual("Merry Xmas", msg);
        //    //Assert.True(true);
        //}

        //[Test]
        //public void OverrideTodayIsXmasTest()
        //{
        //    // 使用Override 製作
        //    var holiday = new  HolidayForTest();
        //    holiday.Today = new DateTime(2020, 12, 25);

        //    Assert.AreEqual("Merry Xmas", holiday.SayHello());
        //    //Assert.True(true);
        //}

        private HolidayForTest _holiday;

        [SetUp]
        public void SetUp()
        {
            _holiday = new HolidayForTest();
        }
        
        [Test]
        public void today_is_xmas()
        {
            GivenToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_xmas_when_12_24()
        {
            GivenToday(12, 24);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

        [Test]
        public void today_is_not_xmas_when_11_24()
        {
            GivenToday(11, 24);
            ResponseShouldBe("Today is not Xmas");
        }


        private void ResponseShouldBe(string expected)
        {
            Assert.AreEqual(expected, _holiday.SayHello());
        }

        private void GivenToday(int month, int day)
        {
            _holiday.Today = new DateTime(2020, month, day);
        }
    }
}