using Conway.Library;
using NUnit.Framework;

namespace Comways.Library.Test
{//1İkiden az canlı komşusu olan herhangi bir canlı hücre, düşük nüfus gibi ölür.
    //1Any live cell with fewer than two live neighbours dies, as if by underpopulation.
    //2İki ya da üç canlı komşusu olan herhangi bir canlı hücre, yeni nesle yaşıyor.
    //2Any live cell with two or three live neighbours lives on to the next generation.
    //3Üçten fazla canlı komşusu olan herhangi bir canlı hücre, aşırı nüfus gibi ölür.
    //3Any live cell with more than three live neighbours dies, as if by overpopulation.
    //4Tam olarak üç canlı komşusu olan herhangi bir ölü hücre, üreme gibi canlı bir hücre haline gelir.
    //4Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    [TestFixture]
    public class LifeRulesTest
    {
        [Test]
        public void LiveCelle_FewerThan2LiveNeigbors_Dies(
            [Values(0,1)] int LiveNeigbours)
        {
            var currentState = Cellstate.Alive;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Dead, newState);
        }
        [Test]
        public void LiveCell_2Or3LiveNeighbors_Lives(
            [Values(2,3)] int LiveNeigbours)
        {
            var currentState = Cellstate.Alive;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Alive, newState);
        }
        [Test]
        public void LiveCell_MoreThan3LiveNeighbours_Dies(
            [Range(4,8)] int LiveNeigbours)
        {
            var currentState = Cellstate.Alive;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Dead, newState);
        }
        [Test]
        public void DeadCell_Exactly3LiveNeigbours_lives()
        {
            var LiveNeigbours = 3;
            var currentState = Cellstate.Dead;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Alive, newState);
        }
        [Test]
        public void DeadCell_FewerThan3LiveNeighbours_StayDead (
            [Range(0,2)] int LiveNeigbours)
        {
            var currentState = Cellstate.Dead;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Dead, newState);
        }
        [Test]
        public void DeadCell_MoreThan3LiveNeighbours_StayDead(
            [Range(4, 8)] int LiveNeigbours)
        {
            var currentState = Cellstate.Dead;
            Cellstate newState = LifeRules.GetNewState(currentState, LiveNeigbours);
            Assert.AreEqual(Cellstate.Dead, newState);
        }

    }
}
