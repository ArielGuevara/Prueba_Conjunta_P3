using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public sealed class CirculoStepDefinitions
    {
        private readonly Circulo _circulo = new Circulo();
        private double _result = 0;

        [Given("the radius of the circle is {double}")]
        public void givenTheRadius(double radius)
        {
            _circulo.radius = radius;
        }

        [Given("the radius is elevated to square")]
        public void givenRadiusSquared()
        {
            _circulo.radiusSquared = _circulo.calculateRadiusSquared();  
        }

        [When("the radius elevated to square is multiplied by PI")]
        public void whenIsMultiplied()
        {
            _result = _circulo.calculateCircleArea(_circulo.radiusSquared);
        }

        [Then("the result is {double}")]
        public void ThenTheResultShouldBe(double result)
        {
            _result.CompareTo(result);
        }

    }
}
