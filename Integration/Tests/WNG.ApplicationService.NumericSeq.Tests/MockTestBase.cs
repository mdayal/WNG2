using Moq;
using Moq.Contrib.Indy;
using NUnit.Framework;

namespace WNG.ApplicationService.NumericSeq.Tests
{
    [TestFixture]
    public abstract class MockTestBase
    {
        protected MockRepository MockRepository;
        public AutoMockContainer Container;

        public void Setup(MockBehavior behavior)
        {
            MockRepository = new MockRepository(behavior);
            Container = new AutoMockContainer(MockRepository);
        }


        [SetUp]
        public virtual void TestSetup()
        {
            Setup(MockBehavior.Default);
        }

        [TearDown]
        public void VerifyAll()
        {
            MockRepository.VerifyAll();
        }
    }
}
