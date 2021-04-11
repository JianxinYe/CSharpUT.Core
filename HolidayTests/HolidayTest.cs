using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    #region �@��(Step2 ����ϥ�)

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
    
    #endregion �@��(Step2 ����ϥ�)

    #region �t�ϸ`�ר�Step1

    [TestFixture]
    public class HolidayTestStep1
    {
        [Test]
        [TestCase(TestName = "���ѬO�t�ϸ`�A�^��Merry Xmas")]
        public void today_is_xmas()
        {
            var holiday = new HolidayService();
            var sayHello = holiday.IsHoliday();
            Assert.AreNotEqual("Merry Xmas", sayHello);
        }

        [Test]
        [TestCase(TestName = "���Ѥ��O�t�ϸ`�A�^��Today is not Xmas")]
        public void today_is_not_xmas()
        {
            var holiday = new HolidayService();
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Today is not Xmas", sayHello);
        }
    }

    #endregion �t�ϸ`�ר�Step1

    #region �t�ϸ`�ר�Step2

    /*
     * ���O�b�W�zStep1���A�]��������̱ۨ���A�Q�g�bModule ���A�L�k����A�G�Ӧb���רҤ��n�N���X
     */

    [TestFixture]
    public class HolidayTestStep2
    {
        [TestCase(TestName = "���ѬO�t�ϸ`�A�^��Merry Xmas")]
        public void today_is_xmas()
        {
            var holiday = new HolidayForTest();
            holiday.Today = new DateTime(2021, 12, 25);
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Merry Xmas", sayHello);
        }

        [TestCase(TestName = "���Ѥ��O�t�ϸ`�A�^��Today is not Xmas")]
        public void today_is_not_xmas()
        {
            var holiday = new HolidayForTest();
            holiday.Today = new DateTime(2021, 11, 25);
            var sayHello = holiday.IsHoliday();
            Assert.AreEqual("Today is not Xmas", sayHello);
        }
    }

    #endregion �t�ϸ`�ר�Step2

    #region �t�ϸ`�ר�Step3

    /*
     * ���O�b�W�zStep2���A�{���X�h���V���A�G�Ӷi�歫�c
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

        [TestCase(TestName = "���ѬO�t�ϸ`�A�^��Merry Xmas")]
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


        [TestCase(TestName = "���Ѥ��O�t�ϸ`�A�^��Today is not Xmas")]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

    }

    #endregion �t�ϸ`�ר�Step3

    #region �t�ϸ`�ר�Step3

    /*
     * �ݨD�s�W�G���w�]�A�]�n�^�� Merry Xmas
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

        [TestCase(TestName = "���ѬO�t�ϸ`�A�^��Merry Xmas")]
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


        [TestCase(TestName = "���Ѥ��O�t�ϸ`�A�^��Today is not Xmas")]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

        [TestCase(TestName = "���ѬO���w�]�A�^��Merry Xmas")]
        public void today_is_xmas_when_dec_24()
        {
            GivenToday(12, 24);
            ResponseShouldBe("Merry Xmas");
        }

        [TestCase(TestName = "���Ѥ��O���w�]�A�^��Merry Xmas")]
        public void today_is_not_xmas_when_nov_24()
        {
            GivenToday(11, 24);
            ResponseShouldBe("Today is not Xmas");
        }

    }

    #endregion �t�ϸ`�ר�Step3
}