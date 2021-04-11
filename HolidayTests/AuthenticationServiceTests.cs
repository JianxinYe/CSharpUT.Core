using Lib;
using NSubstitute;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private IProfile _profile;
        private IToken _token;
        private AuthenticationService _target;
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _profile = Substitute.For<IProfile>();
            _token = Substitute.For<IToken>();
            _logger = Substitute.For<ILogger>();

            _target = new AuthenticationService(_profile, _token, _logger);
        }

        [Test()]
        public void is_valid()
        {
            // var target = new AuthenticationService();

            //var profile = new FakeProfile();
            //var token = new FakeToken();
            //var target = new AuthenticationService(profile, token);

            GivenPassword("joey", "91");
            GivenToken("000000");
            ShouldBeValid("joey", "91000000");
        }

        [Test()]
        public void is_invalid()
        {
            GivenPassword("joey", "91");
            GivenToken("000000");
            ShouldBeInvalid("joey", "wrong password");
        }

        [Test]
        public void should_log_account_when_invalid()
        {
            WhenInvalid("joey", "wrong password");
            ShouldLog("joey");
        }


        [Test]
        public void should_log_account_when_valid()
        {
            WhenInvalid("joey", "91");
            ShouldLog("joey");
        }

        private void ShouldLog(string account)
        {
            // �����p
            _logger.Received(1)
                .Notify(Arg.Is<string>(m => m.Contains(account) && m.Contains("")));
        }

        private void WhenInvalid(string account, string password)
        {
            GivenPassword(account, "91");
            GivenToken("000000");
            _target.IsValid(account, password);
        }

        private void ShouldBeValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsTrue(actual);
        }
        
        private void ShouldBeInvalid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsFalse(actual);
        }

        private void ShouldBeInvalidNotification(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsFalse(actual);
        }

        private void GivenToken(string token)
        {
            _token.GetRandom("").ReturnsForAnyArgs(token);
        }

        private void GivenPassword(string account, string password)
        {
            _profile.GetPassword(account).Returns(password);
        }

        public class FakeProfile : IProfile
        {
            public string GetPassword(string account)
            {
                return account == "joey" ? "91" : "";
            }
        }

        public class FakeToken : IToken
        {
            public string GetRandom(string account)
            {
                return "000000";
            }
        }
    }
}