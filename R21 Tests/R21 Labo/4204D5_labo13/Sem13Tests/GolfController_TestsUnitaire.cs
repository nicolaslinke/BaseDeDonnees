using Labo13.Controllers;
using Labo13.Data;
using Labo13.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem13Tests
{
    public class GolfController_TestsUnitaire
    {
        [Fact]
        public async Task ScoresTrou_ListScorTrouValide()
        {
            Mock<Labo13Context> mockContext = new Mock<Labo13Context>();
            List<ScoreTrou> scoreTrou = new List<ScoreTrou>()
            {
                new ScoreTrou()
                {
                    ScoreTrouId = 1, DateTrou = new DateTime(), Terme = "a", Score = 3
                }
            };
            mockContext.Setup(x => x.ScoreTrous).ReturnsDbSet(scoreTrou);


            GolfController controller = new GolfController(mockContext.Object);
            IActionResult resultat = await controller.ScoresTrou();


            ViewResult viewResultat = Assert.IsType<ViewResult>(resultat);
        }
    }
}
