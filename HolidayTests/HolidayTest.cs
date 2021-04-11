using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    #region ノ(Step2 ぇㄏノ)

    public class HolidayForTest : HolidayService
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
    
    #endregion ノ(Step2 ぇㄏノ)

    #region 竧较竊ㄒStep1

    [TestFixture]
    public class HolidayTestStep1
    {
        [Test]
        [TestCase(TestName = "さぱ琌竧较竊肚Merry Xmas")]
        public void today_is_xmas()
        {
            var holiday = new HolidayService();
            var sayHello = holiday.IsHoliday();
            Assert.AreNotEqual("Merry Xmas", sayHello);
        }

        [Test]
        [TestCase(TestName = "さぱぃ琌竧较竊肚Today is not Xmas")]
        public void today_is_not_xmas()
        {
            var holiday = new HolidayService();
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Today is not Xmas", sayHello);
        }
    }

    #endregion 竧较竊ㄒStep1

    #region 竧较竊ㄒStep2

    /*
     * 琌瓃Step1いら戳ㄌ兵ン砆糶Module い礚猭北珿τㄒい璶盢ㄤ┾
     */

    [TestFixture]
    public class HolidayTestStep2
    {
        [TestCase(TestName = "さぱ琌竧较竊肚Merry Xmas")]
        public void today_is_xmas()
        {
            var holiday = new HolidayForTest();
            holiday.Today = new DateTime(2021, 12, 25);
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Merry Xmas", sayHello);
        }

        [TestCase(TestName = "さぱぃ琌竧较竊肚Today is not Xmas")]
        public void today_is_not_xmas()
        {
            var holiday = new HolidayForTest();
            holiday.Today = new DateTime(2021, 11, 25);
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Today is not Xmas", sayHello);
        }
    }

    #endregion 竧较竊ㄒStep2

    #region 竧较竊ㄒStep3

    /*
     * 琌瓃Step2い祘Α絏Τ睼馒珿τ秈︽篶
     */

    [TestFixture]
    public class HolidayTestStep3
    {
        [SetUp]
        public void SetUp()
        {
            _holiday = new HolidayForTest();
        }

        private HolidayForTest _holiday;

        [TestCase(TestName = "さぱ琌竧较竊肚Merry Xmas")]
        public void today_is_xmas()
        {
            GivenToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        private void ResponseShouldBe(string expected)
        {
            var sayHello = _holiday.IsHoliday();
            Assert.AreEqual(expected, sayHello);
        }

        private void GivenToday(int month, int day)
        {
            _holiday.Today = new DateTime(2021, month, day);
        }


        [TestCase(TestName = "さぱぃ琌竧较竊肚Today is not Xmas")]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

    }

    #endregion 竧较竊ㄒStep3

    #region 竧较竊ㄒStep3

    /*
     * 惠―穝糤キ璶肚 Merry Xmas
     */

    [TestFixture]
    public class HolidayTestStep4
    {
        [SetUp]
        public void SetUp()
        {
            _holiday = new HolidayForTest();
        }

        private HolidayForTest _holiday;

        [TestCase(TestName = "さぱ琌竧较竊肚Merry Xmas")]
        public void today_is_xmas()
        {
            GivenToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        private void ResponseShouldBe(string expected)
        {
            var sayHello = _holiday.IsHoliday();
            Assert.AreEqual(expected, sayHello);
        }

        private void GivenToday(int month, int day)
        {
            _holiday.Today = new DateTime(2021, month, day);
        }


        [TestCase(TestName = "さぱぃ琌竧较竊肚Today is not Xmas")]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

        [TestCase(TestName = "さぱ琌キ肚Merry Xmas")]
        public void today_is_xmas_when_dec_24()
        {
            GivenToday(12, 24);
            ResponseShouldBe("Merry Xmas");
        }

        [TestCase(TestName = "さぱぃ琌キ肚Merry Xmas")]
        public void today_is_not_xmas_when_nov_24()
        {
            GivenToday(11, 24);
            ResponseShouldBe("Today is not Xmas");
        }

    }

    #endregion 竧较竊ㄒStep3
}