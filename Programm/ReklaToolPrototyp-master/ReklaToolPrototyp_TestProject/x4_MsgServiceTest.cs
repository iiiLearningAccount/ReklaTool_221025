using FakeItEasy;
using ReklaTool.Models;

namespace ReklaToolPrototyp_TestProject
{
    [TestClass]
    public class X4MsgServiceTests
    {
        [TestMethod]
        public void GetErsatzteile_ModelIsNotEmpty_ReturnsObject()
        {
            var vorgang_PositionErsatzteil = A.Fake<PositionErsatzteil[]>();
            var vorgan_model = A.Fake<VorgangDatenModelXml>{Ersatzteile = vorgang_PositionErsatzteil}

            var messager = A.Fake<X4MsgService>();
            var ersatzteile = A.Fake<PositionErsatzteil[]>();
            A.CallTo(() => messager.GetErsatzteile()).Returns(ersatzteile);

        }
    }
}